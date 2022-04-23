namespace Common.Response
{
    public class FishFarm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfCages { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public bool IsBargeExist { get; set; }
        public byte[] Picture { get; set; }
    }
}
