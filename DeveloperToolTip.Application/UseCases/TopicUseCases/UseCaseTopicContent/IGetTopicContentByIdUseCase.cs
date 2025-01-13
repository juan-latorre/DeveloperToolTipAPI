using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent
{
    public interface IGetTopicContentByIdUseCase
    {
        Task<TopicContentResponseDto> ExecuteAsync(int id);
    }
}
