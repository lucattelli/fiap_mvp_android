using System.Text.RegularExpressions;

namespace DSC.SmartMarket.BusinessLogic.Common
{
    public static class Formata
    {
        #region CNPJ
        public static string FormataCNPJ(string CNPJ)
        {
            if (string.IsNullOrEmpty(CNPJ))
            {
                return CNPJ;
            }
            else
            {
                Regex regex = new Regex(@"\d{2}\d{3}\d{3}\d{4}\d{2}");
                Match match = regex.Match(CNPJ);
                if (match.Success)
                {
                    return string.Format("{0}.{1}.{2}/{3}-{4}",
                        match.Groups[1],
                        match.Groups[2],
                        match.Groups[3],
                        match.Groups[4],
                        match.Groups[5]);
                }
                else
                {
                    return CNPJ;
                }
            }
        }

        public static string RemoveFormatoCNPJ(string CNPJ)
        {
            if (string.IsNullOrEmpty(CNPJ))
            {
                return CNPJ;
            }
            else
            {
                return Regex.Replace(CNPJ, @"\.|\/|\-", string.Empty);
            }
        }
        #endregion

        #region CPF
        public static string FormataCPF(string CPF)
        {
            if (string.IsNullOrEmpty(CPF))
            {
                return CPF;
            }
            else
            {
                Regex regex = new Regex(@"\d{3}\d{3}\d{3}\d{2}");
                Match match = regex.Match(CPF);
                if (match.Success)
                {
                    return string.Format("{0}.{1}.{2}-{3}",
                        match.Groups[1],
                        match.Groups[2],
                        match.Groups[3],
                        match.Groups[4]);
                }
                else
                {
                    return CPF;
                }
            }
        }

        public static string RemoveFormatoCPF(string CPF)
        {
            if (string.IsNullOrEmpty(CPF))
            {
                return CPF;
            }
            else
            {
                return Regex.Replace(CPF, @"\.|\-", string.Empty);
            }
        }
        #endregion

        #region CEP
        public static string FormataCEP(string CEP)
        {
            if (string.IsNullOrEmpty(CEP))
            {
                return CEP;
            }
            else
            {
                Regex regex = new Regex(@"\d{5}\d{3}");
                Match match = regex.Match(CEP);
                if (match.Success)
                {
                    return string.Format("{0}-{1}",
                        match.Groups[1],
                        match.Groups[2]);
                }
                else
                {
                    return CEP;
                }
            }
        }

        public static string RemoveFormatCEP(string CEP)
        {
            if (string.IsNullOrEmpty(CEP))
            {
                return CEP;
            }
            else
            {
                return Regex.Replace(CEP, @"\-", string.Empty);
            }
        }
        #endregion

        public static string RemoveFormatoTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                return telefone;
            }
            else
            {
                return Regex.Replace(telefone, @"\(|\)|\-|\s", string.Empty);
            }
        }
    }
}
