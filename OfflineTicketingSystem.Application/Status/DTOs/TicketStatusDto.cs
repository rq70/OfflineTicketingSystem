using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Status.DTOs
{
    public class TicketStatusDto
    {
        public int Open {  get; set; }
        public int InProgress {  get; set; }
        public int Closed { get; set; }
    }
}
