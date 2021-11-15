namespace DbDesigner.Models
{
    public class DbDesign
    {
        public long DbDesignId { get; set; }
        public long AppUserId { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseType { get; set; }
        public string DbDesignJson { get; set; }
    }
}
