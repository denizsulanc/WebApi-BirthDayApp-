using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthDayWeb.Models
{
    public static class VeriTabani
    {
        private static Dictionary<string, DavetiyeModel> _liste; //key ve değer tutar

        static VeriTabani()
        {
            _liste = new Dictionary<string, DavetiyeModel>();

            _liste.Add("Deniz", new DavetiyeModel
            {
                Ad = "Deniz",
                Eposta = "denizsulanc@gmail.com",
                KatilmaDurumu = true
            });

            _liste.Add("Berrin", new DavetiyeModel
            {
                Ad = "Berrin",
                Eposta = "berrin@gmail.com",
                KatilmaDurumu = true
            });

            _liste.Add("Uğur", new DavetiyeModel
            {
                Ad = "Uğur",
                Eposta = "ugur@gmail.com",
                KatilmaDurumu = false
            });
        }

        public static void Add(DavetiyeModel model)
        {
            string key = model.Ad.ToLower();

            if (_liste.ContainsKey(key)) //eğer girilen key değeri varsa
            {
                _liste[key] = model; //burda o key değerinin içini güncelle
            }
            else
            {
                _liste.Add(key, model); //eğer yoksa key'i ve model'i içine at
            }
        }

        public static IEnumerable<DavetiyeModel> Liste
        {
            get { return _liste.Values; }
            //en yukarıda tanımlanmış private _liste yi istenildiği zaman get ile döndürecek
        }
    }
}