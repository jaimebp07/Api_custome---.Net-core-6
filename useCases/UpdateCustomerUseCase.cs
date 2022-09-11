using CustomersApi.Repositories;

namespace CustomersApi.useCases
{
   
    public interface IUpdateCustomerUseCase
    {
        Task<Dtos.CustomerDto?> Execute(Dtos.CustomerDto customer);
    }

    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {

        private readonly CustomerDatabaseContext _customerDatabaseContext;

        public UpdateCustomerUseCase(CustomerDatabaseContext customerDatabaseContext)
        {
            _customerDatabaseContext = customerDatabaseContext;
        }


        public async Task<Dtos.CustomerDto?> Execute(Dtos.CustomerDto customer)
        {
            var entity = await _customerDatabaseContext.Get(customer.id);

            if (entity == null)
                return null;
            entity.name = customer.name;
            entity.document_type = customer.document_type;
            entity.document = customer.document;
            entity.deparment = customer.deparment;
            entity.date_end_of_contract = customer.date_end_of_contract;
            entity.email = customer.email;
            entity.cargo = customer.cargo;


            await _customerDatabaseContext.Update(entity);
            return entity.ToDto();

        }

    }
}
