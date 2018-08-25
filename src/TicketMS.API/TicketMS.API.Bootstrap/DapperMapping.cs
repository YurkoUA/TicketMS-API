using System.Collections.Generic;
using Dapper;
using TicketMS.API.Data.Entity;

namespace TicketMS.API.Bootstrap
{
    internal static class DapperMapping
    {
        private static Dictionary<string, string> generalMaps = new Dictionary<string, string>
        {
            ["NominalId"] = "Id",

            ["ColorId"] = "Id",
            ["ColorName"] = "Name",

            ["SerialId"] = "Id",
            ["SerialName"] = "Name",

            ["PackageId"] = "Id",
            ["PackageName"] = "Name",

            ["TicketId"] = "Id"         
        };

        private static Dictionary<string, string> reportMaps = new Dictionary<string, string>
        {
            ["ReportId"] = "Id",
            ["DocumentId"] = "Id",
            ["TypeId"] = "Id"
        };

        internal static void ConfigureCustomMapping()
        {
            var mapper = CreateCustomMapper(generalMaps);

            SqlMapper.SetTypeMap(typeof(PackageEM), mapper);
            SqlMapper.SetTypeMap(typeof(TicketEM), mapper);

            ConfigureForReports();
        }

        private static void ConfigureForReports()
        {
            var mapper = CreateCustomMapper(reportMaps);
            SqlMapper.SetTypeMap(typeof(ReportEM), mapper);
            SqlMapper.SetTypeMap(typeof(ReportDocumentEM), mapper);
            SqlMapper.SetTypeMap(typeof(ReportTypeEM), mapper);
        }

        private static CustomPropertyTypeMap CreateCustomMapper(Dictionary<string, string> map)
        {
            return new CustomPropertyTypeMap(typeof(NominalEM), (type, columnName) =>
            {
                if (map.ContainsKey(columnName))
                    return type.GetProperty(map[columnName]);

                return type.GetProperty(columnName);
            });
        }
    }
}
