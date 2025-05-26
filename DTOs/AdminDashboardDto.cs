namespace TranspoJo.DTOs
{
    public class AdminDashboardDto
    {
        public int BusStationCount { get; set; }
        public int RentalPlaceCount { get; set; }
   
      public List<StationStartDto> StationStart { get; set; }
       
    }
}
