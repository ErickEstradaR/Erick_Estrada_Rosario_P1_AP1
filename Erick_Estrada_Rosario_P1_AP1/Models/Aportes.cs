using System.ComponentModel.DataAnnotations;
using Erick_Estrada_Rosario_P1_AP1.Components.Pages;

namespace Erick_Estrada_Rosario_P1_AP1.Models;

public class Aportes
{
    [Key]
    public int AporteId   { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [MinLength(3, ErrorMessage = "Debe tener al menos 3 caracteres")]
    [MaxLength(50,ErrorMessage = "El limite de caracteres es 50")]
    public string NombrePersona { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [MaxLength(250,ErrorMessage = "El limite de Caracteres es 250")]
    public string Observacion { get; set; } = string.Empty;
    
    [Required (ErrorMessage = "Este campo es requerido")]
    [Range(1,double.MaxValue,ErrorMessage = "Valor incorrecto.")]
    public double Monto { get; set; }
    
    [Required]
    public DateTime FechaRegistro { get; set; } = DateTime.Now.Date;

}

