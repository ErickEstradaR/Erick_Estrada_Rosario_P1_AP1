using System.Linq.Expressions;
using Erick_Estrada_Rosario_P1_AP1.DAL;
using Erick_Estrada_Rosario_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;


namespace Erick_Estrada_Rosario_P1_AP1.Services;

public class AportesService (IDbContextFactory<Contexto> DbFactory)
{
    /// <summary>
    /// Este metodo guarda un aporte si no existe en la base de datos, si existe lo modifica
    /// </summary>
    /// <param name="aportes">Modelo Aporte</param>
    /// <returns>Retorna un booleano dependiendo de si fue exitoso o fallido</returns>
    public async Task<bool> Guardar(Aportes aportes)
    {
        if (!await Existe(aportes.AporteId))
        {
            return await Insertar(aportes);
        }
        else
        {
            return await  Modificar(aportes);
        }
    }
    
    /// <summary>
    /// Verifica si en la base de datos existe un aporte con el id pasado
    /// </summary>
    /// <param name="AporteId">dato de tipo entero que permite buscar un aporte</param>
    /// <returns>false si no existe y true si existe</returns>
     public async Task<bool> Existe(int AporteId)
     {
         await using var Contexto = await DbFactory.CreateDbContextAsync();
         return await Contexto.Aportes.AsNoTracking().AnyAsync(a => a.AporteId == AporteId);
     }
     
    /// <summary>
    /// Metodo que se utiliza en guardar, si el aporte no existe lo va a insertar en la base de datos.
    /// </summary>
    /// <param name="aportes">objeto de tipo aportes</param>
    /// <returns>True si inserta el aporte en la base de datos</returns>
    private async Task<bool> Insertar(Aportes aportes)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Aportes.Add(aportes);
        return await Contexto.SaveChangesAsync() > 0;
    }
    
    /// <summary>
    /// Modifica un aporte en la base de datos si este existe
    /// </summary>
    /// <param name="aportes">objeto de tipo aporte</param>
    /// <returns>true si es modificado y false si no es modificado</returns>
    private async Task<bool> Modificar(Aportes aportes)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Aportes.Update(aportes);
        return await Contexto.SaveChangesAsync() > 0;
    }
    
    /// <summary>
    /// Elimina un aporte 
    /// </summary>
    /// <param name="AporteId">Dato de tipo entero, Id del aporte</param>
    /// <returns>true si es eliminado y false si no es eliminado</returns>
    public async Task<bool> Eliminar(int AporteId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Aportes.Where(a => a.AporteId == AporteId).ExecuteDeleteAsync() > 0;
    }
    
    /// <summary>
    /// Busca un aporte en la base de datos
    /// </summary>
    /// <param name="AporteId">Dato de tipo entero que permite la busqueda</param>
    /// <returns>retorna un aporte si existe</returns>
    public async Task<Aportes?> Buscar(int AporteId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Aportes.AsNoTracking().FirstOrDefaultAsync(a => a.AporteId == AporteId);
    }

    /// <summary>
    /// Busca una lista de aportes segun un criterio
    /// </summary>
    /// <param name="criterio">acepta un criterio con el cual va a filtrar la lista de aportes</param>
    /// <returns>Retorna una lista de aportes</returns>
    public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>>criterio)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return Contexto.Aportes.AsNoTracking().Where(criterio).ToList();
    }
}