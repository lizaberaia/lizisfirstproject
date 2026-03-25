using lizi_s_project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ProductService>();
//თუ აქ addsingletonის ნაცვლად addscopedს გამოვიძახებთ, ყველა ჯერზე ახალი რენდომ ობჯექთი შეიქმნება
//თუ AddTransientს გამოვიძახებთ, ყველა ობჯექთძე სექმნის ახალს და ყველა იქნება განსხვავებული რენდომ რიცხვი
 //AddScoped არის ისეთ მეთოდი, რომელიც ხელახლა შექმნის ობჯექთს
//ADDSingleTon არის ისეთ მეთოდი, როცა ობჯექთი შეიქმნეა მხოლოდ ერთელ, სანამ არ გავთიშავთ
//AddTransient არის ისეთ მეთოდი, რომელიც შექმნის ახალ ობჯექთს იმდენჯერ, რამდენჯერაც გამოიყენება ეს სერვისი 

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
