using System;
using System.Collections.Generic;
using System.Linq;
using Mert.Models;

namespace Mert
{
    class Telefon
    {
        static void Main(string[] args)
        {
            Kişi Mert = new Kişi()
            {
                İsim = "mert",
                Soyisim = "Dede",
                Numara = "5394244221"
            };
            Kişi Hüso = new Kişi()
            {
                İsim = "hüso",
                Soyisim = "Kara",
                Numara = "5743433232"
            };
            Kişi Semo = new Kişi()
            {
                İsim = "semih",
                Soyisim = "Ak",
                Numara = "5302932312"
            };
            List<Kişi> kisiler = new List<Kişi>();
            Rehber rehber = new Rehber();
            kisiler.Add(Mert);
            kisiler.Add(Hüso);
            kisiler.Add(Semo);
            rehber.kisiler = kisiler;
            int islem;
            bool check;

            do
            {


                Console.Write("\n*** Telefon Rehberine Hoşgeldiniz ***\n" + "Lütfen yapmak istediğiniz işlemi seçiniz: \n");
                Console.WriteLine(
                    "(1) Yeni Numara Kaydetmek\n" +
                    "(2) Varolan Numarayı Silmek\n" +
                    "(3) Varolan Numarayı Güncelleme\n" +
                    "(4) Rehberi Listelemek\n" +
                    "(5) Rehberde Arama Yapmak\n" +
                    "(6) Çıkış");
                islem = int.Parse(Console.ReadLine());
                switch (islem)
                {
                    case 1:
                        Kişi yeniKisi = new Kişi();
                        Console.Write("Lütfen isim giriniz: ");
                        yeniKisi.İsim = Console.ReadLine();
                        Console.Write("Lütfen soyisim giriniz: ");
                        yeniKisi.Soyisim = Console.ReadLine();
                        Console.Write("Lütfen numara giriniz: ");
                        yeniKisi.Numara = Console.ReadLine();

                        Kisiekle(yeniKisi, rehber);
                        break;
                    case 2:
                        Console.Write("Lütfen silmek istediğiniz kişinin ismini veya soyismini giriniz: ");
                        string kelime = Console.ReadLine();
                        check = KisiKontrol(kelime, rehber);
                        if (check)
                        {
                            Console.WriteLine("{0} isimli kişi silinmek üzere onaylıyor musunuz? (y/n):", KisiGetir(kelime, rehber).İsim);
                            string answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                KisiSil(kelime, rehber);
                            }
                            else if (answer == "n")
                                break;
                            else
                            {
                                Console.WriteLine("Lütfen geçerli bir cevap veriniz. İşlem Yapılmadı.");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız kriterlere uygun kişi bulunmadı. Lütfen seçim yapınız.\n"
                                + "Silmeyi Sonlandırmak için (1): \n"
                                + "Yeniden denemek için (2): ");
                            string answer1 = Console.ReadLine();
                            if (answer1 == "1")
                                break;
                            else if (answer1 == "2")
                                goto case 2;
                        }
                        break;
                    case 3:
                        Console.Write("Lütfen güncellemek istediğiniz kişinin ismini veya soyismini giriniz: ");
                        string güncel = Console.ReadLine();
                        check = KisiKontrol(güncel, rehber);
                        if (check)
                        {
                            Console.WriteLine("{0} isimli kişi güncellemek üzere onaylıyor musunuz? (y/n):", KisiGetir(güncel, rehber).İsim);
                            string answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                Console.Write("Yeni numara: ");
                                string yeni_numara = Console.ReadLine();
                                KisiGüncelle(güncel, rehber, yeni_numara);
                            }
                            else if (answer == "n")
                                break;
                            else
                            {
                                Console.WriteLine("Lütfen geçerli bir cevap veriniz. İşlem Yapılmadı.");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aradığınız kriterlere uygun kişi bulunmadı. Lütfen seçim yapınız.\n"
                                + "Silmeyi Sonlandırmak için (1): \n"
                                + "Yeniden denemek için (2): ");
                            string answer1 = Console.ReadLine();
                            if (answer1 == "1")
                                break;
                            else if (answer1 == "2")
                                goto case 3;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Telefon Rehberi");
                        foreach (var item in rehber.kisiler)
                        {
                            Console.WriteLine("İsim Soyisim: {0} {1}\n"
                                + "Numara: {2} \n"
                                + "----------", item.İsim, item.Soyisim, item.Numara);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçin \n" + "*******************\n"
                            + "İsim veya soyisime göre arama yapmak için: (1)\n"
                            + "Telefon numarasına göre arama yapmak için: (2)");
                        char islem1 = Convert.ToChar(Console.ReadLine());
                        KisiGetir(islem1, rehber);
                        break;
                }
            } while (islem != 6);
        }

        public static void Kisiekle(Kişi kisi, Rehber rehber)
        {
            try
            {
                Kişi yenikisi = new Kişi();
                yenikisi.İsim = kisi.İsim;
                yenikisi.Soyisim = kisi.Soyisim;
                yenikisi.Numara = kisi.Numara;
                rehber.kisiler.Add(yenikisi);
                Console.WriteLine("Başarıyla Eklendi !");
            }
            catch
            {
                Console.WriteLine("Yeni kişi eklenemedi.");
            }
        }

        public static void KisiSil(string kelime, Rehber rehberListesi)
        {
            try
            {
                rehberListesi.kisiler.Remove(rehberListesi.kisiler.FirstOrDefault(a => a.İsim == kelime || a.Soyisim == kelime));
                Console.WriteLine("Başarıyla Silindi !");
            }
            catch
            {
                Console.WriteLine("Silinemedi.");
            }


        }

        public static bool KisiKontrol(string kelime, Rehber rehber)
        {
            bool result = rehber.kisiler.Any(a => a.İsim == kelime || a.Soyisim == kelime);
            if (result)
                return true;
            else
                return false;
        }
        public static Kişi KisiGetir(string kelime, Rehber rehber)
        {
            Kişi result = rehber.kisiler.FirstOrDefault(a => a.İsim == kelime || a.Soyisim == kelime || a.Numara == kelime);
            return result;
        }
        public static void KisiGetir(char option, Rehber rehber)
        {
            Kişi kisi = new Kişi();
            switch (option)
            {
                case '1':
                    Console.Write("Lütfen isim veya soyisim giriniz: ");
                    string kisiismi = Console.ReadLine();
                    kisi = rehber.kisiler.FirstOrDefault(a => a.İsim == kisiismi || a.Soyisim == kisiismi);
                    break;
                case '2':
                    Console.Write("Lütfen telefon numarası giriniz: ");
                    string kisinumarası = Console.ReadLine();
                    kisi = rehber.kisiler.FirstOrDefault(a => a.Numara == kisinumarası);
                    break;
                default:
                    Console.WriteLine("Lütfen geçerli bir cevap veriniz. İşlem Yapılmadı.");
                    break;
            }
            Console.WriteLine("İsim: {0} \n" + "Soyisim: {1}\n" + "Numara: {2}", kisi.İsim, kisi.Soyisim, kisi.Numara);
        }

        public static void KisiGüncelle(string kelime, Rehber rehber, string numara)
        {
            Kişi result = rehber.kisiler.FirstOrDefault(a => a.İsim == kelime || a.Soyisim == kelime);
            try
            {
                result.Numara = numara;
                Console.WriteLine("Başarıyla Güncellendi !");
            }
            catch
            {
                Console.WriteLine("HATA !");
            }
        }
    }
}
