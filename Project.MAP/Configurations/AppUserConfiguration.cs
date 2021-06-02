using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.MAP.Configurations
{
    public class AppUserConfiguration:BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Profile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.ID); //1e1 ilişki ayarı

            //Bizim AppUser class'ımızın bizim yazdığımız property'lerin yanı sıra Microsoft'un Identity kütüphanesinden gelen property'leri de içerecektir... Identity'den gelen bu property'lerin içerisinde primary key olan ve Id ismine sahip olan bir property daha olacaktır. DOlayısıyla bu class tabloya çevrilirken hem bizim ID property'imiz hem de Identity'nin gönderdiği Id property'si Sql'daki Incasesensitive durum yüzünden aynı sütun sayılarak size migration durumunda bir tabloda aynı isimde iki sütun olamaz diye hata çıkaracaktır... Dolayısıyla bizim burada ID'imiz C#'ta kalsa da onu (kendi ID'imizi) Sql'e göndermemiz gerekecektir... 
            builder.Ignore(x => x.ID);
        }
    }
}
