﻿using CalifornianHealth.Infrastructure.Database.Entities;

namespace CalifornianHealth.Infrastructure.Database.Repositories.ConsultantCalendarRepository
{
    public interface IConsultantCalendarRepository
    {
        IEnumerable<ConsultantCalendar> FetchConsultantCalendar(int id);
    }
}
