using System.ComponentModel.DataAnnotations;

namespace MsCiot_Fix.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Fat { get; set; }
        public int Temprature { get; set; }
        public int BloodPressure { get; set; }

        public DateTime DateTime { get; set; }
    }
}
