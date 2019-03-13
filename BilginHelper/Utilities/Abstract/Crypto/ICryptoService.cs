using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.Utilities.Abstract.Crypto
{
    public interface ICryptoService
    {

        /// <summary>
        /// test
        /// </summary>
        /// <param name="size">test2</param>
        /// <returns>test3</returns>
        string CreateSalt(int size);
        string Encrypt(string plainText, string saltCode);
        string Decrypt(string cipherText, string saltCode);
    }
}
