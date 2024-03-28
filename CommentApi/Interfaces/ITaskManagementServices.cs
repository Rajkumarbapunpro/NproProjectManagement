﻿using SampleProjectMgmt.ResponseDTO;

namespace ProjectManagement.Interfaces
{
    public interface ITaskManagementServices
    {
        Task<List<TaskManagementDTO>> GetTaskDetails();
        Task<List<TaskManagementDTO>> GetTaskDetailById(int id);
        Task<TaskManagementDTO> SaveTaskDetail(TaskManagementDTO taskManagementDTO);
        Task DeleteTaskById(int id);
    }
}
