namespace VehicleManager.Exceptions.ExceptionsBase;

public class ErrorValidationException : VehicleManagerException
{
    public IList<string> ErrorMessages { get; set;  }
    
    public ErrorValidationException(IList<string> errors)
    {
        ErrorMessages = errors;
    }
}