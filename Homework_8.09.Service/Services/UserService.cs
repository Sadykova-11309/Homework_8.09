using AutoMapper;
using Homework_8._09.DataBase.Models;
using Homework_8._09.DataBase.Repository.Extensions;
using Homework_8._09.DataBase.Scheme;
using Homework_8._09.Models.DTO;

namespace Homework_8._09.Service.Services
{
	public class UserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<User> Create(CreateRequest createrequest)
		{
			var userEntity = _mapper.Map<User>(createrequest);
			userEntity = await _userRepository.CreateAsync(userEntity);
			return userEntity;
		}

		public async Task<User> Update(Guid id, UpdateRequest updateRequest)
		{
			var existingUser = await _userRepository.GetByIdAsync(id);
			if (existingUser == null) { return null; }
			_mapper.Map(updateRequest, existingUser);
			existingUser = await _userRepository.UpdateAsync(existingUser);
			return existingUser;
		}

		public async Task<bool> Delete (Guid Id)
		{
			return await _userRepository.DeleteAsync(Id);
		}

		public async Task<User> GetByCredentials(LoginRequest loginRequest)
		{
			var userForSearch = _mapper.Map<User>(loginRequest);

			var userEntity = await _userRepository.GetByCredentialsAsync(
				userForSearch.login,
				userForSearch.password);
			return userEntity;
		}

		public async Task<List<User>> GetAll ()
		{
			return await _userRepository.GetAllAsync();
		}

		public async Task<List<User>> GetByTimePeriodForCreated (DateTime beginingTime, DateTime endingTime)
		{
			return await _userRepository.GetByTimePeriodForCreatedAsync(beginingTime, endingTime);
		}

		public async Task<List<User>> GetByTimePeriodForUpdated(DateTime beginingTime, DateTime endingTime)
		{
			return await _userRepository.GetByTimePeriodForUpdatedAsync(beginingTime, endingTime);
		}

		public async Task<List<User>> GetSortedBySex(int sex)
		{
			return await _userRepository.SortedBySexAsync(sex);
		}

		public async Task<int> GetCount () { return await _userRepository.GetCountAsync(); }

		public async Task<DateTime?> GetMaxDateTime()
		{
			return await _userRepository.GetMaxCreatedAtAsync();
		}

		public async Task<DateTime?> GetMinDateTime()
		{
			return await _userRepository.GetMinCreatedAtAsync();
		}
	}
}
