﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;

namespace DeveloperToolTip.Application.UseCases.DeveloperUseCases
{
    public interface IGetAllDevelopersUseCase
    {
        Task<IEnumerable<DeveloperDto>> ExecuteAsync();
    }
}
