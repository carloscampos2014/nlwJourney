using Journey.Application.UseCases.Activities.Delete;
using Journey.Application.UseCases.Activities.GetAll;
using Journey.Application.UseCases.Activities.GetAllByTrip;
using Journey.Application.UseCases.Activities.GetById;
using Journey.Application.UseCases.Activities.Register;
using Journey.Application.UseCases.Activities.Update;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Journey.Api.Controllers;
[Route("V1/api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IRegisterActivityUseCase _registerActivityUseCase;
    private readonly IGetAllActivityUseCase _getAllActivityUseCase;
    private readonly IGetAllByTripActivityUseCase _getAllByTripActivityUseCase;
    private readonly IGetByIdActivityUseCase _getByIdActivityUseCase;
    private readonly IDeleteActivityUseCase _deleteActivityUseCase;
    private readonly IUpdateActivityUseCase _updateActivityUseCase;

    public ActivitiesController(IRegisterActivityUseCase registerActivityUseCase,
        IGetAllActivityUseCase getAllActivityUseCase,
        IGetAllByTripActivityUseCase getAllByTripActivityUseCase,
        IGetByIdActivityUseCase getByIdActivityUseCase,
        IDeleteActivityUseCase deleteActivityUseCase,
        IUpdateActivityUseCase updateActivityUseCase)
    {
        _registerActivityUseCase = registerActivityUseCase;
        _getAllActivityUseCase = getAllActivityUseCase;
        _getAllByTripActivityUseCase = getAllByTripActivityUseCase;
        _getByIdActivityUseCase = getByIdActivityUseCase;
        _deleteActivityUseCase = deleteActivityUseCase;
        _updateActivityUseCase = updateActivityUseCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseActivitiesJson), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getAllActivityUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("{tripId}/activities")]
    [ProducesResponseType(typeof(ResponseActivitiesJson), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAllByTrip([FromRoute] Guid tripId)
    {
        var response = await _getAllByTripActivityUseCase.ExecuteAsync(tripId);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseActivityJson), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await _getByIdActivityUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPost("{tripId}")]
    [ProducesResponseType(typeof(ResponseActivityJson), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Register(
        [FromRoute] Guid tripId,
        [FromBody] RequestRegisterActivityJson request)
    {
        var response = await _registerActivityUseCase.ExecuteAsync(tripId, request);
        return Created("api/Activities", response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _deleteActivityUseCase.ExecuteAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseActivityJson), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] RequestRegisterActivityJson request)
    {
        var response = await _updateActivityUseCase.ExecuteAsync(id, request);
        return Ok(response);
    }
}
