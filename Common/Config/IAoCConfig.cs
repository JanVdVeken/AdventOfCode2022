namespace Common.Config
{
    public interface IAoCConfig
    {
        string BaseAPIUrl { get; set; }
        string SessionKey { get; set; }
    }
}