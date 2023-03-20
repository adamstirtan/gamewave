namespace FinalBoss.Api.Dto
{
    public class CompanyDto : BaseDto
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}