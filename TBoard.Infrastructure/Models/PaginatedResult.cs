using System.Collections.Generic;

namespace TBoard.Infrastructure.Models
{
    public class PaginatedResult<PlayerDto> 
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IList<PlayerDto> Items { get; set; }
    }
}
