using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byteBank_Modelos.bytebank.Modelos.ADM.Utilitario
{
    public class AutenticacaoUtil
    {
        public bool validarSenha(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaVerdadeira.Equals(senhaTentativa);
        }
    }
}
