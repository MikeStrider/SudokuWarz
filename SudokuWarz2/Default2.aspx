<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="SudokuWarz2.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @font-face {
            font-family: JuneBug;
            src: url('orangejuice2.0.ttf');
        }

        p {
            font-family: JuneBug;
            font-size: 250%;
        }

        .customRight {
            width: 40%;
            position: fixed;
            right: 0;
            bottom: 13px;
        }

        .customLeft {
            width: 60%;
            position: fixed;
            left: 0;
            top: 0;
        }

        .customBottom {
            width: 100%;
            position: fixed;
            bottom: 0;
            left: 0;
            height: 28px;
        }

          .customBottom2 {
            position: fixed;
            bottom: 30px;
            left: 0;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="customLeft">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td>
                                <center><p>Sudoku Warz</p></center>
                            </td>
                            <td width="35%" align="right">Logged in as :
                                <asp:Label ID="lblusername" runat="server" Text="Label"></asp:Label>
                                <br />
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Log Out</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <center>
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2">
                        <ItemTemplate>
                            <table border="1">
                                <tr>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol1" runat="server" Text='<%# Eval("column1") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Eval("column2") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Eval("column3") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Eval("column4") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Eval("column5") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol6" runat="server" Text='<%# Eval("column6") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol7" runat="server" Text='<%# Eval("column7") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol8" runat="server" Text='<%# Eval("column8") %>' />
                                    </td>
                                    <td width="20px">
                                        <center>
                                        <asp:Label ID="lblcol9" runat="server" Text='<%# Eval("column9") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    Seat 1 : <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> <br />
                                    <asp:Button ID="Button1" runat="server" Text="Sit Down" OnClick="Button1_Click"></asp:Button>
                                </td>
                                <td width="22px"></td>
                                <td>
                                    Seat 2 : <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label> <br />
                                    <asp:Button ID="Button3" runat="server" Text="Sit Down" OnClick="Button3_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                        </center>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                        ConnectionString="<%$ ConnectionStrings:SudokuWarzConnectionString1 %>"
                        SelectCommand="SELECT * FROM [Puzzle] ORDER BY rowID"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="customRight">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label not refreshed yet"></asp:Label>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                            <asp:BoundField DataField="text" HeaderText="text" SortExpression="text" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SudokuWarzConnectionString1 %>"
                        ProviderName="<%$ ConnectionStrings:SudokuWarzConnectionString1.ProviderName %>"
                        SelectCommand="SELECT [uniqueID], [name], [text] FROM [Chat] Order By uniqueID"></asp:SqlDataSource>
                    <br />
                    <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="customBottom">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td width="90%">
                                <asp:TextBox ID="TextBox3" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td width="10%">
                                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" Width="100%" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="customBottom2">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>

                    <asp:ListBox ID="ListBox1" runat="server" Height="129px" Width="268px"></asp:ListBox>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
