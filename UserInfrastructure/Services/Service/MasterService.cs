using AutoMapper;
using Common.ViewModels;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class MasterService : IMasterService
    {
        public readonly IMasterRepository _masterRepository;
        private readonly IMapper _mapper;

        public MasterService(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<List<StatusResponse>> GetStatusAsync()
        {
            var status = await _masterRepository.GetStatusAsync();
            if (status != null)
            {
                return _mapper.Map<List<StatusResponse>>(status);
            }
            else
            {
                return null;
            }
        }

        public async Task<List<RoleResponse>> GetRoleAsync()
        {
            var role = await _masterRepository.GetRoleAsync();
            if (role != null)
            {
                return _mapper.Map<List<RoleResponse>>(role);
            }
            else
            {
                return null;
            }
        }
    }
}
