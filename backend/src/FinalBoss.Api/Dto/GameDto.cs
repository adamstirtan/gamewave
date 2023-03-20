namespace FinalBoss.Api.Dto
{
    public class GameDto : BaseDto
    {
        public long? Id { get; set; }

        public long DeveloperId { get; set; }

        public long PublisherId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}