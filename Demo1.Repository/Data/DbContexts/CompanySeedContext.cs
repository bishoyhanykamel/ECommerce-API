using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Repository.Data.DbContexts
{
    public class CompanySeedContext
    {
        public static async Task SeedAsync(CompanyContext context, ILoggerFactory loggerFactory)
        {   
            await context.SaveChangesAsync();
        }
    }
}
