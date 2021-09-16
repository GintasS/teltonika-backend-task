using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using ToDoApp.Core.Configuration;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Services;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;
using Xunit;

namespace ToDoApp.UnitTests.ServiceTests
{
    public class JwtServiceTests
    {
        private readonly IJwtService _jwtService;
        private readonly UserEntity _userEntity;

        public JwtServiceTests()
        {
            var jwtOptionsMock = new Mock<IOptionsMonitor<JwtSettings>>();
            jwtOptionsMock.Setup(x => x.CurrentValue)
                .Returns(new JwtSettings
                {
                    Secret = "TEST SECRET TEST SECRET",
                    TokenGeneration = new TokenGeneration()
                    {
                        ClaimType = "id",
                        DaysUntilExpiration = 7,
                        HashingAlgorithm = @"http://www.w3.org/2001/04/xmldsig-more#hmac-sha256"
                    }
                });


            _jwtService = new JwtService(jwtOptionsMock.Object);

            _userEntity = new UserEntity
            {
                Email = "test@email.com",
                FirstName = "John",
                Id = 1,
                LastName = "Johnny",
                Password = "123",
                Role = Role.Admin
            };
        }

        [Fact]
        public void Should_Generate_Jwt_Token()
        {
            // When
            var result = _jwtService.GenerateToken(_userEntity);

            // Then
            result.Should().NotBeNull();
            result.Length.Should().Be(163);
            result.Should().StartWith("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9");
        }
    }
}
