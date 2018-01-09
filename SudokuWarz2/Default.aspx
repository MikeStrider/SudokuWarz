<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SudokuWarz2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
      @font-face { font-family: JuneBug; src: url('orangejuice2.0.ttf'); } 
           p {
         font-family: JuneBug;
         font-size: 250%;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div><center>
            <table width="100%">
                <tr>
                    <td> 
                        <center><p>Sudoku Warz</p>
                    </td>
                    <td width ="35%" align="right">
                        Logged in as : <asp:Label ID="lblusername" runat="server" Text="none" ForeColor="#CC6600"></asp:Label>
                    </td>
                </tr>
            </table> <br /> <br />

            Sudoku Warz is a 1v1 battle where you take turns completing a Sudoku puzzle.  The player that completes the puzzle in the least amount of time is the winner. <br /> <br />
            Please Log In to Start <br /> <br />
            User Name : <asp:TextBox ID="TextBox1" runat="server" MaxLength="15" Width="152px"></asp:TextBox> <br />
            (limit 15 chars) <br /> <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" style="height: 26px"></asp:Button>
        </div>
    </form>
</body>
</html>
