using AutoMapper;
using Infrastructure.Data.Model;
using WebAPI.ViewModels;

namespace WebAPI.Mappings {
    public class DefaultProfile : Profile
    {
        public DefaultProfile() {
            CreateMap<Page, PageViewModel>();
            CreateMap<Comment, CommentViewModel>();
        }
    }
}
