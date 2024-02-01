namespace DasherApp.Model.Helper
{
    public class PaginationParams
    {
        private const int MAX_PAGE_SIZE = 500;
        private int _pageSize = 100;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
        }
    }
}
