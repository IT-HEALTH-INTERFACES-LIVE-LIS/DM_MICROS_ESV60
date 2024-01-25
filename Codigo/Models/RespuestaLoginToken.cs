namespace DM_MICROS_ESV60.Models
{
    public class RespuestaLoginToken
    {
        public bool ok { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string token { get; set; }
        public string name { get; set; }
        public int idUser { get; set; }
        public string AttentionCenter { get; set; }
        public string UserName { get; set; }
    }


}
