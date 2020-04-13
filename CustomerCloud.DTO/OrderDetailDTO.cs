using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.DTOs
{
    public class OrderDetailDTO
    {
        public Guid Id { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
