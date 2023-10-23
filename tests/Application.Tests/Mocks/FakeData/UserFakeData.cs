using System;
using System.Collections.Generic;
using Core.Security.Entities;
using Core.Test.Application.FakeData;

namespace Application.Tests.Mocks.FakeData;

public class UserFakeData : BaseFakeData<User, int>
{
    public override List<User> CreateFakeData()
    {
        int id = 0;
        List<User> data =
            new()
            {
                new User
                {
                    Id = ++id,
                    FirstName = "Deniz",
                    LastName = "Mert",
                    Email = "example@email.com",
                    PasswordHash = new byte[] { },
                    PasswordSalt = new byte[] { },
                    Status = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new User
                {
                    Id = ++id,
                    FirstName = "Derya",
                    LastName = "Yiğit",
                    Email = "example2@email.com",
                    PasswordHash = new byte[] { },
                    PasswordSalt = new byte[] { },
                    Status = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            };
        return data;
    }
}
