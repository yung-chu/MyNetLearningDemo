using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSAEncryption
{
    public class RSAUtil
    {
        
        /// <summary>
        /// 生成密钥
        /// <param name="privateKey">私钥</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="keySize">密钥长度：512,1024,2048，4096，8192</param>
        /// </summary>
        public static void Generator(out string privateKey, out string publicKey, int KeySize = 2048)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(KeySize);
            privateKey = rsa.ToXmlString(true); //将RSA算法的私钥导出到字符串PrivateKey中 参数为true表示导出私钥 true 表示同时包含 RSA 公钥和私钥；false 表示仅包含公钥。
            publicKey = rsa.ToXmlString(false); //将RSA算法的公钥导出到字符串PublicKey中 参数为false表示不导出私钥 true 表示同时包含 RSA 公钥和私钥；false 表示仅包含公钥。
        }

        /// <summary>
        /// RSA加密 将公钥导入到RSA对象中，准备加密
        /// </summary>
        /// <param name="publicKey">公钥</param>
        /// <param name="encryptstring">待加密的字符串</param>
        public static string RSAEncrypt(string publicKey, string encryptstring)
        {
            byte[] cypherTextBArray;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            var plainTextBArray = new UnicodeEncoding().GetBytes(encryptstring);
            cypherTextBArray = rsa.Encrypt(plainTextBArray, false);
            return Convert.ToBase64String(cypherTextBArray);
        }

        /// <summary>
        /// RSA解密 将私钥导入RSA中，准备解密
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <param name="decryptstring">待解密的字符串</param>
        public static string RSADecrypt(string privateKey, string decryptstring)
        {
            byte[] dypherTextBArray;
            string result;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            var plainTextBArray = Convert.FromBase64String(decryptstring);
            dypherTextBArray = rsa.Decrypt(plainTextBArray, false);
            return new UnicodeEncoding().GetString(dypherTextBArray);
        }
    }
}
