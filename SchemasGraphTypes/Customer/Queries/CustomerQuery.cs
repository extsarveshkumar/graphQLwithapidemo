public class CustomerQuery : ObjectGraphType
{
    public CustomerQuery(ICustomerProvider customerProvider)
    {
        
        Name = "Query";
        Field<ListGraphType<CustomerGraphType>>( Name= "customers", resolve: x => customerProvider.GetCustomers());
        Field<CustomerGraphType>(Name="customer",
            arguments:new QueryArguments(new QueryArgument<IntGraphType>{Name = "Id"}),
            resolve: x=> customerProvider.GetCustomers().FirstOrDefault(p=> p.Id ==  x.GetArgument<int>("Id")));

            
    }
}