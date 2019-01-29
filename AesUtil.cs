using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaiduAPITool
{
    public class AesUtil
    {
        private static byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//dfdf

        public static string AESEncrypt(string plainText)
        {
            byte[] key = HexUtil.StringToByteArray(DataProcessor.GetXmlNodeValue(Program.baiduKeyInfoPath, "AesKey"));
            //分组加密算法  
            //Aes des = Aes.Create();

            byte[] inputByteArray = Encoding.Default.GetBytes(plainText);//得到需要加密的字节数组      
            //设置密钥及密钥向量  
            AesManaged aesCipher = new AesManaged();
            aesCipher.KeySize = 128;
            aesCipher.BlockSize = 128;
            aesCipher.Mode = CipherMode.CBC;
            aesCipher.Padding = PaddingMode.PKCS7;
            aesCipher.Key = key;
            aesCipher.IV = iv;
            var encryptTransform = aesCipher.CreateEncryptor();
            byte[] cipherBytes = encryptTransform.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

            string hex = BitConverter.ToString(cipherBytes).Replace("-", "");
            hex = hex.ToLower();
            return hex;
        }

        public static string AESDecrypt(string plainText,string characterSet)
        {
            byte[] key = HexUtil.StringToByteArray(DataProcessor.GetXmlNodeValue(Program.baiduKeyInfoPath, "AesKey"));
            AesManaged aesCipher = new AesManaged();

            aesCipher.Mode = CipherMode.CBC;
            aesCipher.Padding = PaddingMode.PKCS7;
            aesCipher.Key = key;
            aesCipher.IV = iv;
            var decryptTransform = aesCipher.CreateDecryptor();
            var toDecryptData = HexUtil.StringToByteArray(plainText);
            byte[] decryptedData = decryptTransform.TransformFinalBlock(toDecryptData, 0, toDecryptData.Length);
            string result = Encoding.GetEncoding(characterSet).GetString(decryptedData);
            return result;
        }
    }
}
