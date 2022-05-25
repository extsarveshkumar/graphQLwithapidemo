using GraphQL.Instrumentation;
using GraphQL.Types;
using System;
using System.Web;
class CustomerSchema: Schema
{
    public CustomerSchema(IServiceProvider serviceProvider):base(serviceProvider){
        Query =(CustomerQuery) serviceProvider.GetRequiredService(typeof(CustomerQuery))?? throw new InvalidOperationException();
        Mutation = serviceProvider.GetRequiredService<CustomerMutation>();
    }
}