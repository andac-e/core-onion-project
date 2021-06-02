using Microsoft.AspNetCore.Identity;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {

        //Sizin kendinize özel Crud işlemleri yine saklanır... Ancak unutmayın ki Identity yapısının özel şifrelemeler ve yetkilendirmeleri için hazır async metotları vardır... Bu metotların kullanımı için ekstra olarak bu Repository'de ayrı alanlar açmak en doğrusudur... 
        // Bu metotlar Manager sınıfları içinde bulunur(UserManager, SignInManager Identity'de gömülü olan sınıflardır) Bu sınıflar Dependency Injection ile çalışırlar... Ve constructor based injection yapılabilir... 

        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public AppUserRepository(MyContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //Özel bir Identity Metodu async şeklinde tanımlanmalıdır.. Çünkü siz burada sonuçta bir API kullanıyorsunuz.. Ve bu API requestlerin blocklanmadan beklenmesi için await keyword'unu kullanmanız gerekir... Bir metot içerisinde await keyword'unu kullanabilmeniz için o metodun async tanımlanması gerekir ve Task döndürmesi gerekir... 

        public async Task<bool> AddUser(AppUser item)
        {
            //Sadece Asenkron olarak yaratılmış metotlar içinde await kullanabilirsiniz...

            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(item, isPersistent: false); //isPersistent durumu cookie'de dursun mu durmasın mı 
                return true;
            }
            return false;
        }
    }
}
