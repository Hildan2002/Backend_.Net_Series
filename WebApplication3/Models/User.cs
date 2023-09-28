namespace WebApplication3.Models
{
    public class Pasien
    {
        public int PasienId { get; set; }
        public string Nama { get; set; }
        public string NoRM { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string Agama { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string Pekerjaan { get; set; }
        public string StatusAsKes { get; set; }
        public string StatusKawin { get; set; }
        public string NamaPenanggungJawab { get; set; }
        public string GolonganDarah { get; set; }
        public string RiwayatPenyakit { get; set; }
        public string AlergiObat { get; set; }
        public string KeadaanKeluar { get; set; }
        public string CaraKeluar { get; set; }
        public int DokterId { get; set; }
        public Dokter Dokter { get; set; }
    }


    /* public class RiwayatPenyakit
    {
        public int RiwayatPenyakitId { get; set; }
        public int PasienId { get; set; }
        // public Pasien Pasien { get; set; }
        public string NamaPenyakit { get; set; }
        // Tambahkan atribut lain yang relevan
    }*/


    public class Dokter
    {
        public int DokterId { get; set; }
        public string NamaDokter { get; set; }
        // Tambahkan atribut lain yang relevan
    }
}
