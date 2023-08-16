namespace NestData.Core.Common;

public static class TaskExtensions
{
    public static Task<T> WrapTask<T>(this T obj)
    {
        return Task.FromResult<T>(obj);
    } 
}