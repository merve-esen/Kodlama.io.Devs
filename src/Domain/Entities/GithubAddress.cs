﻿using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class GithubAddress : Entity<int>
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public virtual User User { get; set; }

    public GithubAddress()
    {
    }

    public GithubAddress(int id, int userId) : this()
    {
        Id = id;
        UserId = userId;
    }
}
