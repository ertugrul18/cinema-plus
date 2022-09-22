<%@ Page Title="Vizyondakiler" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Filmler.aspx.cs" Inherits="cinema_plus.Filmler" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <table class="table table-dark">
        <thead>
            <th>Film No</th>
            <th>Film Adı</th>
            <th>Süre</th>
            <th>Vizyon Tarihi</th>
            <th>Tür</th>
            <th>Özet</th>
            <th>Imdb puanı</th>
            <th>Yapım</th>
            <th>Yönetmen</th>
            <th>Dil</th>
            <th>Film Kapağı</th>
        </thead>
        <tbody id="filmListBody"  runat="server">
        
        </tbody>
        </table>


    </div>

    
</asp:Content>
