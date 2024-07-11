using FluentValidation;
using FluentValidation.Results;
using Journey.Communication.Requests;
using Journey.Exceptions;

namespace Journey.Application.UseCases.Activities.Validators;
public class RequestRegisterActivityJsonValidator : AbstractValidator<RequestRegisterActivityJson>
{
    public RequestRegisterActivityJsonValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage(ErrorMessages.NameEmpty)
            .Length(4, 100).WithMessage(ErrorMessages.NameLegth);

        RuleFor(r => r.Status)
            .IsInEnum().WithMessage(ErrorMessages.StatusActivityMessage);

        RuleFor(r => r)
            .Configure(c => c.PropertyName = "Date")
            .Must(m => m.Date.Date >= m.StartDate.Date && m.Date.Date <= m.EndDate.Date)
                .WithMessage(ErrorMessages.DateActivityBeetwenTripDates);
    }

    public override ValidationResult Validate(ValidationContext<RequestRegisterActivityJson> context)
    {
        if (context is null || context.InstanceToValidate is null)
        {
            return new ValidationResult(new List<ValidationFailure> {
                new ValidationFailure(
                    string.Format(ErrorMessages.RequestRegisterNullExeption, "Activity"),
                    string.Format(ErrorMessages.RequestRegisterNullExeptionMessage, "atividade")) });
        }

        return base.Validate(context);
    }
}
