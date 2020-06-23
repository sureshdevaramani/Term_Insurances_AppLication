using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class PaymentBussinessLayer
    {
        public int policy_id { get; set; }

        public string payment_mode { get; set; }

        public DateTime payment_date { get; set; }

        public double policy_premium { get; set; }
    }
}
