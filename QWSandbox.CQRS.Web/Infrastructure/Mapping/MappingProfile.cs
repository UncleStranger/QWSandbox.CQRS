using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QWSandbox.CQRS.Domain.Models.User;
using QWSandbox.CQRS.Web.Infrastructure.Mediator.User;
using QWSandbox.CQRS.Web.Models.Home;

namespace QWSandbox.CQRS.Web.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserViewModel>();
                //.ForAllMembers(x => x.Ignore());

            CreateMap<UserViewModel, UserModel>()
                .ForMember(x => x.CreatedAt, x => x.Ignore())
                .ForMember(x => x.CreatedBy, x => x.Ignore())
                .ForMember(x => x.UpdatedAt, x => x.Ignore())
                .ForMember(x => x.UpdatedBy, x => x.Ignore());

            CreateMap<AddUserRequest, UserModel>();
        }
    }
}
