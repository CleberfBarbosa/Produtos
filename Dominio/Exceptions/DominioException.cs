namespace Dominio.Exceptions
{
    public class DominioException : Exception
    {
        public DominioException(string message) : base(message)
        {
        }

        public static void ThrowWhen(bool condicao, string mensagem = "Domínio inválido!")
        {
            if (condicao)
                throw new DominioException(mensagem);
        }
    }
}
