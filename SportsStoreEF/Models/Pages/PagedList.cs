using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models.Pages
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IQueryable<T> query, QueryOptions options = null)
        {
            CurrentPage = options.CurrentPage;
            PageSize = options.PageSize;

            // maximale Seitenanzahl = Anzahl Datensätze / Anzahl Datensätze pro Seite
            TotalPages = query.Count() / PageSize;
            // Überspringe (Aktuelle Seite - 1) * Maximalanzahl von Datensätzen pro Seite und
            // nehme davon die näschten maximal pro Seite erlaubten Datensätze.
            if(CurrentPage>=1)
            AddRange(query.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
