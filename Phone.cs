using System;
using System.Collections.Generic;
using System.Linq;
using Proje1-patika.Models;

namespace Proje1-patika
{
    class Telefon
    {
        static void Main(string[] args)
        {
            Rehber Mert = new Rehber()
            {
                İsim = "mert",
                Soyisim = "Dede",
                Numara = "5394244221"
            };
            Rehber Hüso = new Rehber()
            {
                İsim = "hüso",
                Soyisim = "Kara",
                Numara = "5743433232"
            };
            Rehber Semo = new Rehber()
            {
                İsim = "semih",
                Soyisim = "Ak",
                Numara = "5302932312"
            };
            List<Rehber> rehber = new List<Rehber>();
            rehber.Add(Mert);
            rehber.Add(Hüso);
            rehber.Add(Semo);
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
                        Rehber yeniKisi = new Rehber();
                        Console.Write("Lütfen isim giriniz: ");
                        yeniKisi.İsim = Console.ReadLine();
                        Console.Write("Lütfen soyisim giriniz: ");
                        yeniKisi.Soyisim = Console.ReadLine();
                        Console.Write("Lütfen numara giriniz: ");
                        yeniKisi.Numara = Console.ReadLine();

                        rehber.Add(Kisiekle(yeniKisi));
                        Console.WriteLine("Başarıyla Eklendi !");
                        break;

                    case 2:
                        Console.Write("Lütfen silmek istediğiniz kişinin ismini veya soyismini giriniz: ");
                        string kelime = Console.ReadLine();
                        check = KisiKontrol(kelime,rehber);
                        if (check)
                        {
                            Console.WriteLine("{0} isimli kişi silinmek üzere onaylıyor musunuz? (y/n):", KisiGetir(kelime,rehber).İsim);
                            string answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                bool result = KisiSil(kelime, rehber);
                                if (result)
                                    Console.WriteLine("Başarıyla Silindi !");
                                else
                                    Console.WriteLine("Silinemedi.");
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
                            Console.WriteLine("{0} isimli kişi güncellemek üzere onaylıyor musunuz? (y/n):", KisiGetir(güncel,rehber).İsim);
                            string answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                Console.Write("Yeni numara: ");
                                string yeni_numara = Console.ReadLine();
                                if (KisiGüncelle(güncel, rehber, yeni_numara))
                                    Console.WriteLine("Başarıyla Güncellendi !");
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
                        foreach (var item in rehber)
                        {
                            Console.WriteLine("İsim: {0}\n"
                                + "Soyisim: {1}\n"
                                + "Numara: {2} \n"
                                + "*********", item.İsim, item.Soyisim, item.Numara);
                        }

                        break;
                    case 5:
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçin \n" + "*******************\n"
                            + "İsim veya soyisime göre arama yapmak için: (1)\n"
                            + "Telefon numarasına göre arama yapmak için: (2)");
                        char islem1 = Convert.ToChar(Console.ReadLine());
                        Rehber person = new Rehber();
                        if (islem1 == Convert.ToChar("1"))
                        {
                            Console.Write("Lütfen isim veya soyisim giriniz: ");
                            string kisiismi = Console.ReadLine();
                            person = KisiGetir(kisiismi, rehber);
                            Console.WriteLine("İsim: {0} \n" + "Soyisim: {1}\n" + "Numara: {2}", person.İsim, person.Soyisim, person.Numara);
                            break;
                        }
                        else if (islem1 == Convert.ToChar("2"))
                        {
                            Console.Write("Lütfen telefon numarası giriniz: ");
                            string kisinumarası = Console.ReadLine();
                            person = KisiGetir(kisinumarası, rehber);
                            Console.WriteLine("İsim: {0} \n" + "Soyisim: {1}\n" + "Numara: {2}", person.İsim, person.Soyisim, person.Numara);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Lütfen geçerli bir cevap veriniz. İşlem Yapılmadı.");
                            break;
                        }
                        break;

                        
                }
            } while (islem != 6);
        }

        public static Rehber Kisiekle(Rehber kisi)
        {
            Rehber yenikisi = new Rehber();
            yenikisi.İsim = kisi.İsim;
            yenikisi.Soyisim = kisi.Soyisim;
            yenikisi.Numara = kisi.Numara;
            return yenikisi;
        }

        public static bool KisiSil(string kelime, List<Rehber> rehberListesi)
        {
            try
            {

                rehberListesi.Remove(rehberListesi.FirstOrDefault(a => a.İsim == kelime || a.Soyisim == kelime));
                return true;
            }
            catch
            {
                return false;
            }


        }

        public static bool KisiKontrol(string kelime, List<Rehber> rehberListesi)
        {
            bool result = rehberListesi.Any(a => a.İsim == kelime || a.Soyisim == kelime);
            if (result)
                return true;
            else
                return false;
        }
        public static Rehber KisiGetir(string kelime,List<Rehber> rehberListesi)
        {
            Rehber result = rehberListesi.FirstOrDefault(a => a.İsim == kelime || a.Soyisim == kelime ||a.Numara==kelime);
            return result;
        }

        public static bool KisiGüncelle(string kelime, List<Rehber> rehberListesi,string numara)
        {
            Rehber result = rehberListesi.FirstOrDefault(a => a.İsim == kelime || a.Soyisim == kelime);
            try
            {
                result.Numara = numara;
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
