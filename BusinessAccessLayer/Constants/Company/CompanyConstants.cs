using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Constants.Company
{
    internal class CompanyConstants
    {
        //ID
        public const string ERROR_MESSAGE_INVALID_ID = "Idenficador da empresa inválido!";
        
        //NAME
        public const string ERROR_MESSAGE_EMPTY_NAME = "Nome não pode ser vazio!";
        public const string ERROR_MESSAGE_INVALID_FORMAT_NAME = "Formato do nome inválido!";
        public const string ERROR_MESSAGE_SMALL_NAME = "Nome não pode ter menos que 3 caracteres!";
        public const string ERROR_MESSAGE_LARGE_NAME = "Nome não pode ter mais que 50 caracteres!";

        //CNPJ
        public const string ERROR_MESSAGE_INVALID_CNPJ = "Formato do CNPJ inválido!";
        public const string ERROR_MESSAGE_EMPTY_CNPJ = "Preencha o CNPJ!";

        //UF
        public const string ERROR_MESSAGE_INVALID_UF = "Unidade Federal inválida!";


    }
}
