using FluentValidation;
using FluentValidation.Results;
using Journey.Communication.Requests;
using Journey.Exceptions;

namespace Journey.Application.UseCases.Trips.Validators;
public class RequestRegisterTripJsonValidator : AbstractValidator<RequestRegisterTripJson>
{
    public RequestRegisterTripJsonValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage(ErrorMessages.NameEmpty)
            .Length(4, 100).WithMessage(ErrorMessages.NameLegth);

        RuleFor(r => r.StartDate.Date)
            .Configure(c => c.PropertyName = "StartDate")
            .GreaterThan(DateTime.UtcNow.Date).WithMessage(ErrorMessages.StartDateGreaterThanNow)
            .LessThanOrEqualTo(r => r.EndDate.Date).WithMessage(ErrorMessages.StartDateLessThanOrEqualToEndDate);

        RuleFor(r => r.EndDate.Date)
            .Configure(c => c.PropertyName= "EndDate")
            .GreaterThan(DateTime.UtcNow.Date).WithMessage(ErrorMessages.EndDateGreaterThanNow)
            .GreaterThanOrEqualTo(r => r.StartDate.Date).WithMessage(ErrorMessages.EndDateLessThanOrEqualToStartDate);
    }

    public override ValidationResult Validate(ValidationContext<RequestRegisterTripJson> context)
    {
        if (context is null || context.InstanceToValidate is null)
        {
            return new ValidationResult(new List<ValidationFailure> { 
                new ValidationFailure(
                    string.Format(ErrorMessages.RequestRegisterNullExeption, "Trip"), 
                    string.Format(ErrorMessages.RequestRegisterNullExeptionMessage), "viagem") });
        }

        return base.Validate(context);
    }
}
