using App.Domain.Common;
using App.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastrcuture.Services.Event
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        public async Task DispatchAndClearEvents(BaseEvent entitiesWithEvents)
        {
            await _mediator.Publish(entitiesWithEvents);
            return;
        }
    }
}
