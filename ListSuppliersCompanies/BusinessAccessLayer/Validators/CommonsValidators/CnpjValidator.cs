using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validators.CommonsValidators
{
    internal static class CnpjValidator
    {
        public static IRuleBuilderOptions<Object, string> IsCnpjValid<Object>(this IRuleBuilder<Object, string> param)
        {
            return param.Must(c => ValidateCnpj(c));
        }

        public static bool ValidateCnpj(string cnpj)
        {
            cnpj = CleanCnpj(cnpj);

            if (cnpj.Length != 14)
                return false;

            if (AllDigisEquals(cnpj))
                return false;

            int digit1 = CalculateDigit(cnpj, 12, 2);

            int digit2 = CalculateDigit(cnpj, 13, 2);

            return digit1 == int.Parse(cnpj[12].ToString()) && digit2 == int.Parse(cnpj[13].ToString());
        }

        private static string CleanCnpj(string cnpj)
        {
            return cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
        }

        private static bool AllDigisEquals(string cnpj)
        {
            for (int i = 1; i < cnpj.Length; i++)
            {
                if (cnpj[i] != cnpj[0])
                    return false;
            }
            return true;
        }

        private static int CalculateDigit(string cnpj, int position, int weight)
        {
            int sum = 0;
            for (int i = 0; i < position; i++)
            {
                sum += int.Parse(cnpj[i].ToString()) * weight--;
                if (weight < 2)
                {
                    weight = 9;
                }
            }
            int rest = sum % 11;
            return rest < 2 ? 0 : 11 - rest;
        }
    }
}
