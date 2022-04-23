namespace Common.Request
{
    public class FarmRequest
    {
        public string Name { get; set; }
        public int NumberOfCages { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public bool IsBargeExist { get; set; }
    }
}
