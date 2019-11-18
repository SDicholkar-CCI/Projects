using Serilog;
using Serilog.Sinks.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScratchCardApp.ErrorHandling
{
    public static class ApplicationError
    {
        public static void LogConfigurations()
        {
            var logger = Log.Logger = new LoggerConfiguration()
                                      .WriteTo.Console()
                                      .WriteTo.File("D:\\Directory\\logs.txt", rollingInterval: RollingInterval.Day)
                                      .WriteTo.Email(new EmailConnectionInfo {
                                                        FromEmail = "itsupport@creativecapsule.com",
                                                        ToEmail  = "swapnil.dicholkar@creativecapsule.com",
                                                        MailServer = "zuari.creativecapsule.local",
                                                        EmailSubject = "Exception Details of Scratch Card App",
                                                        EnableSsl = false,
                                                        Port = 25
                                                        },
                                                        restrictedToMinimumLevel : Serilog.Events.LogEventLevel.Fatal                                                    
                                                    )
                                      .CreateLogger();
        }
    }
}