<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h1>Team D</h1><br />
            <img src="/img/logo.png" alt="Team Logo" /><br />
        </div>
        <div class="col-md-8">
            <h2>Team Members and Responsibilities</h2>
            <p>Team Diamond is composed of 4 members. <strong>Setup roles and responsibilities</strong> were divided among 3 members while <strong>Security setup</strong> was completed by 1 member.</p>
            <br />
            <h3>1. Arr Domingo</h3>
            <p>git: snowman07</p>
            <ul>
                <li>Setup: #7 - Reverse Engineering of Database, DAL Classes Setup, and Assist in Security Setup</li>
                <li>Subsystem: Sales</li>
            </ul><br />
            <h3>2. Rohan Matharu</h3>
            <p>git: crazyturtles</p>
            <ul>
                <li>Setup: Security</li>
                <li>Subsystem: Receiving</li>
            </ul><br />
            <h3>3. Akshit Kunwar</h3>
            <ul>
                <li>Subsystem: Rentals</li>
            </ul><br />
            <h3>4. Shanel Garcia</h3>
            <p>git: shanelgarcia</p>
            <ul>
                <li>Setup: #1 to #6 - Logo Creation, Default and About pages info, Repo setup, and VS solution setup(subfolders, nuget, site.master, etc)</li>
                <li>Subsystem: Purchasing</li>
            </ul><br />
            <hr /><br />
            <h2>Known Bug List</h2>
            <p>See KnownBugsList Folder for more details. Error details and solutions recorded in word document in the folder.</p>
            <ol>
                <li>Unable to clone a repository; Found by Arr; Solved by Arr</li> 
                <li>Missing nuget Microsoft.Owin.Security.Cookies; Found by Arr; Solved by Shanel</li>
                <li>WebStringsConnection.config is being ignored by VS; Found by Shanel; Solved by Shanel.</li>
            </ol>
        </div>
    </div>

</asp:Content>
