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
    
    public async Task Handle_ShouldReturnTweetResponse()
    {
        
    }

}