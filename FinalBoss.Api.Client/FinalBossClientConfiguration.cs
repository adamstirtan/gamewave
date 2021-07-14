namespace FinalBoss.Api.Client
{
    public class FinalBossClientConfiguration : IFinalBossClientConfiguration
    {
        public string BaseUrl { get; set; }

        public string ApiToken { get; set; }
    }
}