using JEGRegistroEstudiante.Components;
using JEGRegistroEstudiante.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using JEGRegistroEstudiante.Services;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();


        //Nota mental(no tan mental): asi se crea el ConStr para usarlo en el contexto
        var ConStr = builder.Configuration.GetConnectionString("SqlConStr");


        //agregando contexto al builderrr

        builder.Services.AddDbContextFactory<ContextoRegistroEstudiantes>(options => options.UseSqlServer(ConStr));

        /*Aqui estoy inyectando el service xd
            bien facilito
        */


        builder.Services.AddScoped<EstudiantesService>();
        builder.Services.AddScoped<AsignaturasService>();
        builder.Services.AddScoped<TiposPuntosService>();






        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}