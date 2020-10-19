using System;
using System.Collections.Generic;
using System.Text;

namespace ODZ.Services
{
    public interface IArticleService
    {
        public int CreateArticle(string name, string descripton, string imgUrl);

    }
}
