using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public List<OrderDetailDTO> Details { get; set; }
    }
}
