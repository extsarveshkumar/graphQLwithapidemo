public interface ICustomerProvider{
    Customer[] GetCustomers();
}

public class CustomerProvider : ICustomerProvider{
    private readonly ICustomerAccess dataAccess;

    public CustomerProvider(ICustomerAccess dataAccess){
        this.dataAccess = dataAccess;
    }
    public Customer[] GetCustomers() => dataAccess.Get().ToArray();
}