using BlogManagement.PostServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.PostServices
{
    public interface IPostService
    {
        Task<int> BlogAdd(PostServiceViewModel vm);
        Task<PostServiceViewModel> GetAll();
        Task<int> Edit(PostServiceViewModel model);
        Task<int> Delete(int id);
    }
}
