<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="cinema_plus.Ticket" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center;">
        <h1>Rezervasyon</h1>
    </div>
    <br />
    <form>
        <div class="form-group">
            <label>Filmler</label>
            <asp:DropDownList ID="Filmler" CssClass="form-control" OnSelectedIndexChanged="Filmler_SelectedIndexChanged" runat="server" AutoPostBack="true"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label>Tarih</label>
            <asp:DropDownList ID="SeansTarih" CssClass="form-control" OnSelectedIndexChanged="SeansTarih_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
        </div>


        <div class="form-group">
            <label>Seans</label>
            <asp:DropDownList ID="Seanslar" CssClass="form-control" OnSelectedIndexChanged="Seanslar_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
        </div>

        <br />
        <h3 style="text-align: center">Kişisel Bilgiler</h3>
        <div class="form-group">
            <label>Ad</label>
            <input class="form-control" type="text" id="isim" />

        </div>
        <div class="form-group">
            <label>Soyad</label>
            <input class="form-control" type="text" id="soyisim" />
        </div>
        <div class="form-group">
            <label>Telefon Numarası</label>
            <input class="form-control" type="text" id="telno" />
        </div>
        <div class="form-group">
            <label>Eposta</label>
            <input class="form-control" type="text" id="eposta" />
        </div>


        <h3 style="text-align: center">Koltuklar</h3>
        <div class="form-group form-check" style="margin: 0 auto" id="Koltuklar" runat="server">
        </div>



        <%-- <asp:Button ID="Button1" runat="server" OnClick="Kaydet_Click" class="btn btn-success" Text="Bilet Al" />--%>
    </form>
    <br />
    <br />
    <br />

    <input id="btnGetTime" type="button" class="btn btn-success" value="Bilet Al" onclick="BiletAl()" />
    <br />
    <br />
    <h2 style="align-items:center" id="tutar"></h2>

      <input id="btnTemizle" type="button" class="btn btn-error" value="Temizle" onclick="Temizle()" />

    <script>
        var koltuk = [];


        function secilenKoltuk() {
            var target = event.target || event.srcElement; // IE

            var id = target.id;

            if (koltuk.indexOf(id) >= 0) { // var çıkart
                koltuk = jQuery.grep(koltuk, function (value) {
                    return value != id;
                });

            }
            else { // koltuk yok array 'e ekle
                koltuk.push(id);
            }
        }


        function BiletAl() {

            var isim = $("#isim").val();
            var soyisim = $("#soyisim").val();
            var telno = $("#telno").val();
            var eposta = $("#eposta").val();
            var filmId = $('#<%=Filmler.ClientID %> option:selected').val();
            var seansId = $('#<%=Seanslar.ClientID %> option:selected').val();

            console.log(filmId);


            if (isim == "" || soyisim == "" || telno == "" || eposta == "" || filmId == 0 || seansId == 0) {// boş ise kontrol
                alert("Lütfen tüm alanları doldurun.");
                return;
            }


            let model = {
                koltuklar: koltuk,
                isim: isim,
                soyisim: soyisim,
                telno: telno,
                eposta: telno,
                filmId: filmId,
                seansId: seansId
            };

            let vm = JSON.stringify(model);

            $.ajax({
                type: "POST",
                url: "Ticket.aspx/BiletAl",
                data: "{'viewModel': '" + vm + "' }",
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: OnSuccess,
                failure: function (response) {
                    //alert(response.d);
                }
            });

        }


        function OnSuccess(response) {
            $("#tutar").text(response.d);

        }


        function Temizle() {
            window.location.href = "Ticket.aspx"
        }

    </script>


</asp:Content>
