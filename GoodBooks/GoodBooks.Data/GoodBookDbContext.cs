using System;
using Microsoft.EntityFrameworkCore;

namespace GoodBooks.Data
{
    public class GoodBookDbContext : DbContext{
    
    public GoodBookDbContext(){}

    public GoodBookDbContext(DbContextOptions options) : base(options){}
    

    public virtual DbSet<Book> Books{get;set;}
    public virtual DbSet<BookReview> BookReviews {get;set;}

    

    }
}
