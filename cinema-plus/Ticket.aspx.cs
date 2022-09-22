using cinema_plus.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cinema_plus
{
    public partial class Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Filmler.Items.Clear();
                CinemaTicketEntities database = new CinemaTicketEntities();
                List<filmler> filmlerListesi = database.filmlers.ToList();
                //sayfa açılırken filmleri listeliyoruz
                ListItem secinizItem = new ListItem();
                secinizItem.Text = "Film Seçiniz";
                secinizItem.Value = 0.ToString();
                Filmler.Items.Add(secinizItem);

                foreach (var film in filmlerListesi)
                {
                    ListItem filmItem = new ListItem();
                    filmItem.Text = film.film_adi;
                    filmItem.Value = film.film_id.ToString();
                    Filmler.Items.Add(filmItem);
                }
                
            }
        }


        [System.Web.Services.WebMethod]
        public static string BiletAl(string viewModel)
        {
            var model = JsonConvert.DeserializeObject<BiletAlModel>(viewModel);

            CinemaTicketEntities database = new CinemaTicketEntities();

            var musteriKayit = database.musterilers.Add(new musteriler() { musteri_adi = model.isim, musteri_soyadi = model.soyisim, eposta = model.eposta, tel_no = model.telno });
            database.SaveChanges();

            foreach (var koltuk in model.koltuklar)//ekrandan gelen koltuk sayısı kadar dönüyor her bir koltuk sayısı için rezervasyon oluşturuyor
            {
                var rezervasyonModel = new rezervasyon();
                rezervasyonModel.film_id = model.filmId;
                rezervasyonModel.seans_id = model.seansId;
                rezervasyonModel.koltuk_no = koltuk;

                rezervasyonModel.musteri_id = musteriKayit.musteri_id;
                database.rezervasyons.Add(rezervasyonModel);

                database.SaveChanges();
            }
            //oluşturulan modeli veri tabanına ekliyor


            var fiyat = 10 * model.koltuklar.Count;

            return $"Ödenecek Tutar:  {fiyat}  TL";
        }

        protected void Filmler_SelectedIndexChanged(object sender, EventArgs e)
        {

            SeansTarih.Items.Clear();

            CinemaTicketEntities database = new CinemaTicketEntities();
            var secilenFİlmId = Convert.ToInt32(Filmler.SelectedItem.Value);
            var secilenFilmeGoreSeansTarihleri = database.seanslars.Where(x => x.film_id == secilenFİlmId && x.tarih > DateTime.Now).ToList();

            var tarihListItem = secilenFilmeGoreSeansTarihleri.DistinctBy(p => p.tarih).Select(x => new ListItem
            {
                Text = x.tarih.Value.ToString("dd.MM.yyyy"),
                Value = x.seans_id.ToString()
            });
            //film seçildiğinde yapılacaklar

            ListItem secinizTarihItem = new ListItem();
            secinizTarihItem.Text = "Tarih Seçiniz";
            secinizTarihItem.Value = 0.ToString();

            SeansTarih.Items.Add(secinizTarihItem);
            //film seçildiğinde tarihleri getiriyoruz

            foreach (var item in tarihListItem)
            {
                SeansTarih.Items.Add(item);
            }
            //sean tarihleri seans seçim yerine ekliyorum
        }

        protected void SeansTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seçilen film ıd ye bağlı seans tarihleri yani gösterim tarihleri gelecek bunu seçtikten sonra tarih bazlı seans saatleri gelecek

            Seanslar.Items.Clear();

            ListItem secinizSeans = new ListItem();
            secinizSeans.Text = "Saat Seciniz";
            secinizSeans.Value = 0.ToString();
            Seanslar.Items.Add(secinizSeans);


            var secilenTarihId = Convert.ToInt32(SeansTarih.SelectedItem.Value);
            var secilenFİlmId = Convert.ToInt32(Filmler.SelectedItem.Value);
            if (secilenFİlmId != 0 && secilenTarihId != 0)
            {
                CinemaTicketEntities database = new CinemaTicketEntities();

                //seçilen filmId sini alır.

                var secilenTarih = Convert.ToDateTime(SeansTarih.SelectedItem.Text);

                //seçilen filmId ye ait seansları getirir.
                var seanslar = database.seanslars.Where(x => x.film_id == secilenFİlmId && x.tarih == secilenTarih).ToList();

                foreach (var seans in seanslar)
                {
                    ListItem seansItem = new ListItem();
                    seansItem.Text = seans.saat.ToString();
                    seansItem.Value = seans.seans_id.ToString();
                    Seanslar.Items.Add(seansItem);
                }
                //senaslar geliyor
            }

        }


        protected void Seanslar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var secilenFİlmId = Convert.ToInt32(Filmler.SelectedItem.Value);
            var selectedSeanceId = Convert.ToInt32(Seanslar.SelectedItem.Value);

            CinemaTicketEntities database = new CinemaTicketEntities();
            StringBuilder koltuklar = new StringBuilder();

            //Dolu koltuk numaralarını döner. Totalde 12 koltuk belirlemiş olalım. 1,2,3,4,5 .. diye numaralandırabilirim.
            var doluKoltuklar = database.rezervasyons.Where(x => x.film_id == secilenFİlmId && x.seans_id == selectedSeanceId).Select(x => x.koltuk_no).ToList(); //  toplam 7 koltuk döndü  (3,4,5,6,7,8,9)
            // 1 3 5 7 9    - --  12  

            for (int ks = 1; ks <= 12; ks++) //TOPLAM KOLTUK KAPASİTESİ 12
            {
                var koltuk = string.Empty;

                if (doluKoltuklar.Contains(ks)) //Dolu koltuk döndürür. Contains(içermek)
                {
                    koltuk = $"<input type=\"checkbox\" disabled=\"disabled\" checked=\"checked\"  class=\"form-check-input\" id=\"{ks}\">NO:<label class=\"form-check-label\">{ks}</label><img src=\"/Metarials/kirmizi.jpg\" width=\"50px\" height=\"60px\"/>";

                    //var aa = "<img src=\"/Metarials/koltuk.png\" width=\"50px\" height=\"60px\"/>";
                }
                else  //Boş koltuk döndürür.
                {
                    koltuk = $"<input type=\"checkbox\" id=\"{ks}\" onclick=\"secilenKoltuk(event)\" class=\"form-check-input\">NO:<label class=\"form-check-label\">{ks}</label><img src=\"/Metarials/yesil.jpg\" width=\"50px\" height=\"60px\"/>";
                }

                koltuklar.Append(koltuk);
            }

            Koltuklar.InnerHtml = koltuklar.ToString();




        }

    }
}