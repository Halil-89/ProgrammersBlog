using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Mvc.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Mvc.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var searchResult = await _articleService.SeachAsync(keyword, currentPage, pageSize, isAscending);
            if (searchResult.ResultStatus == ResultStatus.Succes)
            
                return View(new ArticleSearchViewModel
                {
                    ArticleListDto = searchResult.Data,
                    Keyword = keyword
                });
                return NotFound();
        }
      
        [HttpGet]
        public async Task<IActionResult> Detail(int articleId)
        {
            var articleResult = await _articleService.GetAsync(articleId);
            if (articleResult.ResultStatus==ResultStatus.Succes)
            {
                var userArtices = await _articleService.GetAllByUserIdOnFilter(articleResult.Data.Article.UserId,
                    FilterBy.Category, OrderBy.Date, false, 10, articleResult.Data.Article.CategoryId, DateTime.Now,
                    DateTime.Now, 0, 9999, 0, 9999);
                await _articleService.IncreaseViewCountAsync(articleId);
                return View(new ArticleDetailViewModel
                {
                    ArticleDto= articleResult.Data,
                    ArticleDetailRightSideBar=new ArticleDetailRightSideBarViewModel
                    {
                        ArticleListDto=userArtices.Data,
                        Header="Kullanıcının Aynı Katagori Üzerimdeki En Çok Okunan Makaleleri",
                        User=articleResult.Data.Article.User
                    }
                });
            }
            return NotFound();
        }
    }
}
