using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Business;

public partial class _Default : System.Web.UI.Page 
{
    private Marvel marvel;

    private Marvel Marvel
    {
        get
        {
            if (marvel == null)
                marvel = new Marvel();
            return marvel;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (! IsPostBack)
        {
            List<String> lstAvengers = new List<String>();
            lstAvengers.Add("Hulk");
            lstAvengers.Add("Iron Man");
            lstAvengers.Add("Thor");
            lstAvengers.Add("Captain America");
            lstAvengers.Add("Spider-Man");

            dtlAvengers.DataSource = lstAvengers;
            dtlAvengers.DataBind();
        }
    }

    protected void dtlAvengers_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbkAvenger = (LinkButton) e.Item.FindControl("lbkAvenger");
            lbkAvenger.Text = e.Item.DataItem.ToString();
        }
    }

    protected void lbkAvenger_Click(object sender, EventArgs e)
    {
        LinkButton lbkAvenger = (LinkButton) sender;
        Personagem p = Marvel.obterDadosPersonagem(lbkAvenger.Text);

        CarregarDados(p);

        pnlAvenger.Visible = true;
    }

    private void CarregarDados(Personagem p)
    {
        imgAvenger.ImageUrl = p.UrlImagem;
        lbkUrlWiki.PostBackUrl = p.UrlWiki;
        litDescricao.Text = p.Descricao;
    }
}