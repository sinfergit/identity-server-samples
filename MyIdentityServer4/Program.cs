using IdentityServer4;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add identity server 
builder.Services.AddIdentityServer().AddDeveloperSigningCredential()
    .AddOperationalStore(options =>
    {
        options.EnableTokenCleanup = true;
        options.TokenCleanupInterval = 60;
    })
    .AddInMemoryClients(Config.GetClients())
    .AddInMemoryApiScopes(Config.GetAPIScopes());
    //.AddInMemoryApiResources(Config.GetApiResources());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseIdentityServer();

app.Run();