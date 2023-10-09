using App.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Features.Product.EventsHandler
{
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateEvent>
    {
        public Task Handle(ProductCreateEvent notification, CancellationToken cancellationToken)
        {
           
            Console.WriteLine("Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar Mayar ");
            return Task.CompletedTask;
        }
    }
}
