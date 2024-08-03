namespace BarberBoss.Infraestructure.Exceptions
{
    public class ErrorOnValidatorException : BarberBossException
    {

        public readonly List<string> Errors;

        public ErrorOnValidatorException(List<string> errorMessges) 
        {
            Errors = errorMessges;
        }
    }
}
