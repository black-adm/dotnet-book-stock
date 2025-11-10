using System.Linq;
using System.Collections.Generic;

namespace Syscode42.Business.Core.Validations.Documents
{
    public class CPFValidation
    {
        public const int CPF_LENGTH = 11;

        public static bool IsValid(string cpf)
        {
            var cpfNumbers = Utils.OnlyNumbers(cpf);

            if (!ValidSize(cpfNumbers))
                return false;

            return !DuplicateDigits(cpfNumbers) && ValidDigits(cpfNumbers);
        }

        private static bool ValidSize(string value)
        {
            return value.Length == CPF_LENGTH;
        }

        private static bool DuplicateDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };

            return invalidNumbers.Contains(value);
        }

        private static bool ValidDigits(string value)
        {
            var valueNumber = value.Substring(0, CPF_LENGTH - 2);

            var verifyDigit = new VerifyDigit(valueNumber)
                .WithMultipliers(2, 11);

            var firstDigit = verifyDigit.CalculateDigit();
            verifyDigit.AddDigit(firstDigit);

            var secondDigit = verifyDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(CPF_LENGTH - 2);
        }
    }

    public class CNPJValidation
    {
        public const int CNPJ_LENGTH = 14;

        public static bool IsValid(string cnpj)
        {
            var cnpjNumbers = Utils.OnlyNumbers(cnpj);

            if (!ValidSize(cnpjNumbers))
                return false;

            return !DuplicateDigits(cnpjNumbers) && ValidDigits(cnpjNumbers);
        }

        private static bool ValidSize(string value)
        {
            return value.Length == CNPJ_LENGTH;
        }

        private static bool DuplicateDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };

            return invalidNumbers.Contains(value);
        }

        private static bool ValidDigits(string value)
        {
            var valueNumber = value.Substring(0, CNPJ_LENGTH - 2);

            var verifyDigit = new VerifyDigit(valueNumber)
                .WithMultipliers(2, 9)
                .Replacing("0", 10, 11);

            var firstDigit = verifyDigit.CalculateDigit();
            verifyDigit.AddDigit(firstDigit);

            var secondDigit = verifyDigit.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(CNPJ_LENGTH - 2);
        }
    }

    public class VerifyDigit
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _replaces = new Dictionary<int, string>();
        private bool _moduleComplement = true;

        public VerifyDigit(string number)
        {
            _number = number;
        }

        public VerifyDigit WithMultipliers(int from, int to)
        {
            _multipliers.Clear();

            for (var i = from; i <= to; i++)
                _multipliers.Add(i);

            return this;
        }

        public VerifyDigit Replacing(string replace, params int[] values)
        {
            foreach (var value in values)
                _replaces[value] = replace;

            return this;
        }

        public void AddDigit(string digit)
        {
            _number = string.Concat(_number, digit);
        }

        public string CalculateDigit()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var sum = 0;

            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                sum += product;

                if (++m >= _multipliers.Count)
                    m = 0;
            }

            var mod = (sum % Module);
            var result = _moduleComplement ? Module - mod : mod;

            return _replaces.ContainsKey(result) ? _replaces[result] : result.ToString();
        }
    }

    public class Utils
    {
        public static string OnlyNumbers(string value)
        {
            var onlyNumbers = "";

            foreach (var s in value)
            {
                if (char.IsDigit(s))
                    onlyNumbers += s;
            }

            return onlyNumbers.Trim();
        }
    }
}
