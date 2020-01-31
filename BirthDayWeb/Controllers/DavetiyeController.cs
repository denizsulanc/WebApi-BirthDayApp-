using BirthDayWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BirthDayWeb.Controllers
{
    public class DavetiyeController : ApiController
    {
        [HttpGet] //[HttpGet] dediğimiz anda api/{controller}/{id} ile ulaştığımızda bu action'ı çağırır yoksa bilemez 
        //Eğer bunu yazmazsak aynı işlevi gören Action adının başına Get yazılır şu şekilde => GetKatilanlar
        public IEnumerable<DavetiyeModel> Katilanlar()
        {
            //Bu yapı kullanıcıya xml veya json formatta veri gönderir ama view döndürmez
            return VeriTabani.Liste.Where(i => i.KatilmaDurumu == true);
        }
        public IEnumerable<DavetiyeModel> GetKatilmayanlar()
        {
            //Eğer iki tane Get özelliği olan Action'ımız varsa WebApiConfig.cs'e api/{controller}/{action}/{id} yazmamız gerekir 
            return VeriTabani.Liste.Where(i => i.KatilmaDurumu == false);
        }
        [HttpPost] //Bu action'a veri göndermek istediğimizde kullanırız
        //Eğer bunu yazmazsak aynı işlevi gören Action adının başına Post yazılır şu şekilde => PostEkle
        public void Ekle(DavetiyeModel model)//Postman chrome eklentisi kullanarak veri ekleyebiliyoruz
        {
            if (ModelState.IsValid) //model alanlarına bilgi atarken bütün kuralları göz önünde bulundurmamız gerek
            {
                VeriTabani.Add(model);
            }
        }
    }
}
