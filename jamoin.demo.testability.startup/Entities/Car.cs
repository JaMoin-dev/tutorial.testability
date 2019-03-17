namespace jamoin.demo.testability.startup.Entities
{
    public class Car
    {
        public double RevolutionsPerMinute { get; set; }
        public double MaxTransmission { get; set; }
        public double WheelSize { get; set; }
        public double MaxSpeed => RevolutionsPerMinute * MaxTransmission * WheelSize * 60;
    }

}
