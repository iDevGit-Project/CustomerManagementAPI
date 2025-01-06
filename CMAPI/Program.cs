using CMAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// در این مکان جهت ارتباط رشته اتصال به بانک اطلاعاتی و دیگر تنظیمات appsettings.json شناسایی فایل جیسون مربوط به 
var configuration = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(FileNamesExtentions.AppSettingName).Build();
// MS SQL Server سرویس تنظیمات مربوط به اتصال رشته مربوط به پایگاه داده در 

builder.Services.AddControllers();

//Services DataBase
builder.Services.AddDbContextService(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service Add Policy for Error handler API
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificationOrigins",
        builder =>
        {
            //builder.WithOrigins("https://localhost:7177", "https://webnext.ir");
            builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed((host) => true);
        });
});

// آن ها را بررسی می کنند ApiController تغییر دادن رفتارهای کنترلر در زمانی که عبارت 
// مراجعه و خطا را بررسی کند Action Controller یعنی اگر زمانی در یکی از کنترلر ها خطایی رخ داد، مستقیم به خود 
builder.Services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("_myAllowSpecificationOrigins");

//1 احراز هویت
app.UseAuthentication();

//2 مجوزهای دسترسی
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
