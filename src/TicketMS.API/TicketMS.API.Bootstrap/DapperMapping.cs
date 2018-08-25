using System;
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
            ConfigureMappers(generalMaps, typeof(NominalEM), typeof(ColorEM), typeof(SerialEM), typeof(PackageEM), typeof(TicketEM));
            ConfigureMappers(reportMaps, typeof(ReportEM), typeof(ReportDocumentEM), typeof(ReportTypeEM));
        }

        private static void ConfigureMappers(Dictionary<string, string> map, params Type[] types)
        {
            foreach (var t in types)
            {
                SqlMapper.SetTypeMap(t, CreateMapper(t, map));
            }
        }

        private static CustomPropertyTypeMap CreateMapper(Type type, Dictionary<string, string> map)
        {
            return new CustomPropertyTypeMap(type, (t, columnName) =>
            {
                if (map.ContainsKey(columnName))
                    return t.GetProperty(map[columnName]);

                return t.GetProperty(columnName);
            });
        }
    }
}
