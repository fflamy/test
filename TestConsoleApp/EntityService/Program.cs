using EntityService.Data;


EntityRepository entityRepository = new EntityRepository();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddSingleton(entityRepository);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Urls.Add("http://::8088");
app.UseAuthorization();

app.MapControllers();

app.Run();
