# Shared Components

As a group project, you will be working off of a single code base. You will need to divide up among your team-mates the work for the following shared components. Attempt to divide the work equally. Each person on the team needs to do at least one of the following components. **Any team member not participating in this work will receive a zero (0) for this part of the project.**

- Create the Solution with the class library project and web application. Ensure all NuGet packages are updated. Add the appropriate references in your Sysytem and web applicaton to other class library projects. Set the Target Framework (under Proprties) in both library and web application to 4.8. 
- Add navigation for your website in the Site.master page. Also modify the Site.master to replace the default application name with the identifier of your team and the name of the Team (e.g.: WebAppers - Team A). 
- Set up the connection string config file with values for your web application's DAL. The file name must be named WebConnectionStrings.config. Move the Default connection string in your web.config file to the WebConnectionStrings.config file (this connection string will be needed by security). Alter the connectionString tag in your web.config file to point to the WebConnectionStrings.config file.
- Generate the **entity classes** and **DbContext class** that maps to the project's database. Update any validation
annotations in your entities with appropriate custom error messages.
- Add common user controls to the web application using the NUGet packages FreeCode.Exceptions and FreeCode.WebApp. Also add information on the About.aspx page to list the following (under appropriate headings):
  - Team member names and (if possible) photos
  - Information about the default security roles (if any) and the default users and their passwords. Include any other relevant information about the security configurations for your site.
- Provide documentation about your project on the home page (Default.aspx) for the site. Include a logo for your team and show it on the home page as part of the page title. The documentation for your project must include the following:
  - List of your team members and the areas of the site that they were responsible for developing.
  - Identify which parts of the shared components each member was responsible for.
  - List of known bugs in your project, including portions of your lab that are incomplete. List these bugs under a heading that specifies the release version of your application (such as v 1.0.0 - Beta).
