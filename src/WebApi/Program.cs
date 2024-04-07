using Application;
using Persistence;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence();
builder.Services.AddPresentation();

var app = builder.Build();

app.AddRestApi();

app.Run();
