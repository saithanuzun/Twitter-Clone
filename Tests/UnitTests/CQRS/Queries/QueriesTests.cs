using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;
using Xunit;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Twitter.Backend.Application.Features.Commands.Tweet.Create;
using Twitter.Backend.Application.Features.Queries.User.GetUser;

namespace UnitTests.CQRS.Queries;

public class QueriesTests
{
    [Fact]
    public async Task Handle_ShouldReturnMappedResponse_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User
        {
            Id = userId,
            Username = "john.doe",
            Email = "john@example.com",
            PasswordHash = "123",
            Profile = new UserProfile
            {
                FirstName = "John",
                LastName = "Doe",
                Bio = "Developer",
                Location = "Earth",
                ImageUrl = "http://image.url/avatar.png",
                UserId = userId
            },
            CreatedDate = DateTime.UtcNow,
        };

        var response = new GetUserResponse
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.Profile.FirstName,
            LastName = user.Profile.LastName,
            CreatedDate = user.CreatedDate,
            Bio = user.Profile.Bio,
            Location = user.Profile.Location,
            ImageUrl = user.Profile.ImageUrl
        };

        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(
                userId,
                true,
                It.IsAny<Expression<Func<User, object>>[]>()
            ))
            .ReturnsAsync(user);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<GetUserResponse>(user)).Returns(response);

        var handler = new GetUserHandler(mockRepo.Object, mockMapper.Object);
        var query = new GetUserRequest { Id = userId };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(response.Id, result.Id);
        Assert.Equal(response.Username, result.Username);
        Assert.Equal(response.Email, result.Email);

        mockRepo.Verify(r => r.GetByIdAsync(
            userId,
            true,
            It.IsAny<Expression<Func<User, object>>[]>()), Times.Once);
        mockMapper.Verify(m => m.Map<GetUserResponse>(user), Times.Once);
    }
    
    public async Task Handle_ShouldReturnTweetResponse()
    {
        
    }

}