using NestData.Core.Structs;

namespace NestData.Core.Common;

public static class ResponseExtensions
{
    public static Response<T> AsResponse<T>(this T obj)
    {
        return new Response<T>
        {
            Data = obj,
        };
    }
}