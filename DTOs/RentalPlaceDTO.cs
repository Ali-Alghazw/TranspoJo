namespace TranspoJo.DTOs
{
    public class RentalPlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public LocationDto Coordinates { get; set; } // NEW
    }
}
