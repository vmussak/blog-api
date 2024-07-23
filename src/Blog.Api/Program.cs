using Blog.Api.Configuration.Monitoring;
using Blog.Api.Middlewares;
using Blog.Api.Configuration.DependencyInjection;
using Blog.Worker.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiMonitoring();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBlogSqlServer(builder.Configuration);
builder.Services.AddBlogRabbitMq(builder.Configuration);
builder.Services.AddBlogMongoDb(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddValidators();
builder.Services.AddUseCases();

builder.Services.AddHostedService<BlogPostCreatedService>();
builder.Services.AddHostedService<NewCommentService>();

var app = builder.Build();

app.Services.ConfigureSqlServer();

app.UseCors(op =>
{
    op.AllowAnyOrigin();
    op.AllowAnyMethod();
    op.AllowAnyHeader();
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();
app.MapCustomHealthChecks();

app.Run();
