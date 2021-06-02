using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.MAP.Configurations
{
    //Sakın aşağı taraftaki T constraint'ini ya class ya da IEntity olabilir diye düsünmeyin. Burada demek istediğimiz Constraint hem class hem IEntity olmalıdır. (ikisi birlikte) (&& operatörü gibi düsün) 
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}
