using ShapeGeneratorAPI.Interface;
using ShapeGeneratorAPI.Shapes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shapes need to register the services for dependency injection, new instance created every request
builder.Services.AddScoped<IIsoscelesTriangle, IsoscelesTriangle>();
builder.Services.AddScoped<IScaleneTriangle, ScaleneTriangle>();
builder.Services.AddScoped<IEquilateralTriangle, EquilateralTriangle>();
builder.Services.AddScoped<IRectangle, Rectangle>();
builder.Services.AddScoped<ISquare, Square>();
builder.Services.AddScoped<IParallelogram, Parallelogram>();
builder.Services.AddScoped<IPentagon, Pentagon>();
builder.Services.AddScoped<IHexagon, Hexagon>();
builder.Services.AddScoped<IHeptagon, Heptagon>();
builder.Services.AddScoped<IOctagon, Octagon>();
builder.Services.AddScoped<ICircle, Circle>();

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
