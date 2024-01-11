namespace DasherApp.Model
{
    public class DashDetailModel
    {
        public int Id { get; set; }
        public string Restaurant { get; set; }
        public DateTime OrderCreateTime { get; set; }
        public DateTime OrderPickupTime { get; set; }
        public DateTime OrderDeliveryTime { get; set; }
        public int DailyDashId { get; set; }
        public DateTime RowCreateDate { get; set; }
        public DateTime RowUpdateDate { get; set; }
    }
}
