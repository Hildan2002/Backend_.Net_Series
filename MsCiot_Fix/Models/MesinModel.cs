using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MsCiot_Fix.Models
{
    public class MesinModel
    {
        [Key]
        public int IdMesin { get; set; }

        public string NamaMesin { get; set; }

        public int IdUser { get; set; }
        public UserModel UserModel { get; set; }
    }
}
