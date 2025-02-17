using Erick_Estrada_Rosario_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Erick_Estrada_Rosario_P1_AP1.DAL;

public class Contexto : DbContext
{
    public Contexto (DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Aportes> Aportes { get; set; }
}