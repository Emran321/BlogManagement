using BlogManagement.PostServices;
using BlogManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BlogManagement.Data;
using System.ComponentModel.Design;

namespace BlogManagement.PostServices
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> BlogAdd(PostServiceViewModel vm)
        {
            var result = -1;
            Posts obj = new Posts
            {
                Title = vm.Title,
                Content = vm.Content,
                Author = vm.Author,
                DateCreated = DateTime.Now
            };
            _context.Posts.Add(obj);

            if (await _context.SaveChangesAsync() > 0)
            {
                result = obj.PostId;
            }
            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = -1;
            if (id != 0)
            {
                Posts obj = await _context.Posts.FindAsync(id);
                obj.IsActive = false;
                if (await _context.SaveChangesAsync() > 0)
                {
                    result = obj.PostId;
                }
            }
            return result;
        }

        public async Task<int> Edit(PostServiceViewModel model)
        {
            var result = -1;
            Posts obj = await _context.Posts.FindAsync(model.PostId);
            obj.Title = model.Title;
            obj.Content = model.Content;
            obj.Author = model.Author;
            obj.DateCreated = DateTime.Now;

            if (await _context.SaveChangesAsync() > 0)
            {
                result = obj.PostId;
            }
            return result;
        }

        public async Task<PostServiceViewModel> GetAll()
        {
            PostServiceViewModel model = new PostServiceViewModel();

            model.BlogList = await Task.Run(() => (from t1 in _context.Posts
                                                   where t1.IsActive
                                                   select new PostServiceViewModel
                                                   {
                                                       PostId = t1.PostId,
                                                       Title = t1.Title,
                                                       Content = t1.Content,
                                                       Author = t1.Author,
                                                       DateCreated = t1.DateCreated
                                                   }
                                                 ).OrderBy(o => o.PostId).ThenBy(o => o.Title)
                                                 .AsEnumerable());
            return model;
        }


        public async Task<PostServiceViewModel> GetRecordById(int id)
        {
            var result = await _context.Posts.FindAsync(id);
            PostServiceViewModel model = new PostServiceViewModel();
            model.PostId = result.PostId;
            model.Title = result.Title;
            model.Content = result.Content;
            model.Author = result.Author;
            model.DateCreated = result.DateCreated;
            return model;
        }
    }
}