using System;

namespace DSC.SmartMarket.BusinessLogic.Common
{
    public static class Valida
    {
        public static bool ValidaCPF(string CPF)
        {
            if (string.IsNullOrEmpty(CPF) || (CPF.Length != 11))
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
            {
                if (CPF[i] != CPF[0])
                {
                    igual = false;
                    break;
                }
            }

            if (igual || CPF == "12345678909")
            {
                return false;
            }

            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
            {
                numeros[i] = Convert.ToInt32(CPF[i].ToString());
            }

            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            int resultado = soma % 11;
            if ((resultado == 1) || (resultado == 0))
            {
                if (numeros[9] != 0)
                {
                    return false;
                }
            }
            else if (numeros[9] != (11 - resultado))
            {
                return false;
            }

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;
            if ((resultado == 1) || (resultado == 0))
            {
                if (numeros[10] != 0)
                {
                    return false;
                }
            }
            else if (numeros[10] != (11 - resultado))
            {
                return false;
            }

            return true;
        }

        public static bool ValidaCNPJ(string CNPJ)
        {
            if (CNPJ.Length != 14)
            {
                return false;
            }

            int nrDig;
            string ftmt = "6543298765432";
            int[] digitos = new int[14];
            int[] soma = new int[2] { 0, 0 };
            int[] resultado = new int[2] { 0, 0 };
            bool[] CNPJOk = new bool[2] { false, false };

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = Convert.ToInt32(CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * Convert.ToInt32(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * Convert.ToInt32(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                    {
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    }
                    else
                    {
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                    }
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }
    }
}
