using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Activities.GetById;
public interface IGetByIdActivityUseCase
{
    Task<ResponseActivityJson> ExecuteAsync(Guid id);
}
