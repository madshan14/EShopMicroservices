var builder = WebApplication.CreateBuilder(args);

// Add Services to the container

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();


builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

// Configure the HTTP Request Pipelines
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
