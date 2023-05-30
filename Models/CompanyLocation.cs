using SVA_TraineePortal.Models.DTO;
namespace SVA_TraineePortal.Models
{
    public class CompanyLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string? superSecret { get; set; } //example to show the use case of DTO's. (We don't want this to get outside of our API

        public CompanyLocation() { }

        public CompanyLocation(int id, string locationName, string? superSecret)
        {
            Id = id;
            LocationName = locationName;
            this.superSecret = superSecret;
        }

        public CompanyLocation(CompanyLocationDTO companyLocationDTO) 
        {
            Id = companyLocationDTO.Id;
            LocationName = companyLocationDTO.LocationName;
            superSecret = default;
        }

        public override string ToString()
        {
            return "Id: " + Id + ", LocationName: " + LocationName + ", Secret: " + superSecret;
        }
    }
}
