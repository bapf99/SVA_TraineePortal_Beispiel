namespace SVA_TraineePortal.Models.DTO
{
    public class CompanyLocationDTO
    {
        public int Id { get; set; }
        public string LocationName { get; set; }

        public CompanyLocationDTO() { }

        public CompanyLocationDTO(int id, string locationName)
        {
            Id = id;
            LocationName = locationName;
        }

        public CompanyLocationDTO(CompanyLocation companyLocation)
        {
            Id = companyLocation.Id;
            LocationName = companyLocation.LocationName;
        }
    }
}
