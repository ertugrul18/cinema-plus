using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cinema_plus
{
    public partial class Filmler : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CinemaTicketEntities entities = new CinemaTicketEntities();
            var data = entities.filmlers.ToList(); 
           
            StringBuilder stb = new StringBuilder();

            foreach (var film in data)
            {
                var str = "<tr><td> " + film.film_id + " </td><td> " + film.film_adi + " </td><td> " + film.süresi + " </td><td>" + film.vizyon_tarihi + "</td><td> " + film.tur_adi + "</td><td> " + film.ozet + " </td><td>" + film.imdb_puani + "</td><td>" + film.yapimi + " </td><td> " + film.yonetmen + " </td><td> " + film.dil + " </td><td><img width=\"60px\" height=\"60px\" src="+film.Image+"></td></tr>";

                stb.Append(str);

            }

            filmListBody.InnerHtml = stb.ToString();
        }
    }
}