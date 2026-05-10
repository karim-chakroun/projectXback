using Aladin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aladin.Service.DTO
{
    public class LeasingRequestDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }   // "KIA Sportage"
        public string FullName { get; set; }
        public string Cin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal MonthlyIncome { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
