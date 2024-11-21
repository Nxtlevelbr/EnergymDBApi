using EnergymDBApi.Data;
using EnergymDBApi.Repositories;
using EnergymDBApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Carregar a string de conexão do appsettings.json
string connectionString = builder.Configuration.GetConnectionString("OracleDb");

// Adicionar serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "EnergymDBApi",
        Version = "v1",
        Description = "API para gerenciamento de academias, usuários, exercícios e outras operações relacionadas",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Equipe EnergymDBApi",
            Email = "suporte@energymdbapi.com",
            Url = new Uri("https://www.energymdbapi.com")
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();
});

// Registro de dependências
builder.Services.AddSingleton(new OracleDbContext(connectionString));
builder.Services.AddScoped<AcademiaRepository>();
builder.Services.AddScoped<BairroRepository>();
builder.Services.AddScoped<CidadeRepository>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<EstadoRepository>();
builder.Services.AddScoped<ExercicioRepository>();
builder.Services.AddScoped<PaisRepository>();
builder.Services.AddScoped<PremioRepository>();
builder.Services.AddScoped<ResgateRepository>();
builder.Services.AddScoped<TipoPessoaRepository>();
builder.Services.AddScoped<TipoPremioRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuariosRepository>();

var app = builder.Build();

// Configuração do pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnergymDBApi v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
