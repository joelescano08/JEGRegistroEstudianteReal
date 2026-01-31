using JEGRegistroEstudiante.Models;
using JEGRegistroEstudiante.DAL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace JEGRegistroEstudiante.Services
{
    public class TiposPuntosService(IDbContextFactory<ContextoRegistroEstudiantes> DbFactory)
    {
        private async Task<bool> Existe(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.TiposPuntos.AnyAsync(tp => tp.TipoId == tipoId);
        }

        private async Task<bool> Insertar(TiposPuntos tipoPunto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.TiposPuntos.Add(tipoPunto);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(TiposPuntos tipoPunto)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.TiposPuntos.Update(tipoPunto);

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TiposPuntos tipoPunto)
        {
            if (!await Existe(tipoPunto.TipoId))
            {
                return await Insertar(tipoPunto);
            }
            else
            {
                return await Modificar(tipoPunto);
            }
        }

        public async Task<TiposPuntos?> Buscar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.TiposPuntos
                .FirstOrDefaultAsync(tp => tp.TipoId == tipoId);
        }

        public async Task<bool> Eliminar(int tipoId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.TiposPuntos
                .AsNoTracking()
                .Where(tp => tp.TipoId == tipoId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.TiposPuntos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
