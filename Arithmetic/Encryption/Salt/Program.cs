using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MD5Encryption;

namespace Salt
{
    /// <summary>
    /// 相同的明文用同样的加密方法（如MD5）进行加密会得到相同的密文。

    //如用MD5的方式加密“123456”，你总会得到密文“E10ADC3949BA59ABBE56E057F20F883E”。
    //那么，当数据库信息泄漏时，如果你的密码设置的比较简单，对方是很容易猜到你的密码，或者通过彩虹表来破解你的密码。
    //因此，你需要在明文中添加干扰项-盐（Salt）。

    //对于加盐的方式，我认为有两种。
    //1.对于只加密，但不解密的算法，如MD5，SHA1。我们需要把盐和密文都存在数据库中，用户输入密码时，
    //我们把用户密码和盐组成新的明文，进行加密，然后得到密文，最后对比该密文是否与库中密文匹配。

    //2.对于可加解密的算法，我们可以定义一些规则，如明文前加长度为3的盐，在明文后加长度为5的盐，
    //然后进行加密。解密的时候可以按预先设置的规则把盐去掉就能得到真正的明文。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            EncryptWithSalt("Hello World!");
        }

        /// <summary>
        /// 使用md5加盐
        /// </summary>
        /// <param name="plainText"></param>
        public static void EncryptWithSalt(string plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var headSalt = SaltUtil.GenerateSalt(3);//加盐头
            var tailSalt = SaltUtil.GenerateSalt(2);//加盐尾
            var plainBytesWithSalts = BytesUtil.Combine(headSalt, plainBytes, tailSalt);
            var encryptedBytes = Md5Util.Encrypt(plainBytesWithSalts);
            var encryptedText = BytesUtil.ToHex(encryptedBytes);

            Console.WriteLine("Plain text:{0}, encrypted text:{1}", plainText, encryptedText);
        }

    }

    /// <summary>
    /// 加盐
    /// </summary>
    public class SaltUtil 
    {
        public static byte[] GenerateSalt(int size)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[size];
                rng.GetBytes(salt);
                return salt;
            }
        }
    }


    public  class BytesUtil
    {
        /// <summary>
        /// 组合字节
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public static byte[] Combine(params byte[][] arrays)
        {
            var result = new byte[arrays.Sum(a => a.Length)];

            var offset = 0;

            foreach (var array in arrays)
            {
                Buffer.BlockCopy(array, 0, result, offset, array.Length);
                offset += array.Length;
            }

            return result;
        }


        public static string ToHex(byte[] bytes)
        {
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.AppendFormat("{0:X2}", b);
            }
            return builder.ToString();
        }
    }
}
