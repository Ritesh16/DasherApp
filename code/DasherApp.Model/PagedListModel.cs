namespace DasherApp.Model
{
    public class PagedListModel<T> : List<T>
    {
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }

        public PagedListModel()
        {

        }

        public PagedListModel(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public static PagedListModel<T> Create(IEnumerable<T> source, int pageNumber,
                                int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedListModel<T>(items, count, pageNumber, pageSize);
        }
    }
}
