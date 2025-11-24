using Homework_8._09.DataBase.Models;
using Homework_8._09.Models.DTO;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.Service.Mappings
{
	internal class MapsterConfig
	{
		public static void Configure()
		{
			TypeAdapterConfig<CreateRequest, User>.NewConfig()
				.Map(dest => dest.Id, src => Guid.NewGuid())
				.Map(dest => dest.Login, src => src.Login.Trim())
				.Map(dest => dest.Password, src => src.Password) 
				.Map(dest => dest.Sex, src => src.Sex)
				.Map(dest => dest.RoleId, src => src.RoleId)
				.Map(dest => dest.PositionId, src => src.PositionId)
				.Map(dest => dest.CreatedAt, src => DateTime.UtcNow)
				.Map(dest => dest.UpdatedAt, src => DateTime.UtcNow);
				

			TypeAdapterConfig<UpdateRequest, User>.NewConfig()
				.IgnoreNullValues(true)                   
				.Map(dest => dest.Login, src => src.Login == null ? src.Login : src.Login.Trim())
				.Map(dest => dest.UpdatedAt, src => DateTime.UtcNow)
				;

			TypeAdapterConfig<LoginRequest, User>.NewConfig()
				.Map(dest => dest.Login, src => src.Login.Trim())
				.Map(dest => dest.Password, src => src.Password)
				;
		}
	}
}
