using System;
using System.Collections.Generic;
using System.Text;

namespace AESEncryption
{
    public interface IAesCryptoUtil
    {
        byte[] Encrypt(byte[] plainBytes);

        byte[] Decrypt(byte[] encryptedBytes);
    }
}
