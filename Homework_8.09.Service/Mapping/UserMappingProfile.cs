using AutoMapper;
using Homework_8._09.DataBase.Models;
using Homework_8._09.DataBase.Scheme;
using Homework_8._09.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.Service.Mapping
{
	public class UserMappingProfile : Profile
	{
		public UserMappingProfile()
		{
			this.CreateMap<CreateRequest, User>();
			this.CreateMap<UpdateRequest, User>();
			this.CreateMap<LoginRequest, User>();
		}
	}
}
