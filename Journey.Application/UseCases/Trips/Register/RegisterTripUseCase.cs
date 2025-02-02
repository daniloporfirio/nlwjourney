﻿using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Infraestructure;
using Journey.Infraestructure.Entities;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public ResponseShortTripJson Execute(RequestRegisterTripJson request)
        {
            Validate(request);

            var dbContext = new JourneyDbContext();

            var entity = new Trip
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            dbContext.Trips.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortTripJson
            {
                Id = entity.Id,
                Name = entity.Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        private void Validate(RequestRegisterTripJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new JourneyException(ResourceErrorMessages.NAME_EMPTY);
           
            if (request.StartDate.Date < DateTime.Now.Date)
                throw new JourneyException(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);
            
            if (request.EndDate.Date < request.StartDate.Date)
                throw new JourneyException(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
        }
    }
}
