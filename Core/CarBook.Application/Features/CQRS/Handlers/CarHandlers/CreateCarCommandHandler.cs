﻿using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers;
public class CreateCarCommandHandler
{
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateCarCommand command)
    {
        await _repository.CreateAsync(new Car
        {
            BrandID = command.BrandID,
            BigImageUrl = command.BigImageUrl,
            CoverImageUrl = command.CoverImageUrl,
            Fuel = command.Fuel,
            Km = command.Km,
            Luggage = command.Luggage,
            Model = command.Model,
            Seat = command.Seat,
            Transmission = command.Transmission,
        });
    }
}
