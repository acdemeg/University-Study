// класс для сбора инфоции о проезжающем ТС
public class CheckPointInfo
{
    public int CurrentSpeed { get; set; }
    public string MessageOverSpeed { get; set; }
    public string MessageStolen { get; set; }
    public string BodyTypeMessage { get; set; }
    public string LicencePlateNumber { get; set; }
    public string Color { get; set; }
    public bool HasPassenger { get; set; }
}
