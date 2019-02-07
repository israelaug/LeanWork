using System;
using LeanWorkProject.Models;

namespace LeanWorkProject.Helpers
{
    public static class CardValidator
    {
        public static bool Validate(Card card)
        {
            if (card.Number == null || card.Number == "")
                return false;

            if (!ValidFlagPatterns(card))
                return false;
           
            int position = 1;
            int total = 0;
            string reverseNumber = ReverseString(card.Number);
            
            foreach (char c in reverseNumber.ToCharArray())
            {
                var textNumber = c.ToString();

                if(!CardValidator.IsNumericPositive(textNumber))
                    return false;

                int number = int.Parse(textNumber);

                //dobre o valor de cada número de forma alternada
                if (IsEvenInt(position))
                {
                    number = number * 2;
                    
                    //Para dígitos maiores que 9, subtraia o valor por 9
                    if (number > 9)
                        number = number - 9;
                }

                //Some todos os números da sequência.
                total += number;
                position++;
            }

            //Se o total for múltiplo de 10, o número é válido.
            if (total % 10 == 0)
                return true;

            return false;
        }

        public static string ReverseString(string text)
        {
            char[] charArray = text.ToCharArray();

            Array.Reverse(charArray);

            return new String(charArray);
        }

        public static bool IsEvenInt(int number)
        {
            return (number % 2 == 0);
        }

        public static bool IsNumericPositive(string number)
        {
            int temp;
            var convertable = int.TryParse(number, out temp);
            var parsedNegative = int.Parse(number) < 0;
            return (convertable || !parsedNegative);
        }

        // Deprecated
        // public static bool IsNumericPositive(string number)
        // {
        //     char[] charArray = number.ToCharArray();
        //     int temp = 0;

        //     foreach(var n in charArray)
        //     {
        //         if (!int.TryParse(number, out temp) || int.Parse(number) < 0)
        //             return false;
        //     }
            
        //     return true;
        // }

        private static bool ValidFlagPatterns(Card card)
        {
            bool result = false;
            string firstNumbers;
            switch (card.CardFlag.ToUpper())
            {
                case "AMEX":
                    firstNumbers = card.Number.Substring(0,2);
                    result = (card.Number.Length == 15 && (firstNumbers == "37" || firstNumbers == "34"));
                break;

                case "DISCOVER":
                    firstNumbers = card.Number.Substring(0,4);
                    result = (card.Number.Length == 16 && firstNumbers == "6011");
                break;

                case "MASTERCARD":
                    firstNumbers = card.Number.Substring(0,2);
                    var tempNumber = int.Parse(firstNumbers);
                    result = (card.Number.Length == 16 && (tempNumber >= 51 && tempNumber <= 55)); // between 51-55
                break;

                case "VISA":
                    firstNumbers = card.Number.Substring(0,1);
                    result = ((card.Number.Length == 16 || card.Number.Length == 13) && firstNumbers == "4");
                break;
            }

            return result;
        }
    }
}
