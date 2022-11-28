using AutoMapper;
using WebApplication5.Entities;
using WebApplication5.Models;

namespace WebApplication5
{
    public class AutoMapperConfig: Profile
    {  
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, EditUserModel>().ReverseMap();
        }
    }
}
//AutoMapper dosyasındaki gibi Profile classından miras almış classları içeren assembly'lerini, proje dosyalarını söyle
//onların içi gezilecek profile class'ı almış classları bulunacak constructorlarnı çalıştırıp maplemeyi tetikleyecek