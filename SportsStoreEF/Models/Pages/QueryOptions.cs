using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models.Pages
{
    // Optionen mit denen die Darstellung der Anfrageergebnisse eingestellt werden.
    // CurrentPage = Seitenzahl die standartmäßig angezeigt werden soll nach der Anfrage.
    // PageSize = Anzahl der Einträge pro Seite.
    public class QueryOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string OrderPropertyName { get; set; }
        public bool DescendingOrder { get; set; }

        public string SearchPropertyName { get; set; }
        public string SearchTerm { get; set; }
    }
}
