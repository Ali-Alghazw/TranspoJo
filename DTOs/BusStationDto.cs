namespace TranspoJo.DTOs
{
    public class BusStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationDto Coordinates { get; set; } = new LocationDto(); // Avoid null reference
    }
}
