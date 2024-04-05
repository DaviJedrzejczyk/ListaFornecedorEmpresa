using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Constants.Supplier
{
    internal class SupplierConstants
    {
        //ID
        public const string ERROR_MESSAGE_INVALID_ID = "Idenficador do fornecedor inválido!";

        //NAME
        public const string ERROR_MESSAGE_EMPTY_NAME = "Nome não pode ser vazio!";
        public const string ERROR_MESSAGE_INVALID_FORMAT_NAME = "Formato do nome inválido!";
        public const string ERROR_MESSAGE_SMALL_NAME = "Nome não pode ter menos que 3 caracteres!";
        public const string ERROR_MESSAGE_LARGE_NAME = "Nome não pode ter mais que 50 caracteres!";

        //CPF | CNPJ
        public const string ERROR_MESSAGE_INVALID_CNPJ = "Formato do CNPJ inválido!";
        public const string ERROR_MESSAGE_EMPTY_CNPJ = "Preencha o CNPJ!";
        
        public const string ERROR_MESSAGE_CPF_AND_CNPJ_NOT_EMPTY = "Não é permitido preencher ambos os campos juntos, CNPJ e CPF!";

        public const string ERROR_MESSAGE_INVALID_CPF = "Formato do CPF inválido!";
        public const string ERROR_MESSAGE_EMPTY_CPF = "Preencha o CPF!";

        //PHONE NUMBER
        public const string ERROR_MESSAGE_INVALID_PHONE_NUMBER = "Formato do telefone inválido!";
        public const string ERROR_MESSAGE_EMPTY_PHONE_NUMBER = "Preencha o campo telefone!";

        //VALIDATE DATE
        public const string ERROR_MESSAGE_INVALID_AGE = "A pessoa física não pode ter menos de 18 anos para se cadastrar como fornecedor no Paraná!";

        //RG
        public const string ERROR_RG_EMPTY = "O RG é obrigatório quando o CPF está preenchido.";
        public const string ERROR_RG_AND_CNPJ_NOT_EMPTY = "O RG não pode ser preenchido se foi selecionado Pessoa Jurídica.";

        //COMMON
        public const string ERROR_CPF_AND_CNPJ_NOT_EMPTY = "Fornecedor não pode ser Pessoa Física e Jurídica ao mesmo tempo!";

    }
}
