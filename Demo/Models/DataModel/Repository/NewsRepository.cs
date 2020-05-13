using Demo.Models.DataModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.DataModel.Repository
{
    public class NewsRepository : GenericRepository<NewsContext, NewsEntity>
    {
    }
}
