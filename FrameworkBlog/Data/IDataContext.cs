using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.API.Data
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Album> Albums { get; set; }
        DbSet<Photo> Photos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
