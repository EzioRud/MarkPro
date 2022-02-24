using MarkPro.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IHistoryService, HistoryService>(c =>
{
    c.BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:8181/api/v2");
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient<IGetUserService, GetUserService>(i =>
{
    i.BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/user/");
    i.DefaultRequestHeaders.Add("Accept", "application/json");
    i.DefaultRequestHeaders.Add("x-api-key", "MTY0MzA5MjU5Njk1NzIxYmRjZWZiLWIxYWMtNGI1NC1hYzAxLWFhYWJhZjZjOTE1MSk=");
});

builder.Services.AddHttpClient<IRequestService, RequestService>(i =>
{
    i.BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/request/");
    i.DefaultRequestHeaders.Add("Accept", "application/json");
    i.DefaultRequestHeaders.Add("x-api-key", "MTY0MzA5MjU5Njk1NzIxYmRjZWZiLWIxYWMtNGI1NC1hYzAxLWFhYWJhZjZjOTE1MSk=");
});

builder.Services.AddHttpClient<ITotalRequestService, TotalRequestService>(i =>
{
    i.BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/request/count");
    i.DefaultRequestHeaders.Add("Accept", "application/json");
    i.DefaultRequestHeaders.Add("x-api-key", "MTY0MzA5MjU5Njk1NzIxYmRjZWZiLWIxYWMtNGI1NC1hYzAxLWFhYWJhZjZjOTE1MSk=");
});

//
builder.Services.AddHttpClient<IAllUserRequestsService, AllUserRequestsService>(i =>
{
    i.BaseAddress = new Uri("http://8fde09ad22a2.sn.mynetname.net:5055/api/v1/user/{userId}/request/");
    i.DefaultRequestHeaders.Add("Accept", "application/json");
    i.DefaultRequestHeaders.Add("x-api-key", "MTY0MzA5MjU5Njk1NzIxYmRjZWZiLWIxYWMtNGI1NC1hYzAxLWFhYWJhZjZjOTE1MSk=");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
