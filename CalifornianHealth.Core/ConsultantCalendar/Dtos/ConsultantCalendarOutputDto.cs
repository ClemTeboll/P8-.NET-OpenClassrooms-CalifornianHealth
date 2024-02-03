public record struct ConsultantCalendarOutputDto
    (
        int Id,
        int ConsultantId,
        DateTime Date,
        bool Available
    );