namespace WestcoastEducationAdminApp.ViewModels.AppUsers;

public class CreateAppUserViewModel
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int AddressId { get; set; }
    public string? RoleName { get; set; }
}