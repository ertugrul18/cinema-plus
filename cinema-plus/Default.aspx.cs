﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cinema_plus
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CinemaTicketEntities entities = new CinemaTicketEntities();
            var data = entities.filmlers.ToList();

        }
    }
}