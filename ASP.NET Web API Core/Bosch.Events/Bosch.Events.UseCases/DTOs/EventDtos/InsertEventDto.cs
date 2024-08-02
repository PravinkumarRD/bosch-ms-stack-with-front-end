namespace Bosch.Events.UseCases.DTOs.EventDtos
{
    public class InsertEventDto
    {
        public string? EventCode { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Fees { get; set; }
        public int SeatsFilled { get; set; }
        public string? Logo { get; set; }
        public string? Venue { get; set; }
        public string OrganizedBy { get; set; } = string.Empty;
    }
}
