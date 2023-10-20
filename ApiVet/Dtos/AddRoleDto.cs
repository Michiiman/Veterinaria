using System.ComponentModel.DataAnnotations;

namespace ApiVet.Dtos;
public class AddRoleDto
{
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
}
