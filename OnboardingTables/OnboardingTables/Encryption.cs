using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;

namespace OnboardingTables
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class ConnectionEncryption
    {
        static string OIDValue = "2.16.840.1.101.3.4.1.42";
        private const string END_MARKER = "@@##";

        private string m_sKeyName = "";

        public ConnectionEncryption()
        {
        }

        public ConnectionEncryption(string NameValue)
        {
            m_sKeyName = NameValue;
        }

        /// <summary>
        /// Public method called to encrypt the passed in string and return the 
        /// encrypted string.
        /// </summary>
        /// <param name="InitialString">String value to encrypt</param>
        /// <returns>Encrypted string value</returns>
        public string EncryptString(string InitialString)
        {

            InitialString += END_MARKER;
            string sName = "";

            if (m_sKeyName == "")
                sName = System.Environment.MachineName;
            else
                sName = m_sKeyName;

            TripleDESCryptoServiceProvider provider = FormatProvider(sName);

            if (InitialString.Length % 4 != 0)
            {
                int iDif = InitialString.Length % 4;
                InitialString = InitialString.PadRight(InitialString.Length + iDif, ' ');
            }

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] baUnEnc = new byte[Encoding.Unicode.GetMaxByteCount(InitialString.Length)];
            baUnEnc = Encoding.Unicode.GetBytes(InitialString);

            ms.Position = 0;
            cs.Write(baUnEnc, 0, baUnEnc.Length);
            cs.Flush();
            cs.Close();
            ms.Close();
            byte[] baEnc = ms.GetBuffer();

            string sEncrypted = Convert.ToBase64String(baEnc);
            return sEncrypted;
        }


        /// <summary>
        /// Public method called to decrypt the passed in string.  This string is 
        /// assumed to have been encrypted using the encrypt string method provided
        /// by this module.
        /// </summary>
        /// <param name="InitialString">String value to decrypt</param>
        /// <returns>Decrypted string value</returns>
        public string DecryptString(string InitialString)
        {
            string decryptedValue = string.Empty;
            if (!ConnectionEncryption.isEncryptedwithCertificate(InitialString))
            {
                string sName = "";

                if (m_sKeyName == "")
                    sName = System.Environment.MachineName;
                else
                    sName = m_sKeyName;

                TripleDESCryptoServiceProvider provider = FormatProvider(sName);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write);

                byte[] baIn = Convert.FromBase64String(InitialString);

                ms.Position = 0;
                cs.Write(baIn, 0, baIn.Length);
                cs.Flush();
                ms.Close();

                byte[] baOut = ms.GetBuffer();

                string sUnencrypted = Encoding.Unicode.GetString(baOut);
                // trim off everything after the end marker
                int iPos = sUnencrypted.IndexOf(END_MARKER);
                if (iPos > -1)
                    sUnencrypted = sUnencrypted.Substring(0, iPos);

                decryptedValue = sUnencrypted;
            }
            else
            {
                decryptedValue = this.DecryptStringWithCertificate(InitialString);
            }

            return decryptedValue;
        }


        /// <summary>
        /// Private method called to format the TripleDESCryptoServiceProvider
        /// object and initialize the key and iv values.
        /// </summary>
        /// <param name="Name">
        /// String value to used in formatting the key and iv for the encryption/
        /// decryption routines.
        /// </param>
        /// <returns></returns>
        private TripleDESCryptoServiceProvider FormatProvider(string Name)
        {

            TripleDESCryptoServiceProvider tdp = new TripleDESCryptoServiceProvider();
            tdp.Key = FormatKey(Name);
            tdp.IV = FormatIV(Name);

            return tdp;
        }


        /// <summary>
        /// Private method called to format the key used by the TripleDES encryption 
        /// algorythym.  This key is based on the passed in name value.
        /// </summary>
        /// <param name="Name">String value to use for formatting the encryption key</param>
        /// <returns>Byte array containing the encryption key</returns>
        private byte[] FormatKey(string Name)
        {

            string sKey = "";

            // reverse it
            for (int i = Name.Length - 1; i >= 0; i--)
            {
                sKey += Name.Substring(i, 1);
            }

            // pad it
            if (sKey.Length < 24)
            {
                for (int i = sKey.Length; i < 24; i++)
                {
                    int iValue = (i % 8);
                    sKey += iValue.ToString();
                }
            }

            byte[] baKey = Encoding.Unicode.GetBytes(sKey.ToCharArray(), 0, 12);
            // return it
            return baKey;
        }



        /// <summary>
        /// Private method called to format the initialization vector used by the 
        /// triple des encription algorythym.
        /// </summary>
        /// <param name="Name">String value to use for initializing the IV key</param>
        /// <returns>Byte array used for the IV parameter of the TripleDES encryptor</returns>
        private byte[] FormatIV(string Name)
        {
            string sIV = Name.Length.ToString();
            sIV += Name.GetHashCode().ToString();
            sIV += sIV.PadRight(10, '\n');

            byte[] baIV = Encoding.Unicode.GetBytes(sIV.ToCharArray(), 0, 4);
            return baIV;
        }

        /// <summary>
        /// Encrypt the message with the public key of the recipient. This is done by enveloping the message by using an EnvelopedCms object.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="recipientCert"></param>
        /// <returns></returns>
        public string EncryptStringWithCertificate(string msg, X509Certificate2 recipientCert)
        {

            ContentInfo contentInfo = new ContentInfo(Encoding.UTF8.GetBytes(msg));

            // Setting is encrypted using AES 256 CBC and a random data-encryption key. 
            // The data-encryption key is encrypted using the public key of the certificate. 
            EnvelopedCms envelopedCms = new EnvelopedCms(contentInfo, new AlgorithmIdentifier(new Oid(OIDValue)));

            CmsRecipient recip1 = new CmsRecipient(
                SubjectIdentifierType.IssuerAndSerialNumber,
                recipientCert);

            envelopedCms.Encrypt(recip1);

            // The thumbprint servers two purposes. 
            // 1. It tells the thumbrpint of the certificate used to encrypt the setting so that it can be verified if this 
            //    certificate has been associated with the cloud service. 
            // 2. It gives a way to check if this value is encrypted. If the value does not start with [Thumbprint:
            //    it is assumed to be in clear text and is returned as such. 
            return string.Format("[Thumbprint:{0}]{1}", recipientCert.Thumbprint, Convert.ToBase64String(envelopedCms.Encode()));
        }

        /// <summary>
        /// Decrypt the encoded EnvelopedCms message.
        /// </summary>
        /// <param name="encodedEnvelopedCms"></param>
        /// <returns></returns>  
        public string DecryptStringWithCertificate(string encodedEnvelopedCms)
        {

            // This should be in the format [Thumbprint:ThumbprintValue]EncryptedSetting. So we split at ] to get
            // the encrypted setting. 
            try
            {
                if (isEncryptedwithCertificate(encodedEnvelopedCms))
                {
                    // EnvelopedCms stores the certificate to be used for decrypting the data-encryption key with the encrypted blob. 
                    // We do not need to specify decryption certificate here. 
                    EnvelopedCms envelopedCms = new EnvelopedCms();

                    // Decrypt it and set it in the cache. 

                    encodedEnvelopedCms = encodedEnvelopedCms.Substring(encodedEnvelopedCms.IndexOf(']') + 1);

                    envelopedCms.Decode(Convert.FromBase64String(encodedEnvelopedCms));

                    envelopedCms.Decrypt(envelopedCms.RecipientInfos[0]);

                    return Encoding.UTF8.GetString(envelopedCms.ContentInfo.Content);
                }
                else

                    return encodedEnvelopedCms;
            }
            catch (IndexOutOfRangeException)
            {
                throw new FormatException("Encrypted setting was not in the correct format. Expecting [Thumbprint:ThumbprintValue]EncryptedSetting");
            }
        }

        /// <summary>
        /// This method returns true if the value is encrypted. We assume it to be encrypted, if the setting starts with [Thumbprint:
        /// </summary>
        /// <param name="protectedConfigurationSettingValue"></param>
        /// <returns></returns>
        private static bool isEncryptedwithCertificate(string protectedConfigurationSettingValue)
        {
            if (protectedConfigurationSettingValue.StartsWith("[Thumbprint:"))
                return true;

            return false;
        }

        /// <summary>
        /// Get certificate from the Local Machine store, based on the given thumbprint
        /// </summary>
        /// <param name="thumbprint"></param>
        /// <returns></returns>
        public static X509Certificate2 GetCertificate(string thumbprint)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);

            try
            {
                X509Certificate2 result = null;

                if (!string.IsNullOrEmpty(thumbprint))
                {
                    certificates = store.Certificates;

                    for (int i = 0; i < certificates.Count; i++)
                    {
                        X509Certificate2 cert = certificates[i];

                        if (cert.Thumbprint.ToLower().CompareTo(thumbprint.ToLower()) == 0)
                        {
                            result = new X509Certificate2(cert);

                            return result;
                        }
                    }

                    if (result == null)
                    {
                        throw new ApplicationException(string.Format("No certificate was found in Computer Account for thumbprint {0}", thumbprint));
                    }
                }
                return null;
            }
            finally
            {
                if (certificates != null)
                {
                    for (int i = 0; i < certificates.Count; i++)
                    {
                        X509Certificate2 cert = certificates[i];
                        cert.Reset();
                    }
                }
                store.Close();
            }
        }
    }
}
