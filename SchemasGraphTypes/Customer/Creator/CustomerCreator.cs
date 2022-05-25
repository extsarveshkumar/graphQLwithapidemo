public  interface ICustomerCreator{
    Customer Create(Customer customer);
}

public class CustomerCreator:ICustomerCreator{
    private readonly ICustomerAccess dataAccess;

    public CustomerCreator(ICustomerAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }
    public Customer Create(Customer customer){
        dataAccess.Create(customer);
        return customer;
    }
}