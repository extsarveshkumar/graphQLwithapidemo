class CustomerGraphType:ObjectGraphType<Customer>
{   
    public CustomerGraphType()
    {
        Name ="Customer";
        Field(x=>x.Id, type:typeof(IdGraphType)).Description("CustomerID");
        Field(x => x.FirstName).Description("Customer's First Name");
        Field(x=> x.LastName).Description("Customer Last Name");
        Field(x=>x.Email).Description("Customer Email");
        Field(x=>x.DateOfBirth).Description("Customer DateOfBirth");
    }
    
}