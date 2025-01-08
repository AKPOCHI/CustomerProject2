using Data.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CustomerAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public Guid CustomerId { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public string AccountNumber { get; set; }   

        public decimal AccountBalance { get; set; }
    }
}
