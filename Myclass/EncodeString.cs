using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace CrudCore.Myclass
{
    public class EncodeString
    {
        public static string MD5HashCrytography(string string2Md5)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(string2Md5));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
            {
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            }
            string2Md5 = sb.ToString();
            
            return string2Md5;

        }
        public static string EncodeTo64(string Text)
            {
            byte[] ToEncode = Encoding.Unicode.GetBytes(Text);
            string returnEncode = Convert.ToBase64String(ToEncode);
            
            return returnEncode;

            }

        public static string DecoderFrom64(string Text) 
        { 
            byte[] ToDecode = Convert.FromBase64String(Text);
            String returnDecode = Encoding.Unicode.GetString(ToDecode);
            
            return returnDecode;


        }

         
    }
}
