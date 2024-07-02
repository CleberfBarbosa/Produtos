using Dominio.Interfaces;

namespace Dominio.Properties
{
    public class DatabaseProperties
    {
        public string ConnectionString { get; set; }

        public const string SectionName = "DatabaseProperties";
    }
}
