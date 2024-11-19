global using Ordering.Application;
global using Ordering.Infrastructure;
global using Ordering.Infrastructure.Data.Extentions;
global using Ordering.API;

global using Carter;
global using Mapster;
global using MediatR;
global using Ordering.Application.Dtos;
global using Ordering.Application.Orders.Commands.DeleteOrder;
global using Ordering.Application.Orders.Commands.CreateOrder;
global using Ordering.Application.Orders.Queries.GetOrdersByCustomer;
global using BuildingBlocks.Pagination;
global using Ordering.Application.Orders.Queries.GetOrderByName;
global using Ordering.Application.Orders.Queries.GetOrders;
global using BuildingBlocks.Exceptions.Handler;