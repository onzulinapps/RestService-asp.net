using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace RestAPIPlanningActivities.Crypt
{
    public class CryptoPass
    {
        //clase que usaremos para cifrar la clave en uyn solo sentido no se puede descifrar 
        public static byte[] GenerateHash(string password, byte[] salt)
        {
            byte[] passwordData = Encoding.UTF8.GetBytes(password);

            byte[] composite = new byte[passwordData.Length + 32];

            Array.Copy(passwordData, composite, passwordData.Length);
            Array.Copy(salt, 0, composite, passwordData.Length, salt.Length);

            SHA256 hashFunction = new SHA256Managed();
            byte[] hash = hashFunction.ComputeHash(composite);
            return hash;
        }
        //obtener salt
        public static byte[] GetSalt()
        {
            byte[] rngContainer = new byte[32];
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();
            rngProvider.GetBytes(rngContainer);

            return rngContainer;
        }
        //obtener salt desde una cadena
        public static byte[] GetSaltFromString(string source)
        {
            string[] raw = source.Split('-');
            byte[] result = new byte[raw.Length];
            for (int i = 0; i < raw.Length; i++)
            {
                result[i] = Convert.ToByte(raw[i], 16);
            }
            return result;
        }



    }
}