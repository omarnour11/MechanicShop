namespace MyMechanicShop.Domain.Common.Results.Abstraction;


// the shape of my errors
public interface IResult
{
    List<Error>? Errors {get;}

    bool IsSuccess {get;}
}
public interface IResult<out TValue> : IResult
{
    TValue Value {get;}

}