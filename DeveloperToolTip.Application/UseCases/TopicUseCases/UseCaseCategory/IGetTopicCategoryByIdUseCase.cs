﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory
{
    public interface IGetTopicCategoryByIdUseCase
    {
        Task<TopicCategoryDto> ExecuteAsync(int id);
    }
}
