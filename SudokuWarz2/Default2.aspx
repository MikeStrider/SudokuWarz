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
                                <asp:Label ID="lblusername" runat="server" Text="Label" ForeColor="#CC6600"></asp:Label>
                                <br />

                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" TabIndex="1">Log Out</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <center>
                      <table>
                        <tr>
                         <td>
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" OnItemDataBound="DataList1_ItemDataBound"
                            OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                          <ItemTemplate>
                            <table border="1">
                                <tr>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol1" runat="server" Text='<%# Eval("column1") %>' />
                                        <asp:TextBox ID="txtcol1" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol2" runat="server" Text='<%# Eval("column2") %>' />
                                        <asp:TextBox ID="txtcol2" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol3" runat="server" Text='<%# Eval("column3") %>' />
                                        <asp:TextBox ID="txtcol3" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol4" runat="server" Text='<%# Eval("column4") %>' />
                                        <asp:TextBox ID="txtcol4" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol5" runat="server" Text='<%# Eval("column5") %>' />
                                        <asp:TextBox ID="txtcol5" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol6" runat="server" Text='<%# Eval("column6") %>' />
                                        <asp:TextBox ID="txtcol6" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol7" runat="server" Text='<%# Eval("column7") %>' />
                                         <asp:TextBox ID="txtcol7" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol8" runat="server" Text='<%# Eval("column8") %>' />
                                        <asp:TextBox ID="txtcol8" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td width="30px">
                                        <center>
                                        <asp:Label ID="lblcol9" runat="server" Text='<%# Eval("column9") %>' />
                                        <asp:TextBox ID="txtcol9" runat="server" Width="26px" Visible="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                          </td>
                          <td width="22px"></td>
                           <td><br />Its Your Turn : <asp:Label ID="lblitsYourTurn" runat="server" Text="none" ForeColor="#CC6600"></asp:Label> <br />
                                     <asp:Button ID="Button5" runat="server" Text="End Turn" OnClick="Button5_Click" Visible="False"></asp:Button> <br />
                                     <asp:Button ID="Button6" runat="server" Text="Start Game" OnClick="Button6_Click" Visible="False"></asp:Button>
                           </td>
                         </tr>
                      </table>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    Seat 1 : <asp:Label ID="lblSeat1" runat="server" Text="none" ForeColor="#CC6600"></asp:Label> <br />
                                    <asp:Button ID="Button1" runat="server" Text="Sit Down" OnClick="Button1_Click" TabIndex="2"></asp:Button>
                                </td>
                                <td width="22px"></td>
                                <td>
                                    Seat 2 : <asp:Label ID="lblSeat2" runat="server" Text="none" ForeColor="#CC6600"></asp:Label> <br />
                                    <asp:Button ID="Button3" runat="server" Text="Sit Down" OnClick="Button3_Click" TabIndex="3"></asp:Button>
                                </td>
                                <td width="22px"></td>
                                <td>
                                    <asp:Label ID="lblturn" runat="server" Text="Its Your Turn" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Visible="False"></asp:Label>
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
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                            <asp:BoundField DataField="datetime" HeaderText="datetime" SortExpression="datetime">
                                <ItemStyle Font-Size="Small" />
                            </asp:BoundField>
                            <asp:BoundField DataField="text" HeaderText="text" SortExpression="text" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server" Text="Label not refreshed yet"></asp:Label><br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SudokuWarzConnectionString1 %>"
                        ProviderName="<%$ ConnectionStrings:SudokuWarzConnectionString1.ProviderName %>"
                        SelectCommand="SELECT name, datetime, text FROM Chat ORDER BY uniqueID"></asp:SqlDataSource>
                    <br />
                    <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="customBottom">
            <asp:Panel ID="Panel3" runat="server" DefaultButton="Button2">
                <table width="100%">
                    <tr>
                        <td width="90%">
                            <asp:TextBox ID="TextBox3" runat="server" Width="100%" TabIndex="5"></asp:TextBox>
                        </td>
                        <td width="10%">
                            <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" Width="100%" TabIndex="6" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="customBottom2">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Hide Users List" OnClick="Button4_Click" TabIndex="4" />
                                <asp:ListBox ID="ListBox1" runat="server" Height="110px" Width="268px"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
