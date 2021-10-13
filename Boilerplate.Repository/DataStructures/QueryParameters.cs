using System.ComponentModel;

namespace Boilerplate.Repository.DataStructures {
    public class QueryParameters {
        private const int MaxPageSize = 1000;
        private int _pageSize = 30;
        
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        
        [DefaultValue(10)]
        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        
        [Description("Order by string")]
        public string OrderBy { get; set; }
    }
}