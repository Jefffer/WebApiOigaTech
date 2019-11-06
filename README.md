# WebApiOigaTech

Here you can find the Web Api for the project **WebApiEmployeesOigaTech**. This is consumed by the Angular project **_EmployeesViewOigaTech_**, equally available on my GitHub profile: https://github.com/Jefffer/EmployeesViewOigaTech

## Database creation

For Database creation, please run the script **_EmployeeOigaTech.sql_** located in this repository. This script was generated by SQL Server, it includes not only the scheme but also the information necessary to properly execute the application.

## Launch the App

To launch all the application correctly, you must clone both repositories and run them simultaneously on the appropriate port, please validate them in the corresponding files:

### For Angular project

Check the line `readonly rootURL = "http://localhost:57829/api"; // API connection` defined in the _employee.service.ts_.

### For Web Api project

Check the line `config.EnableCors(new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*"));` located in the file **_App_Start/WebApiConfig.cs_**.

