using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestDeveloper.Services.Infraestructure
{
    public static class Extensions
    {
        private static IConfigurationRoot confiSetting;

        public static DbContextOptions<TContext> GetConnection<TContext>(this string connectionStringName, string nameFileSettings = "") where TContext : DbContext
        {
            try
            {
                return new DbContextOptionsBuilder<TContext>().UseSqlServer(connectionStringName.ToString().GetStringConnections(nameFileSettings)).Options;
            }
            catch (Exception ex)
            {
                throw new Exception($"La cadena de conexión {connectionStringName} presenta la siguiente falla {ex.Message}");
            }
        }

        public static string GetStringConnections(this string connectionStringName, string nameFileSettings)
        {
            if (confiSetting == null)
            {
                confiSetting = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile(nameFileSettings == string.Empty ? "appsettings.json" : nameFileSettings)
               .Build();
            }

            return confiSetting.GetConnectionString(connectionStringName.ToString());
        }
    }
}
