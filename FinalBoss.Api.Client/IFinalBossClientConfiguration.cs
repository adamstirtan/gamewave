namespace FinalBoss.Api.Client
{
    public interface IFinalBossClientConfiguration
    {
        string BaseUrl { get; set; }

        string ApiToken { get; set; }
    }
}