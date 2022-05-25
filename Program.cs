global using GraphQL.Types;
global using GraphQL;


using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;

using graphqldemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductProvider, ProductProvider>();
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ProductQuery>();
builder.Services.AddSingleton<ISchema, ProductSchema>();

builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddSingleton<IProductCreator, ProductCreator>();
builder.Services.AddSingleton<ProductMutation>();
builder.Services.AddSingleton<ProductInput>();


//Customer
builder.Services.AddSingleton<ICustomerProvider, CustomerProvider>();
builder.Services.AddSingleton<CustomerGraphType>();
builder.Services.AddSingleton<CustomerQuery>();
builder.Services.AddSingleton<ISchema, CustomerSchema>();

builder.Services.AddSingleton<ICustomerAccess, CustomerDataAccess>();
builder.Services.AddSingleton<ICustomerCreator, CustomerCreator>();
builder.Services.AddSingleton<CustomerMutation>();
builder.Services.AddSingleton<CustomerInput>();


builder.Services.AddGraphQL(b => b
                .AddHttpMiddleware<ISchema>()
                .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSchema<ProductSchema>()
                .AddSchema<CustomerSchema>()
                .AddGraphTypes(typeof(CustomerSchema).Assembly)
                .AddGraphTypes(typeof(ProductSchema).Assembly));

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


app.UseGraphQL<ISchema>();
app.UseGraphQLPlayground();

app.Run();
