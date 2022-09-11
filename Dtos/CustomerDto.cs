namespace CustomersApi.Dtos
{
    /* un Dto es un objeto que se utiliza para transferir informacion de una capa del cominio a otra*/
    public class CustomerDto
    {
        public int id { get; set; }
        public String name { get; set; }
        public String document_type { get; set; }
        public String document { get; set; }
        public String deparment { get; set; }
        public DateTime date_end_of_contract { get; set; }
        public String email { get; set; }
        public String cargo { get; set; }
    }
}
