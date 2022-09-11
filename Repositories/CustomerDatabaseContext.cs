using CustomersApi.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi.Repositories
{
    public class CustomerDatabaseContext : DbContext
    {
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) : base(options)
        {

        }

        public DbSet<CustomerEntity> Customers { get; set; }

        public async Task<CustomerEntity> Get(int id)
        {
            return await Customers.FirstAsync(x => x.id == id);
            //return await Customers.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Delete(int id)
        {
            CustomerEntity entity = await Get(id);
            Customers.Remove(entity);
            SaveChanges();
            return true;
        }


        //Añadir un elemento
        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                id = null,
                name = customerDto.name,
                document_type = customerDto.document_type,
                document = customerDto.document,
                deparment = customerDto.deparment,
                date_end_of_contract = customerDto.date_end_of_contract,
                email = customerDto.email,
                cargo = customerDto.cargo
            };

            EntityEntry<CustomerEntity> response = await Customers.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.id ?? throw new Exception("no se ha podido guardar"));

        }

        public async Task<bool> Update(CustomerEntity customerEntity)
        {
            Customers.Update(customerEntity);
            await SaveChangesAsync();

            return true;
        }
    }

    public class CustomerEntity
    {
        public int? id { get; set; }
        public String name { get; set; }
        public String document_type { get; set; }
        public String document { get; set; }
        public String deparment { get; set; }
        public DateTime date_end_of_contract { get; set; }
        public String email { get; set; }
        public String cargo { get; set; }
    
        public CustomerDto ToDto()
        {
            return new CustomerDto()
            {
                name = name,
                document_type = document_type,
                document = document,
                deparment = deparment,
                date_end_of_contract = date_end_of_contract,
                email = email,
                cargo = cargo,
                id = id ?? throw new Exception("el ide no puede ser null")
            };
        }
    }
}