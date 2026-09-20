# 📚 Kütüphane Yönetim Sistemi (C# Console App)

Bu proje, C# programlama dilinin temel ve orta seviye özelliklerini (OOP, LINQ, Async/Await, Events, JSON Serialization) bir araya getiren konsol tabanlı bir kütüphane otomasyonudur.

## 🚀 Özellikler

- **Nesne Yönelimli Programlama (OOP):** Modüler sınıf yapısı.
- **Event & Delegate:** Yeni kitap eklendiğinde tetiklenen dinamik bildirim sistemi.
- **LINQ Entegrasyonu:** Kitapları türe göre gruplama, yıla göre sıralama ve filtreleme.
- **Asenkron Dosya İşlemleri (`async/await`):** Verilerin `kütüphane.json` dosyasına asenkron olarak kaydedilmesi ve okunması.
- **Hata Yönetimi:** Yanlış veri girişlerine karşı `try-catch` koruması.

## 🛠️ Kullanılan Teknolojiler

- C# (.NET)
- LINQ
- System.Text.Json
- Asynchronous Programming (`Task`, `async/await`)

## 💻 Kullanım

1. Uygulama başladığında karşınıza gelen menüden `1` tuşuna basarak kitap ekleme ekranına ulaşabilirsiniz.
2. Kitabın **Başlığını**, **Yazarını**, **Türünü** ve **Yılını** girerek listeye ekleyebilirsiniz. (Yeni kitap eklendiğinde event tetiklenecektir).
3. Veri girişi bittiğinde döngüden çıkarak LINQ ile yapılan sıralama, gruplama ve filtreleme sonuçlarını görebilirsiniz.
4. Son aşamada veriler otomatik olarak `kütüphane.json` dosyasına kaydedilir ve dosyadan okunarak konsola tekrar yazdırılır.

---
*Bu proje C# öğrenme sürecinde pratik yapmak amacıyla geliştirilmiştir.*
