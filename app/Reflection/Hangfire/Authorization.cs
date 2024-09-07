using System.Diagnostics.CodeAnalysis;
using Hangfire.Dashboard;

namespace Reflection.Hangfire;

public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            //Can use this for NetCore
            return true; 
        }
    }