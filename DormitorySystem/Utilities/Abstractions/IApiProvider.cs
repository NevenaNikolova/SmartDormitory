namespace Utilities.Abstractions
{
    public interface IApiProvider
    {
        string ReturnRespons(string url, string header);
    }
}