using Demo.Models.DataModel.News;
using Demo.Models.DataModel.Repository;
using Demo.Models.DataModel.User;
using Demo.Models.ViewModel;
using Demo.Util;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class NewsService
    {
        private NewsRepository newsRepository;
        public NewsService()
        {
            newsRepository = new NewsRepository();
        }
        public List<NewsEntity> GetAllNews()
        {
            return newsRepository.GetAll().ToList();
        }

        public NewsEntity GetNews(string id)
        {
            try
            {
                NewsEntity newsEntity = newsRepository.FindBy(e => e.Id == Int32.Parse(id)).First();
                if (newsEntity != null)
                    return newsEntity;
            } catch(Exception e)
            {
                throw e;
            }
            return null;
        }

        public bool DeleteNews(string id)
        {
            NewsEntity newsEntity = new NewsEntity() { Id = Int32.Parse(id) };
            try
            {
                newsRepository.Delete(newsEntity);
                newsRepository.Save();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public bool EditNews(EditNewsViewModel model, string id)
        {
            try
            {
                NewsEntity newsEntity = GetNews(id);
                newsEntity.Title = model.Title;
                newsEntity.Content = model.Content;
                newsEntity.Category = model.Category;
                newsRepository.Edit(newsEntity);
                newsRepository.Save();
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        public async Task<NewsEntity> CreateNews(CreateNewsViewModel model, string userName)
        {
            try
            {
                long timestamp = TimeUtil.GetNowTimeStamp();
                NewsEntity newsEntity = new NewsEntity()
                {
                    Title = model.Title,
                    Content = model.Content,
                    Category = model.Category,
                    CreatedAt = timestamp,
                    Author = userName
                };
                NewsEntity result = await newsRepository.Add(newsEntity);
                newsRepository.Save();
                return result;
            } catch(Exception)
            {
                return null;
            }
        }
    }
}
