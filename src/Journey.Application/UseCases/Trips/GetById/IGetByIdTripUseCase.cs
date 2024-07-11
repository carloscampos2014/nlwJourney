using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.GetById;
public interface IGetByIdTripUseCase
{
    Task<ResponseTripJson> ExecuteAsync(Guid id);
}
