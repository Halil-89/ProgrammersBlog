using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla Güncellenmiştir..";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName}  adlı kategori başarıyla veritabanından SİLİNMİŞTİR.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName}  adlı kategori başarıyla arşivden geri getirilmiştir..";
            }
        }
        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir Makale bulunamadı.";
                return "Böyle bir makale bulunamadı.";
            }
            public static string Delete(string articleName)
            {
                return $"{articleName} adlı makale başarıyla silinmiştir";
            }
            public static string Add(string articleName)
            {
                return $"{articleName} adlı makale başarıyla eklenmiştir.";
            }
            public static string HardDelete(string articleName)
            {
                return $"{articleName}  adlı makale başarıyla veritabanından SİLİNMİŞTİR.";
            }
            public static string Update(string articleName)
            {
                return $"{articleName} adlı makale başarıyla Güncellenmiştir..";
            }
            public static string UndoDelete(string articleName)
            {
                return $"{articleName}  adlı makale başarıyla arşivden geri getirilmiştir..";
            }
            public static string IncreaseViewCount(string articleName)
            {
                return $"{articleName}  başlıklı makale'nin okunma sayısı başarıyla arttırılmıştır..";
            }
        }

        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }
            public static string Approve(int commentId)
            {
                return $"{commentId} no'lu yorum başarıyla onaylanmıştır.";
            }

            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName}  tarafından eklenen yorum başarıyla arşivden geri getirilmiştir..";
            }
        }
    }
}

