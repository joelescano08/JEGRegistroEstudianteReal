using JEGRegistroEstudiante.Models;
using JEGRegistroEstudiante.DAL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace JEGRegistroEstudiante.Services
{
    public class AsignaturasService(IDbContextFactory<ContextoRegistroEstudiantes> DbFactory)
    {
        private async Task<bool> Existe(int asignaturaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(a => a.AsignaturaId == asignaturaId);
        }

        private async Task<bool> ExisteNombre(string nombre)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(a => a.Nombre == nombre);
        }

        private async Task<bool> Insertar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            if (await ExisteNombre(asignatura.Nombre))
                return false;

            contexto.Asignaturas.Add(asignatura);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Asignaturas.Update(asignatura);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Asignaturas asignatura)
        {
            if (!await Existe(asignatura.AsignaturaId))
                return await Insertar(asignatura);
            else
                return await Modificar(asignatura);
        }

        public async Task<Asignaturas?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.FirstOrDefaultAsync(a => a.AsignaturaId == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas
                .AsNoTracking()
                .Where(a => a.AsignaturaId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Asignaturas>> Listar(Expression<Func<Asignaturas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
