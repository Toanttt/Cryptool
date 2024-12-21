using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptool
{
    class PlayfairCipher
    {
        string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // Không có 'J'
        string temp;
        string alphabet6 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Cho ma trận 6x6
        string temp6;
        char[,] matrixLayout; 
        int version = 5; 

        public PlayfairCipher(char[,] matrixLayout = null, int version = 5)
        {
            this.matrixLayout = matrixLayout;
            this.version = version;
            temp = alphabet;
            temp6 = alphabet6;
        }

        // convert string thành ma trận
        void ConvertToMatrix(string str, char[,] matrix)
        {
            for (int i = 0; i < version; i++)
                for (int j = 0; j < version; j++)
                    matrix[i, j] = str[i * version + j];
        }

        // Lấy vị trí của char trong ma trận
        (int, int) FindPosition(char c, char[,] matrix)
        {
            for (int i = 0; i < version; i++)
                for (int j = 0; j < version ; j++)
                    if (matrix[i, j] == c) return (i, j);
            return (-1, -1);
        }

        // Lấy cặp char sau khi mã hoá 
        string GetPairEncode(char a, char b, char[,] matrix)
        {
            (int aPosi, int aPosj) = FindPosition(a, matrix);
            (int bPosi, int bPosj) = FindPosition(b, matrix);

            if (aPosi == bPosi) { aPosj = (aPosj + 1) % version; bPosj = (bPosj + 1) % version; }
            else if (aPosj == bPosj) { aPosi = (aPosi + 1) % version; bPosi = (bPosi + 1) % version; }
            else { (aPosj, bPosj) = (bPosj, aPosj); }

            return $"{matrix[aPosi, aPosj]}{matrix[bPosi, bPosj]}";
        }
        // Lấy cặp char sau khi giải mã 
        string GetPairDecode(char a, char b, char[,] matrix)
        {
            (int aPosi, int aPosj) = FindPosition(a, matrix);
            (int bPosi, int bPosj) = FindPosition(b, matrix);

            if (aPosi == bPosi) { aPosj = (aPosj + (version - 1)) % version; bPosj = (bPosj + (version - 1)) % version; }
            else if (aPosj == bPosj) { aPosi = (aPosi + (version - 1)) % version; bPosi = (bPosi + (version - 1)) % version; }
            else { (aPosj, bPosj) = (bPosj, aPosj); }

            return $"{matrix[aPosi, aPosj]}{matrix[bPosi, bPosj]}";
        }

        // Tạo ma trận theo khoá
        public char[,] createMatrix(string key)
        {
            char[,] matrix = new char[version, version];
            if (key == "" || key == null)
            {
                if(version == 5)
                { 
                    ConvertToMatrix(temp, matrix);
                } else if (version == 6)
                {
                    ConvertToMatrix(temp6, matrix);
                }
                return matrix;
            }
            key = RemoveDiacritics(key);
            if (version == 5)
            {
                key = new string(key.Where(char.IsLetter).Select(char.ToUpper).Distinct().ToArray()).Replace('J', 'I');

            } else if(version == 6){
                key = new string(key.Where(char.IsLetterOrDigit).Select(char.ToUpper).Distinct().ToArray());
            }

            string keyaf = new string(key.Distinct().ToArray());
            string alphabetUpdated="";

            if (version == 5)
            {
                alphabetUpdated = keyaf + new string(alphabet.Except(keyaf).ToArray());
            }
            else if (version == 6)
            {
                alphabetUpdated = keyaf + new string(alphabet6.Except(keyaf).ToArray());
            }


            ConvertToMatrix(alphabetUpdated, matrix);
            matrixLayout = matrix;

            return matrix;
        }

        // Xoá chữ trong tiếng việt
        private string RemoveDiacritics(string text)
        {
            string stFormD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in stFormD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        // Xử lý thông điệp cần mã hoá
        private string HandleMes(string input)
        {
            input = RemoveDiacritics(input.ToUpper());
            if (version == 5)
            {
                input = new string(input.Where(char.IsLetter).ToArray()).Replace('J', 'I');
            }
            else if (version == 6) {
                input = new string(input.Where(char.IsLetterOrDigit).Select(char.ToUpper).ToArray());
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                // Lấy chữ đầu tiên
                char currentChar = input[i];
                result.Append(currentChar);

                if (i < input.Length - 1 && input[i] == input[i + 1])
                {
                    result.Append(currentChar == 'X' ? 'Y' : 'X');
                }
            }

            if (result.Length % 2 == 1)
            {
                result.Append(result[result.Length - 1] == 'X' ? 'Y' : 'X');
            }
            return result.ToString();
        }

        // Mã hoá 
        public string Encode(string mes)
        {
            mes = HandleMes(mes);
            // Ra kết quả
            string result = "";
            for (int i = 0; i < mes.Length; i += 2)
                result += GetPairEncode(mes[i], mes[i + 1], matrixLayout);

            return result.ToUpper();
        }

        // Giải mã
        public string Decode(string mes)
        {
            if (mes.Length % 2 == 1) return "Mật mã có số lượng lẻ";
            mes = RemoveDiacritics(mes);
            mes = new string(mes.Where(char.IsLetterOrDigit).Select(char.ToUpper).ToArray());

            string result = "";
            for (int i = 0; i < mes.Length; i += 2)
                result += GetPairDecode(mes[i], mes[i + 1], matrixLayout);
            return result.ToUpper();
        }

        // get() ma trận
        public char[,]? getMatrix()
        {
            if (matrixLayout == null) return null;
            return matrixLayout;
        }
        // Thiết lập version cho Playfair
        public void setVersion(int version)
        {
            if (version == 5 || version == 6)
                this.version = version;
        }
    }
}
