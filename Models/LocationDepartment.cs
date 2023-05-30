using SVA_TraineePortal.Models.DTO;

namespace SVA_TraineePortal.Models
{
    public class LocationDepartment
    {
        public int Id { get; set; }
        public int CompanyLocationId { get; set; }
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public string? secret { get; set; }

        public LocationDepartment() { }

        public LocationDepartment(int id, int companyLocationId, string departmentName, string? description)
        {
            Id = id;
            CompanyLocationId = companyLocationId;
            DepartmentName = departmentName;
            Description = description;
        }

        public LocationDepartment(LocationDepartmentDTO locationDepartmentDTO)
        {
            Id = locationDepartmentDTO.Id;
            CompanyLocationId = locationDepartmentDTO.CompanyLocationId;
            DepartmentName = locationDepartmentDTO.DepartmentName;
            Description = locationDepartmentDTO.Description;
        }

        public override string ToString()
        {
            return "Id: " + Id + ", DepartmentName: " + DepartmentName + ", Description: " + Description + ", Secret: " + (secret == null ? "null" : secret)  + ", CompanyLocationId: " + CompanyLocationId;
        }
    }
}
