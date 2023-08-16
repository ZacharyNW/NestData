namespace NestData.Core.Structs;

public class Response
{
    public List<Error> Errors { get; } = new List<Error>();
    public bool HasErrors => Errors.Any();
    public static Response Success = new Response();

    public void AddError(Error error) =>
        Errors.Add(error);

    public void AddErrors(List<Error> errors) => errors.ForEach(AddError);
}

public class Response<T> : Response
{
    public T Data { get; set; }
}

public class Error
{
    public Error(string property, string message)
    {
        Property = property;
        Message = message;
    }
    
    public string Property { get; set; }
    public string Message { get; set; }
}

