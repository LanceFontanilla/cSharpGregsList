using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services;

public class HousesService
{
    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
        _repo = repo;
    }

    internal House CreateHouse(House houseData)
    {
        House house = _repo.CreateHouse(houseData);
        return house;
    }

    internal List<House> GetAllHouses()
    {
        List<House> houses = _repo.GetAllHouses();
        return houses;
    }

    internal House GetHouseById(int houseId)
    {
        House house = _repo.GetHouseById(houseId);
        if (house == null) throw new Exception($"no house with id: {houseId}");
        return house;
    }

    internal string RemoveHouse(int houseId)
    {
        House house = this.GetHouseById(houseId);

        _repo.RemoveHouse(houseId);
        return $"this {house.SqFt} house was removed from the database";
    }

    internal House UpdateHouse(House updateData)
    {
        House original = this.GetHouseById(updateData.Id);

        original.SqFt = updateData.SqFt != 0 ? updateData.SqFt : original.SqFt;
        original.Bedrooms = updateData.Bedrooms != 0 ? updateData.Bedrooms : original.Bedrooms;
        original.Bathrooms = updateData.Bathrooms != 0 ? updateData.Bathrooms : original.Bathrooms;
        original.ImgUrl = updateData.ImgUrl != null ? updateData.ImgUrl : original.ImgUrl;
        original.Description = updateData.Description != null ? updateData.Description : original.Description;
        original.Price = updateData.Price != 0 ? updateData.Price : original.Price;

        House house = _repo.UpdateHouse(original);
        return house;

    }
}
