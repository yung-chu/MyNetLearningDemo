using System;

namespace RSAEncryption
{
    ///https://www.cnblogs.com/heimalang/p/6496856.html
    /// <summary>
    /// RSA加密算法流程如下：
    //1、首先 【系统】 生成一对密钥，即私钥和公钥
    //2、然后，【系统】 将公钥发送给 【用户】
    //3、【用户】用收到的公钥对数据加密，再发送给【系统】
    //4、【系统】 收到数据后，使用自己的私钥解密，返回密码

    //由于在非对称算法中，公钥加密的数据必须用对应的私钥才能解密，而私钥又只有接收方自己知道，
    //这样就保证了数据传输的安全性。
    //理论性比较强，下面通过一个DEMO进行代码的演示：
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string privateKey;
            string publicKey;
            string input = "test";

            //1生成一对密钥，即私钥和公钥
            RSAUtil.Generator(out privateKey, out publicKey);

             Console.WriteLine(privateKey+" "+ publicKey);

            //2.用收到的公钥对数据加密
            string decryptstring = RSAUtil.RSAEncrypt(publicKey, input);

        

           //3.使用自己的私钥解密
           Console.WriteLine(RSAUtil.RSADecrypt(privateKey, decryptstring)); 

        }
    }



}
