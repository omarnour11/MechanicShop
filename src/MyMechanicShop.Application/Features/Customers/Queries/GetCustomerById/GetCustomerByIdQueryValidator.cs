using FluentValidation;

namespace MyMechanicShop.Application.Features.Customers.Queries.GetCustomerById;



public sealed class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(request => request.Id).NotEmpty()
                          .WithErrorCode("CustomerId_Is_Required")
                          .WithMessage("CustomerId is required.");

    }
}