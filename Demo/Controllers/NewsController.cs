using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.DataModel.News;
using Demo.Models.DataModel.Repository;
using Demo.Models.ViewModel;
using Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class NewsController : Controller
    {
        private NewsService newsService;
        public NewsController()
        {
            newsService = new NewsService();
        }

        public IActionResult Index()
        {
            List<NewsEntity> newsEntities = newsService.GetAllNews();
            return View(newsEntities);
        }

        public IActionResult Detail(string id)
        {
            NewsEntity newsEntity = newsService.GetNews(id);
            return View(newsEntity);
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            NewsEntity newsEntity = newsService.GetNews(id);
            EditNewsViewModel model = new EditNewsViewModel()
            {
                Title = newsEntity.Title,
                Content = newsEntity.Content,
                Category = newsEntity.Category
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(EditNewsViewModel model, string id)
        {
            bool succeed = newsService.EditNews(model, id);
            if(!succeed)
            {
                ModelState.AddModelError("", "We could not save your news now, please try later");
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(string id)
        {
            bool succeed = newsService.DeleteNews(id);
            if(succeed)
            {
                return View();
            }
            return RedirectToAction("Detail", new { id });
        }

        [Authorize]
        public IActionResult Create()
        {
            CreateNewsViewModel model = new CreateNewsViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsViewModel model)
        {
            NewsEntity newsEntity = await newsService.CreateNews(model, User.Identity.Name);
            return RedirectToAction("Detail", new { id = newsEntity.Id });
        }
    }
}