using JEGRegistroEstudiante.Models;
using JEGRegistroEstudiante.DAL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace JEGRegistroEstudiante.Services

{
    public class EstudiantesService(IDbContextFactory<ContextoRegistroEstudiantes> DbFactory)
    {

        private async Task<bool> Existe(int estudianteID)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.Estudiantes.AnyAsync( estudiante => estudiante.EstudianteId == estudianteID );

        }

        private async Task<bool> Insertar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Add(estudiante);
            return await contexto.SaveChangesAsync() > 0;


        }

        private async Task<bool> Modificar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Update(estudiante);

            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Estudiantes estudiante)
        {
            if(!await Existe(estudiante.EstudianteId)){
                return await Insertar(estudiante);
            }
            else
            {
                return await Modificar(estudiante);
            }

        }
        
        
        
        public async Task<Estudiantes?> Buscar(int estudianteID)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.Estudiantes.FirstOrDefaultAsync(estudiante => estudiante.EstudianteId == estudianteID);

        }


        public async Task<bool> Eliminar(int estudianteID)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.Estudiantes.AsNoTracking().Where(estudiante => estudiante.EstudianteId == estudianteID).ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes, bool>> criterio){
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.Estudiantes.Where(criterio).AsNoTracking().ToListAsync();
        }





    }
}
