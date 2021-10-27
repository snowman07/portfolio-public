<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2><%: Title %>.</h2>
        <h3>User and Security Roles and Password</h3>
        <p>
            <strong>Webmaster Role: </strong><br />
            username: Webmaster<br />
           password: Pa$$w0rd<br />
        </p>
        <p>
            <strong>Associate Role:</strong><br />
            username: DBookem<br />
            username: JKan<br />
            username: NItall<br />
            password: Pa$$wordUser<br />
        </p>
        <p><strong>Store Manager Role:</strong><br />
            username: NPointe<br />
            password: Pa$$wordUser<br />
        </p>
        <p>
            <strong>Purchasing - </strong>
            Store Manager or Department Head creates purchases <br/>
            <strong>Receiving  - </strong>
            Associate or Department Head do receiving <br/>
            <strong>Rentals - </strong>
            Associate, Store Manager or Department Head create rentals <br/>
            <strong>Sales - </strong>
            Associate or Store Manager handle sales and/or returns <br/>
        </p>
    </div>

    <div>
       <h3>Database Connection String</h3>
        <blockquote>
            &lt;connectionstrings&gt;<br />
	            &lt;add name="DefaultConnection"
		         connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApp-20210130014757.mdf;Initial Catalog=aspnet-WebApp-20210130014757;Integrated Security=True"<br />
		         providerName="System.Data.SqlClient" /&gt;<br />

	                &lt;add name="ToolsRUsDB"<br />
		                 connectionString=".;<br />
			                 Initial Catalog=eTools;<br />
			                 Integrated Security=True"<br />
		                providerName="System.Data.SqlClient" /&gt;<br />
                &lt;/connectionstrings&gt;<br />
        </blockquote>
    </div>
</asp:Content>
