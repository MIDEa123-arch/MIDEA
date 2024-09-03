using System;
using System.Globalization;
using System.Linq;
//namespace VD1
//{
//    class HinhTron
//    {
//        double BanKinh;
//        public double Chuvi()
//        {
//            return BanKinh * 2 * Math.PI;
//        }
//        public double DienTich()
//        {
//            return Math.Sqrt(BanKinh) * Math.PI;
//        }
//        public void Nhap()
//        {
//            BanKinh = double.Parse(Console.ReadLine());
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            HinhTron hinhTron = new HinhTron();

//            hinhTron.Nhap();

//            Console.WriteLine("Chu vi hình tròn: " + hinhTron.Chuvi().ToString("F1"));
//            Console.WriteLine("Diện tích hình tròn: " + hinhTron.DienTich().ToString("F1"));

//            Console.ReadLine();
//        }
//    }
//}
//namespace VD3
//{
//    class PTbac2
//    {
//        int a, b, c;
//        public int soNghiem()
//        {
//            int delta = b * b - (4 * a * c);
//            if (delta > 0)
//            {
//                return 2;
//            }
//            else if (delta < 0)
//            {
//                return 0;
//            }
//            else
//            {
//                return 1;
//            }    
//        }
//        public void Dangptr()
//        {
//            Console.WriteLine("Phuong trinh co dang: {0}x^2 + {1}x + {2} = 0", a, b, c);
//        }
//        public void Nhap()
//        {
//            a = int.Parse(Console.ReadLine());  
//            b = int.Parse(Console.ReadLine());
//            c = int.Parse(Console.ReadLine());
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            PTbac2 ptr = new PTbac2();
//            ptr.Nhap();
//            ptr.Dangptr();
//            Console.WriteLine("So nghiem cua phuong trinh la: {0}", ptr.soNghiem());

//        }
//    }
//}
//namespace VD4
//{
//    class PhanSo
//    {
//        int mau1, tu1, mau2, tu2, Tu, Mau;
//        private int UCLN(int a, int b)
//        {
//            while (b != 0)
//            {
//                int temp = b;
//                b = a % b;
//                a = temp;
//            }
//            return Math.Abs(a);
//        }
//        private void RutGon()
//        {
//            int ucln = UCLN(Tu, Mau);
//            Tu /= ucln;
//            Mau /= ucln;
//        }
//        public void Sum()
//        {
//            Tu = tu1 * mau1 + tu2 * mau2;
//            Mau = mau1* mau2;
//            RutGon();
//            Console.WriteLine("Tong = {0} / {1}", Tu, Mau);
//        }
//        public void Nhap()
//        {
//            tu1 = int.Parse(Console.ReadLine());
//            mau1 = int.Parse(Console.ReadLine());    
//            tu2 = int.Parse(Console.ReadLine());
//            mau2 = int.Parse(Console.ReadLine());
//        }
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//           PhanSo ps = new PhanSo();
//           ps.Nhap();
//           ps.Sum();

//        }
//    }

namespace VD5
{
    class KiemTra()
    {
        public bool KiemTraHopLe(int day, int month, int year)
        {
            Thang thang = new Thang();
            thang.month = month;

            Nam nam = new Nam();
            nam.year = year;

            bool isNamNhuan = nam.NamNhuan();
            int soNgayTrongThang = thang.KtrSoNgay(isNamNhuan);

            return day > 0 && day <= soNgayTrongThang;
        }
    }
    
    class Thang
    {
        int[] Co31ngay = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        int[] Co30ngay = new int[] { 4, 6, 9, 11 };
        public int month;

        public void Nhap()
        {
            Console.WriteLine("Nhap thang: ");
            month = int.Parse(Console.ReadLine());

            while (month < 1 || month > 12)
            {
                Console.WriteLine("Thang khong hop le ");
                month = int.Parse(Console.ReadLine());
            }
        }

        public int KtrSoNgay(bool namNhuan)
        {
            if (Co31ngay.Contains(month))
            {
                return 31;
            }
            else if (Co30ngay.Contains(month))
            {
                return 30;
            }
            else
            {
                return namNhuan ? 29 : 28;
            }
        }
    }

    class Nam
    {
        public int year;

        public void Nhap()
        {
            Console.WriteLine("Nhap nam: ");
            year = int.Parse(Console.ReadLine());
        }

        public bool NamNhuan()
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }

    class Nguoi
    {
        public int birthDay, birthMonth, birthYear;
        KiemTra Ktr = new KiemTra();
        public void Nhap()
        {
            Console.WriteLine("Nhap ngay sinh: ");
            birthDay = int.Parse(Console.ReadLine());
            birthMonth = int.Parse(Console.ReadLine());
            birthYear = int.Parse(Console.ReadLine());
            while (!Ktr.KiemTraHopLe(birthDay, birthMonth, birthYear))
            {
                Console.WriteLine("Ngay sinh khong hop le:");
                birthDay = int.Parse(Console.ReadLine());
                birthMonth = int.Parse(Console.ReadLine());
                birthYear = int.Parse(Console.ReadLine());
            }
        }
        public void TinhTuoi(int currentDay, int currentMonth, int currentYear)
        {
            int ageYears = currentYear - birthYear;
            int ageMonths = currentMonth - birthMonth;
            int ageDays = currentDay - birthDay;

            // Nếu ngày hiện tại nhỏ hơn ngày sinh
            if (ageDays < 0)
            {
                // Lấy số ngày của tháng trước đó
                Nam nam = new Nam();
                nam.year = currentYear;
                Thang thang = new Thang();
                thang.month = (currentMonth == 1) ? 12 : currentMonth - 1;
                int daysInPreviousMonth = thang.KtrSoNgay(nam.NamNhuan());
                ageDays += daysInPreviousMonth;

                // Giảm 1 tháng
                ageMonths--;
            }

            // Nếu tháng hiện tại nhỏ hơn tháng sinh
            if (ageMonths < 0)
            {
                ageYears--;
                ageMonths += 12;
            }

            Console.WriteLine("Tuoi chinh xac la: {0} tuoi, {1} thang, {2} ngay.", ageYears, ageMonths, ageDays);
        }
    }

    class CurrentYear
    {
        public int currentDay, currentMonth, currentYear;
        KiemTra Ktr = new KiemTra();
        public void Nhap()
        {
            Console.WriteLine("Nhap ngay hien tai: ");
            currentDay = int.Parse(Console.ReadLine());
            currentMonth = int.Parse(Console.ReadLine());
            currentYear = int.Parse(Console.ReadLine());
            while (!Ktr.KiemTraHopLe(currentDay, currentMonth, currentYear))
            {
                Console.WriteLine("Ngay hien tai khong le:");
                currentDay = int.Parse(Console.ReadLine());
                currentMonth = int.Parse(Console.ReadLine());
                currentYear = int.Parse(Console.ReadLine());
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Nguoi nguoi = new Nguoi();
            nguoi.Nhap();
            CurrentYear currentYear = new CurrentYear();
            currentYear.Nhap();
            nguoi.TinhTuoi(currentYear.currentDay, currentYear.currentMonth, currentYear.currentYear);
        }
    }
}

