using System.ComponentModel.DataAnnotations;
using Asp_net_core_mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Asp_net_core_mvc.Models
{
    public class Zoo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не встановлена назва")]
        public string Name { get; set; } = "none";
        [Required(ErrorMessage = "Не встановлена кількість робочих")]
        [Range(0, 100, ErrorMessage = "Кількість робочих повинна бути в діапазоні 0-100")]
        public int Workers_Ammount { get; set; }
        [Required(ErrorMessage = "Не встановлена кількість воль'єрів")]
        public int Aviary_Ammount { get; set; }

        public List<Ticket> Tickets { get; set; } = new();
    }


public static class ZooEndpoints
{
	public static void MapZooEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Zoo", async (Asp_net_core_mvcContext db) =>
        {
            return await db.Zoo.ToListAsync();
        })
        .WithName("GetAllZoos")
        .Produces<List<Zoo>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Zoo/{id}", async (int Id, Asp_net_core_mvcContext db) =>
        {
            return await db.Zoo.FindAsync(Id)
                is Zoo model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetZooById")
        .Produces<Zoo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Zoo/{id}", async (int Id, Zoo zoo, Asp_net_core_mvcContext db) =>
        {
            var foundModel = await db.Zoo.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(zoo);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateZoo")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Zoo/", async (Zoo zoo, Asp_net_core_mvcContext db) =>
        {
            db.Zoo.Add(zoo);
            await db.SaveChangesAsync();
            return Results.Created($"/Zoos/{zoo.Id}", zoo);
        })
        .WithName("CreateZoo")
        .Produces<Zoo>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Zoo/{id}", async (int Id, Asp_net_core_mvcContext db) =>
        {
            if (await db.Zoo.FindAsync(Id) is Zoo zoo)
            {
                db.Zoo.Remove(zoo);
                await db.SaveChangesAsync();
                return Results.Ok(zoo);
            }

            return Results.NotFound();
        })
        .WithName("DeleteZoo")
        .Produces<Zoo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
