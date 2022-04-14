namespace Company.BLL.DataTransferObjects.CompanyDto
{
    public class CompanyForGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
