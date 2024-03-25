using WebApplication1.Logic.Interfaces;
using WebApplication1.Logic.Processors;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string baseURl = builder.Configuration.GetSection("BaseUrl").Get<string>();
builder.Services.AddSingleton<ITypecodeClient, TypecodeClient>(t => new TypecodeClient(baseURl));
builder.Services.AddSingleton<DataProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



