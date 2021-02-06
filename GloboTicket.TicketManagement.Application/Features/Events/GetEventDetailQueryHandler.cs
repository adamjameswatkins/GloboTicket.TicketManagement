using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Event> eventRepository;
        private readonly IAsyncRepository<Category> categoryRepository;

        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
            this.categoryRepository = categoryRepository;
        }
        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await this.eventRepository.GetByIdAsync(request.Id);

            var eventDetailDto = this.mapper.Map<EventDetailVm>(@event);

            var category = await this.categoryRepository.GetByIdAsync(@event.CategoryId);

            eventDetailDto.Category = this.mapper.Map<CategoryDto>(category);

            return eventDetailDto;
        }
    }
}
