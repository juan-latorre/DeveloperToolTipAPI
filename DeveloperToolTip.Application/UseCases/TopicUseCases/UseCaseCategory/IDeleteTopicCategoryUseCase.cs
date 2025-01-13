using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory
{
    public interface IDeleteTopicCategoryUseCase
    {
        Task ExecuteAsync(int categoryId);
    }
}
