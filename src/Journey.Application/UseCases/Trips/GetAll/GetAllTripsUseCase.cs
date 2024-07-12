using Journey.Communication.Responses;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.GetAll;
public class GetAllTripsUseCase
{
    public ResponseTripsJson Execute(Guid id)
    {
        var dbContext = new JourneyDbContext();

        var trips = dbContext.Trips.ToList();

        return new ResponseTripsJson
        {
            Trips = trips.Select(trip => new ResponseShortTripJson
            {
                Id = trip.Id,
                EndDate = trip.EndDate,
                Name = trip.Name,
                StartDate = trip.StartDate
            }).ToList()
        };
    }

    public object Execute()
    {
        throw new NotImplementedException();
    }
}
