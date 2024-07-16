using bytebank.Modelos.ADM.SistemaInterno;
using byteBank_Modelos.bytebank.Modelos.ADM.Utilitario;

namespace bytebank.Modelos.ADM.Utilitario
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }
        public AutenticacaoUtil Autentificador { get; set; }
        public bool Autenticar(string senha)
        {
            return this.Autentificador.validarSenha(this.Senha, senha);
        }

    }
}
