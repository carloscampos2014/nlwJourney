using FluentAssertions;
using FluentValidation.Results;
using Journey.Application.UseCases.Trips.Validators;
using Journey.Communication.Requests;
using Journey.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Test.UseCases.Trips.Validators;
public class RequestRegisterTripJsonValidatorTest
{
    [Fact]
    public void NaoDeveserUmObjetoRequestTripsJsonNulo()
    {
        //Arrange
        RequestRegisterTripJson request = null;
        var validator = new RequestRegisterTripJsonValidator();
        var expected = new ValidationFailure(ErrorMessages.RequestRegisterNullExeption, ErrorMessages.RequestRegisterNullExeptionMessage);

        //Act
        var actual = validator.Validate(request);

        //Asserts
        actual.IsValid.Should().BeFalse();
        actual.Errors.Should().NotBeEmpty();
        actual.Errors.FirstOrDefault().Should().NotBeNull();
        actual.Errors.FirstOrDefault().Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void DeveSerumObjetoRequestRegisterTripsJsonValido()
    {
        //Arrange
        RequestRegisterTripJson request = new RequestRegisterTripJson()
        {
            Name = "Ilha dos Paratontos",
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2),
        };
        var validator = new RequestRegisterTripJsonValidator();

        //Act
        var actual = validator.Validate(request);

        //Asserts
        actual.IsValid.Should().BeTrue();
        actual.Errors.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(Validations))]
    public void DeveRetornarErrosdeValidacao(
        string name, 
        DateTime startDate,
        DateTime endDate,
        IEnumerable<ValidationFailure> expected)
    {
        //Arrange
        var request = new RequestRegisterTripJson()
        {
            Name = name,
            StartDate = startDate,
            EndDate = endDate,
        };
        var validator = new RequestRegisterTripJsonValidator();

        //Act
        var actual = validator.Validate(request);

        //Asserts
        actual.IsValid.Should().BeFalse();
        actual.Errors.Should().NotBeEmpty();
        actual.Errors.Count.Should().Be(expected.Count());
        foreach (var expectedError in expected)
        {
            var matchingError = actual.Errors.SingleOrDefault(e => e.PropertyName == expectedError.PropertyName && e.ErrorMessage == expectedError.ErrorMessage);
            matchingError.Should().NotBeNull();
        }
    }

    public static IEnumerable<Object[]> Validations()
    {
        var nameEmpty = new ValidationFailure("Name", ErrorMessages.NameEmpty);
        var nameLegth = new ValidationFailure("Name", ErrorMessages.NameLegth);
        var startDateGreaterNow = new ValidationFailure("StartDate", ErrorMessages.StartDateGreaterThanNow);
        var startDateLessEndDate = new ValidationFailure("StartDate", ErrorMessages.StartDateLessThanOrEqualToEndDate);
        var endDateGreaterNow = new ValidationFailure("EndDate", ErrorMessages.EndDateGreaterThanNow);
        var endDateGreaterStartDate = new ValidationFailure("EndDate", ErrorMessages.EndDateLessThanOrEqualToStartDate);

        yield return new object[] { string.Empty, DateTime.MinValue, DateTime.MinValue, new[] {nameEmpty, nameLegth, startDateGreaterNow, endDateGreaterNow } };
        yield return new object[] { "a", DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2), new[] { nameLegth } };
        yield return new object[] { "Ilha de Papajudas", DateTime.UtcNow.AddDays(3), DateTime.UtcNow.AddDays(2), new[] { startDateLessEndDate, endDateGreaterStartDate } };
    }
}
