public interface ICustomerAccess
{
    void Create(Customer customer);
    IList<Customer> Get();
}
public class CustomerDataAccess: ICustomerAccess
{
    private readonly List<Customer> customers = new List<Customer>
    {
        new Customer(1,"Naresh","Adepu","naresh.adepu@pac",new DateTime(1990,01,01)),
        new Customer(1,"Iqbal","abc","naresh.adepu@pac",new DateTime(1990,01,01))

    };
    public IList<Customer> Get() => customers;

    public void Create(Customer customer){ customers.Add(customer);}
}