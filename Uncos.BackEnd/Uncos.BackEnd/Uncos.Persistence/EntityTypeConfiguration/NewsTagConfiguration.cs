using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Domain;

namespace Uncos.Persistence.EntityTypeConfiguration
{
    public class NewsTagConfiguration : IEntityTypeConfiguration<NewsTag>
    {
        public void Configure(EntityTypeBuilder<NewsTag> builder)
        {
            builder.HasOne(nt => nt.News)
                   .WithMany(n => n.NewsTags)
                   .HasForeignKey(nt => nt.NewsId);

            builder.HasOne(nt => nt.Tag)
                   .WithMany(t => t.NewsTags)
                   .HasForeignKey(nt => nt.TagId);
        }
    }
}
