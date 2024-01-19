﻿using CalifornianHealth.Core.ConsultantCalendar.Contracts;
using CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository;

namespace CalifornianHealth.Core.ConsultantCalendar
{
    public class ConsultantCalendarManager : IConsultantCalendarManager
    {
        private readonly IConsultantCalendarRepository _consultantCalendarRepository;

        public ConsultantCalendarManager(IConsultantCalendarRepository consultantCalendarRepository)
        {
            _consultantCalendarRepository = consultantCalendarRepository;
        }

        public List<ConsultantCalendarOutputDto> GetAllConsultantCalendars()
        {
            var request = _consultantCalendarRepository.FetchConsultantCalendar();
            return CreateOutputList(request);
        }

        public List<ConsultantCalendarOutputDto> GetConsultantCalendarsById(int id)
        {
            var request = _consultantCalendarRepository.FetchConsultantCalendarById(id);
            return CreateOutputList(request);
        }

        private List<ConsultantCalendarOutputDto> CreateOutputList(IEnumerable<Infrastructure.Database.Entities.ConsultantCalendar> request)
        {
            return request.Select(x => new ConsultantCalendarOutputDto
            {
                Id = x.Id,
                ConsultantId = x.ConsultantId,
                Date = x.Date,
                Available = x.Available
            }).ToList();
        }
    }
}
