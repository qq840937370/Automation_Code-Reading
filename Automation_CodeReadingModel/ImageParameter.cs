namespace Automation_CodeReadingModel
{
    public class ImageParameter
    {
        private string mean;   // mean
        private string deviation;   // deviation
        public string Mean {get { return mean != null ? mean : "0"; }set { mean=value; }}
        public string Deviation { get { return deviation != null ? deviation : "0"; } set { deviation = value; } }
    }
}
