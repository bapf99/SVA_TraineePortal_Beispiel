namespace SVA_TraineePortal.Models.DTO
{
    public class LocationDepartmentDTO
    {

        public int Id { get; set; }
        public int CompanyLocationId { get; set; }
        public string DepartmentName { get; set; }
        public string? Description { get; set; }

        public LocationDepartmentDTO() { }

        public LocationDepartmentDTO(int id, int companyLocationId, string departmentName, string? description)
        {
            Id = id;
            CompanyLocationId = companyLocationId;
            DepartmentName = departmentName;
            Description = description;
        }

        public LocationDepartmentDTO(LocationDepartment locationDepartment)
        {
            Id = locationDepartment.Id;
            CompanyLocationId = locationDepartment.CompanyLocationId;
            DepartmentName = locationDepartment.DepartmentName;
            Description = locationDepartment.Description;
        }
    }
}
