# SanaStore
SanaStore is a single-page application, built as a Demo for Sana. It was built using Visual Studio 2017 Community Edition, ASP.NET Core, using the available Angular template.

## Features
SanaStore is built with:

- [ASP.NET Core (MVC/WebAPI)](https://get.asp.net/) and [C#](https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx) for cross-platform server-side code
- [Angular](https://angular.io/) and [TypeScript](http://www.typescriptlang.org/) for client-side code
- [Webpack](https://webpack.github.io/) for building and bundling client-side resources
- [Bootstrap](http://getbootstrap.com/) for layout and styling

To help you get started, we've also set up:

- **Client-side navigation**. For example, click *Products* then *Back* to return here.
- **Server-side prerendering**. For faster initial loading and improved SEO, your Angular app is prerendered on the server. The resulting HTML is then transferred to the browser where a client-side copy of the app takes over.
- **Webpack dev middleware**. In development mode, there's no need to run the webpack build tool. Your client-side resources are dynamically built on demand. Updates are available as soon as you modify any file.
- **Hot module replacement**. In development mode, you don't even need to reload the page after making most changes. Within seconds of saving changes to files, your Angular app will be rebuilt and a new instance injected into the page.
- **Efficient production builds**. In production mode, development-time features are disabled, and the webpack build tool produces minified static CSS and JavaScript files.

## Instalation
To make sure that the application runs properly, first we must publish the database. SanaStore uses a SQL Server database by default to store data. The easiest way to create the database is done by using Visual Studio:

1. Open the Solution **SanaStore.sln** (VS2017).
2. From the Visual Studio 2017 interface, second-click on the Database project **SanaStore.Database** -> **Publicar** (My UI is in spanish, so please bare with me).
3. In the **publicar base de datos** dialog, select the target Database by clicking on **Editar**, and pick the database. If no database connections are available, you must forst add one using **Explorador de Servicios** -> **Conexiones de datos**.
![alt text](https://raw.githubusercontent.com/marcohern/SanaStore/master/images/publishDb.edit.png "Publish Databae . Edit")

4. After selecting the target connection, click on **Publicar**. This will begin the database creation process.

![alt text](https://raw.githubusercontent.com/marcohern/SanaStore/master/images/publishDb.publish.png "Publish Database . Publish")

5. Visual Studio will displays a log of the publishing process. By default, a **SanaStore** database is created if it does not exists. Tables are created as well.

![alt text](https://raw.githubusercontent.com/marcohern/SanaStore/master/images/publishDb.results.png "Publish database . Results")

6. Once publish is finished, make sure your Connection string is propperly set in the **/SanaStore/appsettings.json** file. An example of the connection string would be: *(local);Database=SanaStore;Trusted_Connection=True;MultipleActiveResultSets=true*

![alt text](https://raw.githubusercontent.com/marcohern/SanaStore/master/images/connString.png "Connection String")

6. Finally, click on the **> Ejecutar (IIS Express)** button to run the app.
