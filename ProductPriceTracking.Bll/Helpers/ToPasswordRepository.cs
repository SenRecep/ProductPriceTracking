namespace ProductPriceTracking.Bll.Helpers
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class ToPasswordRepository
    {
        private static void NullCheck(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(@"There is no data to be encrypted");
            }
        }

        public static byte[] ConvertToByte(string data)
        {
            return new UnicodeEncoding().GetBytes(data);
        }

        public static byte[] Byte8(string value)
        {
            char[] arrayChar = value.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];
            for (int i = 0; i < arrayByte.Length; i++)
            {
                arrayByte[i] = Convert.ToByte(arrayChar[i]);
            }
            return arrayByte;
        }

        public static string Md5(string data)
        {
            NullCheck(data);
            MD5CryptoServiceProvider password = new MD5CryptoServiceProvider();
            byte[] passwordByte = password.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in passwordByte)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        public static string Sha1(string data)
        {
            NullCheck(data);


            SHA1CryptoServiceProvider sifre = new SHA1CryptoServiceProvider();
            byte[] sifrebytes = sifre.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in sifrebytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        public static string Sha256(string data)
        {
            NullCheck(data);

            SHA256Managed sifre = new SHA256Managed();
            byte[] arySifre = ConvertToByte(data);
            byte[] aryHash = sifre.ComputeHash(arySifre);
            return BitConverter.ToString(aryHash);
        }

        public static string Sha384(string data)
        {
            NullCheck(data);

            SHA384Managed sifre = new SHA384Managed();
            byte[] arySifre = ConvertToByte(data);
            byte[] aryHash = sifre.ComputeHash(arySifre);
            return BitConverter.ToString(aryHash);
        }

        public static string Sha512(string data)
        {
            NullCheck(data);
            SHA512Managed sifre = new SHA512Managed();
            byte[] arySifre = ConvertToByte(data);
            byte[] aryHash = sifre.ComputeHash(arySifre);
            return BitConverter.ToString(aryHash);
        }

        public static string PasswordCryptographyCombine(string data)
        {
            return Md5(Sha384(Sha256(data)));
        }
    }
}
