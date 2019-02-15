using System;
using System.Security.Cryptography;
using System.Text;

namespace AESEncryption
{
    ///http://www.cnblogs.com/Erik_Xu/p/5349880.html
    /// <summary>
    /// 1.高级加密标准（英语：Advanced Encryption Standard，缩写：AES）,高级加密标准 是对称密钥加密中最流行的算法之一。

    /// 2.对称密钥加密又叫专用密钥加密或共享密钥加密，
    /// 即发送和接收数据的双方必使用相同的密钥对明文进行加密和解密运算。
    /// 对称密钥加密算法主要包括：DES、3DES、IDEA、RC5、RC6等。
    /// </summary>
    class Program
    {
        //加密键
        private static string key = "AecCrypto";
       

        static void Main(string[] args)
        {
            string encryptedTextOutPut = string.Empty;
            Encrypt("123456",ref encryptedTextOutPut);

            Decrypt(encryptedTextOutPut);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText"></param>
        public static void Encrypt(string plainText,ref string encryptedTextOutPut)
        {
            AesCryptoUtil aesCryptoUtil = new AesCryptoUtil(key);
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var encryptedBytes = aesCryptoUtil.Encrypt(plainBytes);
             encryptedTextOutPut = Convert.ToBase64String(encryptedBytes);

            Console.WriteLine("Plain text:{0}, encrypted text:{1}", plainText, encryptedTextOutPut);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedText"></param>
        public static  void Decrypt(string encryptedText)
        {
            AesCryptoUtil aesCryptoUtil = new AesCryptoUtil(key);
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var plainBytes = aesCryptoUtil.Decrypt(encryptedBytes);
            var plainText = Encoding.UTF8.GetString(plainBytes);

            Console.WriteLine("Encrypted text:{0}, plain text:{1}", encryptedText, plainText);
        }

    }



}
