using System.ComponentModel.DataAnnotations;

namespace AC_Razor_HTML_helper.Models
{
    public class estados_reserva
    {
        [Key]
        public int estado_res_id { get; set; }
        public string? estado { get; set; }
    }
}
