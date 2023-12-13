using MediatR;
using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterEndpoints();

app.Run();
