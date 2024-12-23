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
        string alphabetMain = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Cho ma trận 5x5
        string alphabet; // Cho ma trận 5x5
        string temp;
        string alphabet6 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Cho ma trận 6x6
        string temp6;
        char[,] matrixLayout; 
        int version = 5;
        char removeChar = 'J';
        char replaceChar = 'I';

        public PlayfairCipher(char[,] matrixLayout = null, int version = 5)
        {
            this.matrixLayout = matrixLayout;
            this.version = version;
            this.alphabet = alphabetMain.Replace(removeChar.ToString(), "");
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
            // Khi không có khoá trả về mảng có chuỗi bình thường
            if (string.IsNullOrEmpty(key))
            {
                string alphabetToUse = version == 5 ? temp : temp6;
                ConvertToMatrix(alphabetToUse, matrix);
                return matrix;
            }
            // Bỏ ký tự tiếng việt
            key = RemoveDiacritics(key);
            if (version == 5)
            {
                key = new string(key.Where(char.IsLetter).Select(char.ToUpper).Distinct().ToArray()).Replace(removeChar, replaceChar);

            } else if(version == 6){
                key = new string(key.Where(char.IsLetterOrDigit).Select(char.ToUpper).Distinct().ToArray());
            }
            // Loại bỏ ký tự trùng lập
            string keyaf = new string(key.Distinct().ToArray());

            string alphabetUpdated = version == 5
                ? keyaf + new string(alphabet.Except(keyaf).ToArray())
                : keyaf + new string(alphabet6.Except(keyaf).ToArray());

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
        private string HandleMes(string mes, char firstSep = 'X', char secondSep = 'Y')
        {
            // Bỏ các ký tự tiếng việt
            mes = RemoveDiacritics(mes.ToUpper());
            if (version == 5)
            {
                mes = new string(mes.Where(char.IsLetter).ToArray()).Replace(removeChar, replaceChar);
            }
            else if (version == 6) {
                mes = new string(mes.Where(char.IsLetterOrDigit).Select(char.ToUpper).ToArray());
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < mes.Length; i++)
            {
                // Lấy chữ đầu tiên
                char currentChar = mes[i];
                result.Append(currentChar);

                if (i < mes.Length - 1 && mes[i] == mes[i + 1])
                {
                    result.Append(currentChar == firstSep ? secondSep : firstSep);
                }
            }

            // Trả chuỗi sau khi xử lý
            if (result.Length % 2 == 1)
            {
                result.Append(result[result.Length - 1] == firstSep ? secondSep : firstSep);
            }
            return result.ToString();
        }

        // Mã hoá 
        public string Encode(string mes, char firstSep = 'X', char secondSep = 'Y')
        {
            mes = HandleMes(mes, firstSep, secondSep);
            // Ra kết quả
            string result = "";
            for (int i = 0; i < mes.Length; i += 2)
                result += GetPairEncode(mes[i], mes[i + 1], matrixLayout);

            return mes + " " +result.ToUpper() ;
        }

        // Giải mã
        public string Decode(string mes)
        {
            if (mes.Length % 2 == 1) return "- Mật mã có số lượng lẻ, không hợp lệ.";
            mes = RemoveDiacritics(mes);
            mes = new string(mes.Where(char.IsLetterOrDigit).Select(char.ToUpper).ToArray()).Replace(removeChar, replaceChar);

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
        public void setAlphabet(char removeChar = 'J', char replaceChar = 'I')
        {
            this.removeChar = removeChar;
            this.replaceChar = replaceChar;
            this.alphabet = alphabetMain.Replace(removeChar.ToString(), "");
        }
    }
}
