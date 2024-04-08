using AutoMapper;
using OnlineNewsWebApp.Core.ViewModels.Category;
using OnlineNewsWebApp.Core.ViewModels.Comment;
using OnlineNewsWebApp.Core.ViewModels.Post;
using OnlineNewsWebApp.Core.ViewModels.Role;
using OnlineNewsWebApp.Core.ViewModels.Tag;
using OnlineNewsWebApp.Core.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using OnlineNewsWebApp.Core.Entities;

namespace OnlineNewsWebApp.Infrastructure.Mapper
{
    // Map the properties of entity models to their viewmodels
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Post, PostViewModel>()
                .ForMember(
                pvm => pvm.Tags, m => m.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.Tag))
                )
                .ForMember(
                pvm => pvm.AuthorName, m => m.MapFrom(a => a.Author.LastName + " " + a.Author.FirstName)
                );
            CreateMap<Post, PostAdminViewModel>()
                .ForMember(
                pvm => pvm.AuthorName, m => m.MapFrom(a => a.Author.LastName + " " + a.Author.FirstName)
                );
            CreateMap<Post, PostDetailsViewModel>().ForMember(
                pdvm => pdvm.Tags, m => m.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.Tag))
                )
                .ForMember(
                pvm => pvm.AuthorName, m => m.MapFrom(a => a.Author.LastName + " " + a.Author.FirstName)
                );
            CreateMap<Tag, TagViewModel>();
            CreateMap<Tag, TagToUpdateViewModel>();
            CreateMap<TagToUpdateViewModel, Tag>();
            CreateMap<CategoryToCreateViewModel, Category>();
            CreateMap<CategoryToUpdateViewModel, Category>();
            CreateMap<Category, CategoryToUpdateViewModel>();
            CreateMap<Comment, CommentToUpdateViewModel>();
            CreateMap<CommentToUpdateViewModel, Comment>();
            
            CreateMap<Post, PostToUpdateViewModel>()
                .ForMember(
                p => p.TagIds, epvm => epvm.MapFrom(p => p.PostTagMaps.Select(ptm => ptm.TagId))
                );
            CreateMap<PostToUpdateViewModel, Post>();
            CreateMap<Category, CategoryDetailsViewModel>();
            CreateMap<Comment, CommentDetailsViewModel>()
                .ForMember(
                c => c.Post, cdvm => cdvm.MapFrom(c => c.Post.Title)
                );
            CreateMap<Tag, TagDetailsViewModel>();
            CreateMap<RoleViewModel, IdentityRole>();
            CreateMap<IdentityRole, RoleViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<NewUserViewModel, User>();
            CreateMap<RoleToCreateViewModel, IdentityRole>();
            CreateMap<User, UserDetailsViewModel>();
            CreateMap<UserDetailsViewModel, EditUserViewModel>()
                .ForMember(
                euvm => euvm.RoleIds, m => m.MapFrom(udvm => udvm.Roles.Select(r => r.Id))
                );
            CreateMap<EditUserViewModel, User>();
        }
    }
}
