using System.ComponentModel.DataAnnotations;
namespace Erick_Estrada_Rosario_P1_AP1.Models;

public class Aportes
{
    [Key]
    public int AporteId   { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    public string NombrePersona { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [MaxLength(250)]
    public string Observacion { get; set; }
    
    [Required (ErrorMessage = "Este campo es requerido")]
    [Range(0,int.MaxValue)]
    public double Monto { get; set; }
    
    [Required]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

}

