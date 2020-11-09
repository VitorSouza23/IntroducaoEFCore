using System;
using System.Collections.Generic;
using IntroducaoEFCore.ValueObjects;

namespace IntroducaoEFCore.Domain
{
    public class Order
    {
        public int id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartIn { get; set; }
        public DateTime EndIn { get; set; }
        public FreightType FreightType { get; set; }
        public OrderState OrderState { get; set; }
        public string Observation { get; set; }
        public ICollection<OrderItem> MyProperty { get; set; }
    }
}