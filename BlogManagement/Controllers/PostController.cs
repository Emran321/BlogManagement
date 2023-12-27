using BlogManagement.PostServices;
using BlogManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogManagement.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }



        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await _postService.GetAll();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Index(PostServiceViewModel vm)
        {
            if (vm.ActionEum == ActionEnum.Add)
            {
                //Add 
                await _postService.BlogAdd(vm);
            }
            else if (vm.ActionEum == ActionEnum.Edit)
            {
                //Edit
                await _postService.Edit(vm);
            }           
            else
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _postService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var res = await _postService.GetRecordById(id);
            return PartialView("_DetailsPartialView", res);
        }

    }
}