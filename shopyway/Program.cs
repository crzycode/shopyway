using Microsoft.EntityFrameworkCore;
using shopyway.Context;
using shopyway.Implements;
using shopyway.Interface;

using shopyway.Model.Topdeals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("mypolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});
builder.Services.AddDbContext<DataContext>(options =>
{
options.UseSqlServer($"{Connection.connection}");
});
builder.Services.AddTransient<IUser_Register, User_Register>();
builder.Services.AddTransient<ITop_deals, Top_deals_>();
builder.Services.AddTransient<ITopElec_products, TopElec_products_>();
builder.Services.AddTransient<ITop_category, top_category>();
builder.Services.AddTransient<ITop_fashion_category, Top_fashion_category>();
builder.Services.AddTransient<IGet_fashion_product, Get_fashion_products>();
builder.Services.AddTransient<Isearch, Search>();
builder.Services.AddTransient<IMen_section, Men_section_>();
builder.Services.AddTransient<IWomen_section, Women_section_>();
builder.Services.AddTransient<IMobile_laptop_category_product, Mobile_laptops_product_category>();
builder.Services.AddTransient<IElectronic_category_product, Electronic_product_category_>();
builder.Services.AddTransient<ICart, Cart_>();
builder.Services.AddTransient<IDetails, Details>();
builder.Services.AddTransient<IPartner, partner_account>();
builder.Services.AddTransient<IGet_partner_data, Get_partner_data_>();
builder.Services.AddTransient<IBulk_add_to_cart, Bulk_cart>();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("mypolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
