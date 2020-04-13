using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.DTOs
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("AddressId")]
        public Guid AddressId { get; set; }
        public AddressDTO Address { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
