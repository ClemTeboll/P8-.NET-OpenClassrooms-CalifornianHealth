public record struct AppointmentInputDto
    (
        int Id,
        DateTime StartDateTime,
        DateTime EndDateTime,
        int ConsultantId,
        string PatientId
    );
