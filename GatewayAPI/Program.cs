using GatewayAPI.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddGrpcClient<Organization.OrganizationClient>(o =>
//{
//    o.Address = new Uri("http://localhost:5249");
//});
builder.Services.AddGrpcClient<Organization.OrganizationClient>(o =>
{
    o.Address = new Uri("http://localhost:5001");
}).ConfigureChannel(o =>
{
    o.HttpHandler = new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(5),
        EnableMultipleHttp2Connections = true
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
