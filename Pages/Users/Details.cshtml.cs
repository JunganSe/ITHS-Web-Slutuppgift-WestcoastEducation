using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestcoastEducationAdminApp.ViewModels.AppUsers;

namespace WestcoastEducationAdminApp.Pages.Users;

[BindProperties]
public class Details : PageModel
{
    private readonly IConfiguration _config;
    private readonly string _apiUrl;

    public AppUserViewModel? UserModel { get; set; }
    public List<string> RoleNames { get; set; } = new();

    public Details(IConfiguration config)
    {
        _config = config;
        _apiUrl = _config.GetValue<string>("ApiUrl");
    }

    public async Task OnGetAsync(string id)
    {
        var httpClient = new HttpClient();
        
        string userUrl = $"{_apiUrl}/AppUser/{id}";
        UserModel = await httpClient.GetFromJsonAsync<AppUserViewModel>(userUrl) ?? new AppUserViewModel();
        
        string rolesUrl = $"{_apiUrl}/AppUser/RoleNamesByAppUser/{id}";
        RoleNames = await httpClient.GetFromJsonAsync<List<string>>(rolesUrl) ?? new List<string>();
    }
}
