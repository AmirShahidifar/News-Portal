using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Entities
{
    public class NewsCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<News> NewsItems { get; set; } = new List<News>();
    }

}