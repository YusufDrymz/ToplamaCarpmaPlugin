using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Islem;
using Toplama;
using Carpma;
using System.Reflection;
using System.Collections;
using System.IO;

namespace consoletest
{
    class Program
    {
        public static object[] pluginler = new object[100];

        static void Main(string[] args)
        {
            PluginYukle("c:\\plugins");
            string key = "";
            do
            {
                Console.WriteLine("Birinci Sayiyi Giriniz: ");
                int sayi1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("İkinci Sayiyi Giriniz: ");
                int sayi2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Yapmak İstediğiniz İşlemi Giriniz: ");
                key = Console.ReadLine();

                if (key != "q")
                {
                    IHesap plugin = PluginAra(key);
                    if (plugin != null)
                    {
                        int sonuc = plugin.Hesapla(sayi1, sayi2);
                        Console.WriteLine("Sonuc: " + sonuc.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Yüklenmeyen Bir İşlem Seçildi!!!");
                    }
                }

            } while (key != "q");

        }

        static IHesap PluginAra(string isim)
        {
            foreach(IHesap plugin in pluginler)
            {
                if (plugin.Isim == isim)
                    return plugin;
            }
            return null;
        }

        static void PluginYukle(string dizin)
        {
            string[] dosyalar = Directory.GetFiles(dizin, "*.dll");
            int index = 0;
            foreach (string dosya in dosyalar)
            {
                Assembly asm = Assembly.LoadFrom(dosya);
                Type[] typelar = asm.GetTypes();
                foreach (Type type in typelar)
                {
                    if (type.IsClass && typeof(IHesap).IsAssignableFrom(type))
                    {
                        object nesne = Activator.CreateInstance(type);
                        pluginler[index] = nesne;
                        index++;
                    }
                }
            }
        }

    }
}
