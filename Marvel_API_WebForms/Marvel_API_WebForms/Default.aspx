<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marvel Comics API</title>

    <style type="text/css">
        body
        {
            font-family: 'Comic Sans MS';
        }
    </style>
</head>
<body>
    <form runat="server">
        <h1>Marvel Comics API</h1>
        <div>
            <asp:DataList ID="dtlAvengers" runat="server" RepeatDirection="Horizontal" OnItemDataBound="dtlAvengers_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="lbkAvenger" runat="server" Style="padding: 0 10px" OnClick="lbkAvenger_Click" />
                </ItemTemplate>
            </asp:DataList>
        </div>

        <asp:Panel ID="pnlAvenger" runat="server" Visible="false">
            <div style="overflow: hidden; margin-top: 50px;">
                <div style="float: left; margin-right: 50px;">
                    <asp:Image ID="imgAvenger" runat="server" Height="200" Width="200" />
                </div>
                <div style="margin-left: 50px;">
                    <h2><asp:LinkButton ID="lbkUrlWiki" runat="server" Text="More info..." /></h2>
                    <p><asp:Literal ID="litDescricao" runat="server" /></p>
                </div>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
