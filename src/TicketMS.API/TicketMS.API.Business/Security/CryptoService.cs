using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using TicketMS.API.Infrastructure.Services;

namespace TicketMS.API.Business.Security
{
    public class CryptoService : ICryptoService
    {
        private readonly RandomNumberGenerator numberGenerator;
        private readonly HashAlgorithm hashAlgorithm;

        public CryptoService(RandomNumberGenerator numberGenerator, HashAlgorithm hashAlgorithm)
        {
            this.numberGenerator = numberGenerator;
            this.hashAlgorithm = hashAlgorithm;
        }

        public byte[] GenerateRandomBytes(int length)
        {
            var salt = new byte[length];
            numberGenerator.GetBytes(salt);
            return salt;
        }

        public byte[] ComputeHash(byte[] bytes)
        {
            return hashAlgorithm.ComputeHash(bytes);
        }

        public byte[] Xor(params byte[][] bytes)
        {
            var size = bytes.First().Length;
            var xorResult = new BitArray(bytes.First().Length * 8);

            foreach (var arr in bytes)
            {
                xorResult = xorResult.Xor(new BitArray(arr));
            }

            var result = new byte[size];
            xorResult.CopyTo(result, 0);
            return result;
        }
    }
}
