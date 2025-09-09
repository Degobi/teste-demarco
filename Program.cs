using Microsoft.Extensions.Options;
using MongoDB.Driver;
using teste_demarco.Infra;
using teste_demarco.Interfaces;
using teste_demarco.Services.Integracao;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DbConfig>(
    builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var config = sp.GetRequiredService<IOptions<DbConfig>>().Value;
    return new MongoClient(config.ConnectionString);
});

builder.Services.AddSingleton(sp =>
{
    var config = sp.GetRequiredService<IOptions<DbConfig>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(config.DatabaseName);
});


builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddCors();

#region INTEGRACAO =============
builder.Services.AddSingleton<IClienteService, ClienteService>();
#endregion

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
