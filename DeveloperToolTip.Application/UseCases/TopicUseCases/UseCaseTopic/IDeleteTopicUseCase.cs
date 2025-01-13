using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic
{
    public interface IDeleteTopicUseCase
    {
        Task ExecuteAsync(int topicId);
    }
}
