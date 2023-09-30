using ShapeGeneratorAPI.Shapes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shapes need to register the services for dependency injection, new instance created every request
builder.Services.AddScoped<IsoscelesTriangle>();
builder.Services.AddScoped<ScaleneTriangle>();
builder.Services.AddScoped<EquilateralTriangle>();
builder.Services.AddScoped<Rectangle>();
builder.Services.AddScoped<Square>();
builder.Services.AddScoped<Parallelogram>();
builder.Services.AddScoped<Pentagon>();
builder.Services.AddScoped<Hexagon>();
builder.Services.AddScoped<Heptagon>();
builder.Services.AddScoped<Octagon>();
builder.Services.AddScoped<Circle>();

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
