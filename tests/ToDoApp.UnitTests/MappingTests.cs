using FluentAssertions;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Mappings;
using ToDoApp.Core.Models.Requests;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;
using Xunit;

namespace ToDoApp.Tests
{
    public class MappingTests
    {
        private readonly UserEntity _userEntity;
        private readonly ToDoItemEntity _toDoItemEntity;

        public MappingTests()
        {
            _userEntity = new UserEntity
            {
                Email = "test@email.com",
                FirstName = "John",
                Id = 1,
                LastName = "Johnny",
                Password = "123",
                Role = Role.Admin
            };

            _toDoItemEntity = new ToDoItemEntity
            {
                Id = 1,
                Name = "Test",
                IsDone = false,
                ToDoListEntity = new ToDoListEntity()
                {
                    Id = 1
                }
            };
        }

        [Fact]
        public void Should_Map_UserEntity_To_EmailMessage()
        {
            // Given
            var passwordRecoveryEmailTemplate = new PasswordRecoveryEmailTemplate
            {
                Subject = "My Subject",
                Body = "{0}/test"
            };

            // When
            var emailMessage = _userEntity.MapToEmailMessage(passwordRecoveryEmailTemplate);

            // Then
            emailMessage.Should().NotBeNull();
            emailMessage.Subject.Should().Be(passwordRecoveryEmailTemplate.Subject);
            emailMessage.Body.Should().Be(_userEntity.Id + "/test");
            emailMessage.RecipientEmail.Should().Be(_userEntity.Email);
        }

        [Fact]
        public void Should_Map_CreateToDoItemRequest_To_ToDoItemEntity()
        {
            // Given
            var request = new CreateToDoItemRequest
            {
                Name = "My Todo Item",
                IsDone = false
            };

            var toDoListEntity = new ToDoListEntity();

            // When
            var toDoItemEntity = request.MapToToDoItemEntity(toDoListEntity);

            // Then
            toDoItemEntity.Should().NotBeNull();
            toDoItemEntity.Name.Should().Be(request.Name);
            toDoItemEntity.IsDone.Should().Be(request.IsDone);
            toDoItemEntity.ToDoListEntity.Should().BeSameAs(toDoListEntity);
        }

        [Fact]
        public void Should_Map_ToDoItemEntity_To_CreateToDoItemResponse()
        {
            // When
            var response = _toDoItemEntity.MapToCreateToDoItemResponse();

            // Then
            response.Should().NotBeNull();
            response.Id.Should().Be(_toDoItemEntity.Id);
            response.Name.Should().Be(_toDoItemEntity.Name);
            response.IsDone.Should().Be(_toDoItemEntity.IsDone);
            response.ListId.Should().Be(_toDoItemEntity.ToDoListEntity.Id);
        }

        [Fact]
        public void Should_Map_ToDoItemEntity_To_ReadToDoItemResponse()
        {
            // When
            var response = _toDoItemEntity.MapToReadToDoItemResponse();

            // Then
            response.Should().NotBeNull();
            response.Id.Should().Be(_toDoItemEntity.Id);
            response.Name.Should().Be(_toDoItemEntity.Name);
            response.IsDone.Should().Be(_toDoItemEntity.IsDone);
        }

        [Fact]
        public void Should_Map_ToDoItemEntity_To_UpdateToDoItemResponse()
        {
            // When
            var response = _toDoItemEntity.MapToUpdateToDoItemResponse();

            // Then
            response.Should().NotBeNull();
            response.Id.Should().Be(_toDoItemEntity.Id);
            response.Name.Should().Be(_toDoItemEntity.Name);
            response.IsDone.Should().Be(_toDoItemEntity.IsDone);
            response.ListId.Should().Be(_toDoItemEntity.ToDoListEntity.Id);
        }

        [Fact]
        public void Should_Map_UserEntity_To_AuthenticateResponse()
        {
            // Given
            var token = "token";
                
            // When
            var response = _userEntity.MapToAuthenticateResponse(token);

            // Then
            response.Should().NotBeNull();
            response.Id.Should().Be(_toDoItemEntity.Id);
            response.FirstName.Should().Be(_userEntity.FirstName);
            response.LastName.Should().Be(_userEntity.LastName);
            response.Token.Should().Be(token);
            response.Email.Should().Be(response.Email);
        }

        [Fact]
        public void Should_Map_UserEntity_To_User()
        {
            // When
            var user = _userEntity.MapToUser();

            // Then
            user.Should().NotBeNull();
            user.Id.Should().Be(_userEntity.Id);
            user.FirstName.Should().Be(_userEntity.FirstName);
            user.LastName.Should().Be(_userEntity.LastName);
            user.Email.Should().Be(_userEntity.Email);
            user.Password.Should().Be(_userEntity.Password);
            user.Role.Should().Be(_userEntity.Role);
        }


    }
}
