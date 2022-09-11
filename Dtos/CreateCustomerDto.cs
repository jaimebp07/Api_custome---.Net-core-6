using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Dtos
{
    public class CreateCustomerDto
    {
        [Required (ErrorMessage = "El nombre propio tiene que estar especificado")]
        public String name { get; set; }

        [Required(ErrorMessage = "El tipo de documento tiene que estar especificado")]
        public String document_type { get; set; }

        [Required(ErrorMessage = "El documento tiene que estar especificado")]
        public String document { get; set; }
        
        [Required(ErrorMessage = "El departamento tiene que estar especificado")]
        public String deparment { get; set; }

        public DateTime date_end_of_contract { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "el email no es correcto")]
        public String email { get; set; }
        
        public String cargo { get; set; }

    }
}
