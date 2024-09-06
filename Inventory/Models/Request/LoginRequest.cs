using System.ComponentModel;

namespace Inventory.Models.Request
{
    public class LoginRequest
    {
        [DefaultValue("officialpapaidas@gmail.com")]
        public string? UserName { get; set; }
        [DefaultValue("123")]
        public string? Password { get; set; }
    }
}
