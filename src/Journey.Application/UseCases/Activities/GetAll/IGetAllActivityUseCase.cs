using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Activities.GetAll;
public interface IGetAllActivityUseCase
{
    Task<ResponseActivitiesJson> ExecuteAsync();
}
