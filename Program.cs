using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace CHECKPOINT_TASK
{
    internal class Program
    {
        public static event Action<string> KitapEklendi;
        static async Task Main(string[] args)
        {
            List<Kitap> kitaplar = new List<Kitap>();
            HashSet<string> benzersiz = new HashSet<string>();
            KitapEklendi += Bildirim;
            string ürün = "";
            while (ürün != "bitir")
            {
                try
                {
                    Console.WriteLine("1.Ekleme\n2.Çıkış");
                    Console.Write("Yanıt: ");
                    ürün = Console.ReadLine();
                    if (ürün == "1")
                    {
                        Console.WriteLine("Baslik: ");
                        string baslik = Console.ReadLine();
                        Console.WriteLine("Yazar: ");
                        string yazar = Console.ReadLine();
                        Console.WriteLine("Tür: ");
                        string tür = Console.ReadLine();
                        Console.WriteLine("Yil: ");
                        int yil = Int32.Parse(Console.ReadLine());
                        kitaplar.Add(new Kitap(baslik, yazar, tür, yil));
                        benzersiz.Add(yazar);
                        KitapEklendi?.Invoke(baslik);
                    }
                    else if (ürün == "2")
                        ürün = "bitir";
                    else
                        Console.WriteLine("Lütfen Doğru Giriniz.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
            }
            if(kitaplar.Count == 0)
            {
                Console.WriteLine("Kitap Yok.");
                return;
            }
            var turler = kitaplar.GroupBy(i => i.Tur).ToList();
            foreach(var item in turler)
            {
                Console.WriteLine(item.Key + "\n");
                foreach(var i in item)
                {
                    Console.WriteLine(" " + i.Baslik);
                }
            }
            var yillar = kitaplar.OrderBy(i => i.Yil).ToList();
            foreach(var item in yillar)
            {
                Console.WriteLine(item.Baslik + "|" + item.Yil);
            }
            Console.WriteLine(kitaplar.Where(i => i.Yil > 2000).Count());
            try
            {
                Console.WriteLine("Eski mi Yeni mi: ");
                string cevap = Console.ReadLine().ToLower();
                if (cevap == "eski")
                {
                    Console.WriteLine(EnEskiVeyaEnYeni(kitaplar, i => i.Yil, true));
                }
                else if (cevap == "yeni")
                {
                    Console.WriteLine(EnEskiVeyaEnYeni(kitaplar, i => i.Yil, false));
                }
                else
                    Console.WriteLine("Dogru Giriniz.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            await KaydetAsync(kitaplar);
            List<Kitap> kitaplarYuklenen = await YukleAsync();
            foreach (var item in kitaplarYuklenen)
            {
                Console.WriteLine(item.Baslik + "|" + item.Yazar + "|" + item.Tur + "|" + item.Yil);
            }

        }
        public static void Bildirim(string baslik)
        {
            Console.WriteLine($"Yeni Kitap Eklendi: {baslik}\n");
        }
        public static T EnEskiVeyaEnYeni<T>(List<T> liste, Func<T,int> yilSecici, bool enEski)
        {
            if(enEski)
            {
                return liste.OrderBy(yilSecici).First();
            }
            else
            {
                return liste.OrderByDescending(yilSecici).First();
            }
        }
        public static async Task KaydetAsync(List<Kitap> kitaplar)
        {
            var json = JsonSerializer.Serialize(kitaplar);
            using(StreamWriter writer = new StreamWriter("kütüphane.json"))
            {
                await writer.WriteAsync(json);
            }
        }
        public static async Task<List<Kitap>> YukleAsync()
        {
            using (StreamReader reader = new StreamReader("kütüphane.json"))
            {
                var json = await reader.ReadToEndAsync();
                List<Kitap> kitaplar = JsonSerializer.Deserialize<List<Kitap>>(json);
                return kitaplar;
            }
        }

    }
}
