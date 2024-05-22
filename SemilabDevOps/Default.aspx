<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SemilabDevOps._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


	 <div>

	 
		 <asp:Label id="Label1" runat="server"/>
		 <br />
                    <asp:TextBox ID="UserName" runat="server" AutoCompleteType="Email" ></asp:TextBox>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
		 <asp:Button id="SubmitButton" runat="server" Text="Belépés VSTS-re" />
	 <br />

		 <asp:DropDownList ID="BugOrBacklog" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="BugOrBacklog_SelectedIndexChanged" >
			 <asp:ListItem Selected="True" Value="-">Kérlek válassz!</asp:ListItem>
			 <asp:ListItem Value="bug"> Hiba bejelentése </asp:ListItem>
			 <asp:ListItem Value="backlog"> Új kérés </asp:ListItem>
		 </asp:DropDownList>
		 <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
		 <asp:DropDownList ID="Severity" runat="server" Visible="false" />
		 <br />
		 <asp:DropDownList ID="ThreadList" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ThreadList_SelectedIndexChanged"><asp:ListItem Selected="True" Value=""> Válassz kategóriát! </asp:ListItem></asp:DropDownList>
		 <br />
		 <asp:DropDownList ID="SubList" runat="server" Visible="false" AutoPostBack ="true" OnSelectedIndexChanged="SubList_SelectedIndexChanged"></asp:DropDownList>
		 <br />
		 <asp:Label ID="CustomLabel1" runat="server" Text="" Visible="false"/><asp:TextBox ID="CustomTextBox1" Width ="0" runat="server" Visible="false" AutoPostBack="true"/><br />
		 <asp:Label ID="CustomLabel2" runat="server" Text="" Visible="false"/><asp:TextBox ID="CustomTextBox2" Width ="0" runat="server" Visible="false" AutoPostBack="true"/><br />
		 <asp:Label ID="CustomLabel3" runat="server" Text="" Visible="false"/><asp:TextBox ID="CustomTextBox3" Width ="0" runat="server" Visible="false" AutoPostBack="true"/><br />
		 <asp:TextBox ID="Subject" runat="server" Visible="false" ToolTip="Cím" AutoPostBack="true" Width="600px"></asp:TextBox>
		 <br />
		 <asp:TextBox ID="Details" runat="server" Visible="false" ToolTip="Részletek" AutoPostBack="true" Height="148px" Width="660px" TextMode="MultiLine" Rows ="10"></asp:TextBox>

		 <br />
		 <asp:Button ID="SubmitTicket" runat="server" Text="Ticket felvétele" Visible="false" OnClick="SubmitTicket_Click" />
		 <asp:Label ID="Feedback" runat="server" Text="" Visible="false"/>
		 <%--<asp:DropDownList ID="Level" runat="server" Visible="false"><asp:ListItem Selected="True" /><asp:ListItem /><asp:ListItem /><asp:ListItem /><asp:ListItem /></asp:DropDownList>--%>
		 <asp:HiddenField ID="Level" Value="0" runat="server" />
	 </div>


</asp:Content>
