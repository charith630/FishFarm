using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Farm
    {
        public Farm()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfCages { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public bool IsBargeExist { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
