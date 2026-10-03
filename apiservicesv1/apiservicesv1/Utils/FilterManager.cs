using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Intrinsics.Arm;

namespace apiservicesv1.Utils
{
    public class FilterManager
    {
        public static string conditionsFilters<T>(Dictionary<string, string> filters)
        {
            //varible para el filtrado
            var filterConditions = filters
                .Select(filter =>
                {
                    if (filter.Key == RuleManager.FIELD_NAME_STATE)
                    {
                        string stateFilterValue = filter.Value;

                        return stateFilterValue == $"{RuleManager.DISABLED_STATE}" ? "" : $"{RuleManager.FIELD_NAME_STATE} = '{RuleManager.ACTIVE_STATE}'";
                    }
                    else
                    {
                        return $"{filter.Key} LIKE '%{filter.Value}%'";
                    }
                })
                .Where(condition => !string.IsNullOrEmpty(condition)); // Filtrar condiciones vacías

            if (filterConditions.Any())
            {
                return " WHERE " + string.Join(" AND ", filterConditions);
            }
            else
            {
                return string.Empty;
            }
        }

        public static Dictionary<string, string> GetFilters(HttpRequest request)
        {
            var filters = new Dictionary<string, string>();

            foreach (var query in request.Query)
            {
                var filterKey = query.Key;
                var filterValue = query.Value.ToString();

                filters[filterKey] = filterValue;
            }

            if (!filters.ContainsKey(RuleManager.FIELD_NAME_STATE))
            {
                filters[RuleManager.FIELD_NAME_STATE] = "A";
            }

            return filters;
        }
    }
}
