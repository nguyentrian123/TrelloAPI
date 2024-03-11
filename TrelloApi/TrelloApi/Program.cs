var builder = WebApplication.CreateBuilder(args);

    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("Properties\\launchSettings.json") // Đường dẫn tương đối của file launchSettings.json
        .Build();

// Lấy giá trị của biến từ cấu hình
string myVariable = configuration["profiles:TrelloApi:applicationUrl"];
Console.WriteLine(myVariable);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
