using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Tests.Helpers
{
    public static class TestDataHelper
    {
        public static Developer CreateDeveloper(int id, string firstName, string lastName, string passwordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92")
        {
            return new Developer
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PasswordHash = passwordHash, // Valor por defecto
                Email = $"{firstName}.{lastName}@example.com",
                RoleId = 1, // Valor predeterminado
                IsActive = true
            };
        }

        public static Topic CreateTopic(int id, string title = "Default Title", string description = "Default Description")
        {
            return new Topic
            {
                Id = id,
                Title = title,
                Description = description,
                CategoryId = 1, // Asignar un valor predeterminado
                CreatedBy = 1,  // Asignar un desarrollador
                CreatedDate = DateTime.Now
            };
        }
    }


}
