using App.Domain.Common;
using App.Domain.Entities;


namespace App.Domain.Events
{
    public class ProductCreateEvent:BaseEvent
    {
        public ProductCreateEvent(Product product)
        {
            Product = product;
        }
        public Product Product { get; set; }
    }
}
