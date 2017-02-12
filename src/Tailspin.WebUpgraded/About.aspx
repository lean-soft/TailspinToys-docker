<%@ Page Title="" Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Tailspin Toys - About Us</title>
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
<h1 class="section-header">Corporate Bio</h1>
    <div id="bdy" class="product-wrapper">
        <div class="product-detail">
        <div >
            <%--<h2>
                Corporate Bio
            </h2>--%>
            <br />
            <p>
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad
                minim veniam, quis nostrud exercitation ulliam corper suscipit lobortis nisl ut
                aliquip ex ea commodo consequat. Duis autem veleum iriure dolor in hendrerit in
                vulputate velit esse molestie consequat, vel willum lunombro dolore eu feugiat nulla
                facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent
                luptatum zzril delenit augue duis dolore te feugait nulla facilisi.
            </p>
            <p>
                Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.
                Por scientie, musica, sport etc., li tot Europa usa li sam vocabularium. Li lingues
                differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos
                directe al desirabilit&aacute; de un nov lingua franca: on refusa continuar payar
                custosi traductores. It solmen va esser necessi far uniform grammatica, pronunciation
                e plu sommun paroles.
            </p>
            <p>
                Ma quande lingues coalesce, li grammatica
                del resultant lingue es plu simplic e regulari quam ti del coalescent lingues. Li
                nov lingua franca va esser plu simplic e regulari quam li existent Europan lingues.
                It va esser tam simplic quam Occidental: in fact, it va esser Occidental. A un Angleso
                it va semblar un simplificat Angles, quam un skeptic Cambridge amico dit me que
                Occidental es.
            </p>
            <hr />
            <h2 class="small">
                CEO Bio</h2>
            <p>
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad
                minim veniam, quis nostrud exercitation ulliam corper suscipit lobortis nisl ut
                aliquip ex ea commodo consequat. Duis autem veleum iriure dolor in hendrerit in
                vulputate velit esse molestie consequat, vel willum lunombro dolore eu feugiat nulla
                facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent
                luptatum zzril delenit augue duis dolore te feugait nulla facilisi.
            </p>
            <p>
                Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.
                Por scientie, musica, sport etc., li tot Europa usa li sam vocabularium. Li lingues
                differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos
                directe al desirabilit&aacute; de un nov lingua franca: on refusa continuar payar
                custosi traductores. It solmen va esser necessi far uniform grammatica, pronunciation
                e plu sommun paroles.
            </p>
            <p>
                Ma quande lingues coalesce, li grammatica del resultant lingue es plu simplic e
                regulari quam ti del coalescent lingues. Li nov lingua franca va esser plu simplic
                e regulari quam li existent Europan lingues. It va esser tam simplic quam Occidental:
                in fact, it va esser Occidental. A un Angleso it va semblar un simplificat Angles,
                quam un skeptic Cambridge amico dit me que Occidental es.
            </p>
            <hr />
            <h2 class="small">
                CTO Bio</h2>
            <p>
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad
                minim veniam, quis nostrud exercitation ulliam corper suscipit lobortis nisl ut
                aliquip ex ea commodo consequat. Duis autem veleum iriure dolor in hendrerit in
                vulputate velit esse molestie consequat, vel willum lunombro dolore eu feugiat nulla
                facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent
                luptatum zzril delenit augue duis dolore te feugait nulla facilisi.
            </p>
            <p>
                Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.
                Por scientie, musica, sport etc., li tot Europa usa li sam vocabularium. Li lingues
                differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos
                directe al desirabilit&aacute; de un nov lingua franca: on refusa continuar payar
                custosi traductores. It solmen va esser necessi far uniform grammatica, pronunciation
                e plu sommun paroles.
            </p>
            <p>
                Ma quande lingues coalesce, li grammatica del resultant lingue es plu simplic e
                regulari quam ti del coalescent lingues. Li nov lingua franca va esser plu simplic
                e regulari quam li existent Europan lingues. It va esser tam simplic quam Occidental:
                in fact, it va esser Occidental. A un Angleso it va semblar un simplificat Angles,
                quam un skeptic Cambridge amico dit me que Occidental es.
            </p>
            <asp:AdRotator ID="AdRotator1" runat="server" DataSourceID="XmlDataSource1" />
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="/Content/Xml/Ads.xml" />
        </div>
        </div>
    </div>
</asp:Content>
