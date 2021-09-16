using ToDoApp.Core.Configuration;
using ToDoApp.Core.Models;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Core.Models.Responses;
using ToDoApp.Database.Entities;

namespace ToDoApp.Core.Mappings
{
    public static class Mappings
    {
        public static EmailMessage MapToEmailMessage(this UserEntity userEntity, PasswordRecoveryEmailTemplate template)
        {
            return new EmailMessage
            {
                Subject = template.Subject,
                Body = string.Format(template.Body, userEntity.Id),
                RecipientEmail = userEntity.Email
            };
        }

        public static ToDoItemEntity MapToToDoItemEntity(this CreateToDoItemRequest request, ToDoListEntity listEntity)
        {
            return new ToDoItemEntity
            {
                Name = request.Name,
                IsDone = request.IsDone,
                ToDoListEntity = listEntity
            };
        }

        public static CreateToDoItemResponse MapToCreateToDoItemResponse(this ToDoItemEntity entity)
        {
            return new CreateToDoItemResponse
            {
                Id = entity.Id,
                ListId = entity.ToDoListEntity.Id,
                Name = entity.Name,
                IsDone = entity.IsDone
            };
        }

        public static ReadToDoItemResponse MapToReadToDoItemResponse(this ToDoItemEntity entity)
        {
            return new ReadToDoItemResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                IsDone = entity.IsDone
            };
        }

        public static UpdateToDoItemResponse MapToUpdateToDoItemResponse(this ToDoItemEntity entity)
        {
            return new UpdateToDoItemResponse
            {
                ListId = entity.ToDoListEntity.Id,
                Id = entity.Id,
                Name = entity.Name,
                IsDone = entity.IsDone
            };
        }

        public static AuthenticateResponse MapToAuthenticateResponse(this UserEntity entity, string token)
        {
            return new AuthenticateResponse
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Token = token,
                Email = entity.Email
            };
        }

        public static User MapToUser(this UserEntity entity)
        {
            return new User
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role
            };
        }
    }
}
