using HandlingDomainExceptionsExplicitly;

// How we use get results
Customer customer = new();
var registerCustomer = customer.RegisterCustomer();

// get left value
var exception = registerCustomer.RightOrDefault();
if (exception is not null)
{
    // log exception or add exception list
}

// get right value
var value = registerCustomer.LeftOrDefault();
if (value is not null)
{
    // Do Something
}

// use Match
registerCustomer.Match(
    result => $"this is result {result}",
    exception => $"this is exception {exception.Message}"
);


// using Doright() action
registerCustomer.DoRight((exception) => throw exception);


public class Customer
{
    // How we use either in a method
    public Either<int?, Exception> RegisterCustomer()
    {
        try
        {
            /*Do Something*/
            return new Either<int?, Exception>(1);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return new Either<int?, Exception>(exception);
        }
    }
}