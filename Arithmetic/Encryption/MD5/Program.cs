using System;
using System.Security.Cryptography;
using System.Text;

namespace MD5Encryption
{
    /// <summary>
    /// MD5即Message-Digest Algorithm 5（信息-摘要算法5），用于确保信息传输完整一致。
    /// 是计算机广泛使用的杂凑算法之一（又译摘要算法、哈希算法），主流编程语言普遍已有MD5实现。
    /// 将数据（如汉字）运算为另一固定长度值，是杂凑算法的基础原理，MD5的前身有MD2、MD3和MD4。

    ///MD5算法具有以下特点：
    ///1、压缩性：任意长度的数据，算出的MD5值长度都是固定的。
    ///2、容易计算：从原数据计算出MD5值很容易。
    ///3、抗修改性：对原数据进行任何改动，哪怕只修改1个字节，所得到的MD5值都有很大区别。
    ///4、强抗碰撞：已知原数据和其MD5值，想找到一个具有相同MD5值的数据（即伪造数据）是非常困难的。
    ///
    /// 　注：MD5常用于密码加密。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Encrypt("Hello World!");
        }


        public static void Encrypt(string plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var encryptedBytes = Md5Util.Encrypt(plainBytes);
            var stringBuilder = new StringBuilder();
            foreach (var b in encryptedBytes)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            var encryptedText = stringBuilder.ToString();

            Console.WriteLine("Plain text:{0}, encrypted text:{1}", plainText, encryptedText);
        }

    }


    public class Md5Util
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainBytes"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] plainBytes)
        {
            using (var md5 = MD5.Create())
            {
                var encryptedBytes = md5.ComputeHash(plainBytes);
                return encryptedBytes;
            }
        }
    }
}
