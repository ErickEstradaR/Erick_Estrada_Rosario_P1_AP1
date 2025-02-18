using System.ComponentModel.DataAnnotations;
using Erick_Estrada_Rosario_P1_AP1.Components.Pages;

namespace Erick_Estrada_Rosario_P1_AP1.Models;

public class Aportes
{
    [Key]
    public int AporteId   { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [MaxLength(50,ErrorMessage = "El limite de caracteres es 50")]
    public string NombrePersona { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [MaxLength(250,ErrorMessage = "El limite de Caracteres es 250")]
    public string Observacion { get; set; }
    
    [Required (ErrorMessage = "Este campo es requerido")]
    [Range(0,int.MaxValue,ErrorMessage = "Valor incorrecto.")]
    public double Monto { get; set; }
    
    [Required]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

}

