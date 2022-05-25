///Mutations - A way to change the data(Edit/delete/Add)

public class CustomerInput: InputObjectGraphType{
    public CustomerInput(){
        Field<IntGraphType>("Id");
        Field<StringGraphType>("FirstName");
        Field<StringGraphType>("LastName");
        Field<StringGraphType>("Email");
        Field<StringGraphType>("DateOfBirth");
        
    }
}

public class CustomerMutation: ObjectGraphType{
    public CustomerMutation(ICustomerCreator customerCreator){
        Field<CustomerGraphType>("createcustomer",
        arguments:new QueryArguments{new QueryArgument<CustomerInput> { Name ="customer"}},
        resolve: x=> customerCreator.Create(x.GetArgument<Customer>("customer")));
        
        
    }
}

