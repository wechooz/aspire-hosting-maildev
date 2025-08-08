var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApplication>("webapplication")
    ;

builder.AddMailDev("mail", credentials: new(builder.AddParameter("test"), builder.AddParameter("test2", "password"))
    );

builder.Build().Run();
