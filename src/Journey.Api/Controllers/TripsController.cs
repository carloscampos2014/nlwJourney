using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Application.UseCases.Trips.Update;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Journey.Api.Controllers;
[Route("V1/api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly IRegisterTripUseCase _registerTripUseCase;
    private readonly IGetAllTripUseCase _getAllTripUseCase;
    private readonly IGetByIdTripUseCase _getByIdTripUseCase;
    private readonly IDeleteTripUseCase _deleteTripUseCase;
    private readonly IUpdateTripUseCase _updateTripUseCase;

    public TripsController(
        IRegisterTripUseCase registerTripUseCase,
        IGetAllTripUseCase getAllTripUseCase,
        IGetByIdTripUseCase getByIdTripUseCase,
        IDeleteTripUseCase deleteTripUseCase,
        IUpdateTripUseCase updateTripUseCase)
    {
        _registerTripUseCase = registerTripUseCase;
        _getAllTripUseCase = getAllTripUseCase;
        _getByIdTripUseCase = getByIdTripUseCase;
        _deleteTripUseCase = deleteTripUseCase;
        _updateTripUseCase = updateTripUseCase;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripsJson), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _getAllTripUseCase.ExecuteAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await _getByIdTripUseCase.ExecuteAsync(id);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseTripJson), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Register([FromBody] RequestRegisterTripJson request)
    {
        var response = await _registerTripUseCase.ExecuteAsync(request);
        return Created("api/Trips", response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _deleteTripUseCase.ExecuteAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorResponseJson), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] RequestRegisterTripJson request)
    {
        var response = await _updateTripUseCase.ExecuteAsync(id, request);
        return Ok(response);
    }
}
