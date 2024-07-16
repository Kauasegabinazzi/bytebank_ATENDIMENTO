using bytebank.Modelos.ADM.SistemaInterno;
using byteBank_Modelos.bytebank.Modelos.ADM.Utilitario;

namespace bytebank.Modelos.ADM.Utilitario
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }
        private AutenticacaoUtil Autentificador = new AutenticacaoUtil();
        public bool Autenticar(string senha)
        {
            return this.Autentificador.validarSenha(this.Senha, senha);
        }

    }
}
