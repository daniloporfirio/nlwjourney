namespace Journey.Communication.Responses
{
    public class ResponseTripJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<ResponseActivityJson> responseActivities { get; set; } = [];
    }
}
