using System;
using System.Runtime.CompilerServices;

class pengolahanNilai
{
    static int index;
    static string usernameWalas = "walas", passWalas = "12345";
    static string[] dataNamaSiswa = new string[5] { "Azhar", "Satria", "Jeno", "Gabriel", "Prince" };
    static string[] datapasswordSiswa = new string[5] { "Azhar123", "satriaganteng", "jeno123", "gabirel123", "prince123" };
    static string[,] datamapelSiswa = new string[5, 5] {{ "Matematika    ", "Fisika   ", "Bahasa Indonesia    ", "English     ", "DP Kejuruan" },
        {"Matematika    ", "Fisika      ", "Bahasa Indonesia    ", "English     ", "DP Kejuruan " },{ "Matematika   ", "Fisika  ", "Bahasa Indonesia    ", "English     ", "DP Kejuruan"     },
        {"Matematika    ", "Fisika      ", "Bahasa Indonesia    ", "English     ", "DP Kejuruan " },{ "Matematika   ", "Fisika  ", "Bahasa Indonesia    ", "English     ", "DP Kejuruan"     } };
    static string[,] datanilaiSiswa = new string[5, 5] { { "10", "80", "90", "60", "95" } ,
        { "20", "80", "90", "60", "95" }, {"30", "80", "90", "60", "95", },
        { "40", "80", "90", "60", "95" }, {"50", "80", "90", "60", "95", } };



    static void Main(string[] args)
    {
        login();
    }

    static void login()
    {
        Console.Clear();

        Console.Write("\n\n\n - - - - - LOGIN - - - - - \n");
        Console.Write("Usernamme    :   ");
        string user = Console.ReadLine();
        Console.Write("Password     :   ");
        string pass = Console.ReadLine();

        var stringTofind = user;
        string resultnama = Array.Find(dataNamaSiswa, element => element == stringTofind);
        var passTofind = pass;
        string resultpass = Array.Find(datapasswordSiswa, element => element == passTofind);
        index = Array.FindIndex(dataNamaSiswa, row => row == user);
        Console.Write($"index terdeteksi dari nama siswa = {index}\n");

        if (user == usernameWalas && pass == passWalas)
        {
            Console.WriteLine("Login Sukse - -> To Walas PAGE");
            int milliseconds = 1500;
            Thread.Sleep( milliseconds );
            lamanWalas();
        }
        else if (user == resultnama && pass == resultpass)
        {
            Console.WriteLine($"Login Sukse - -> To {resultnama} PAGE");
            int milliseconds = 1500;
            Thread.Sleep(milliseconds);
            lamanSiswa();
        }
        else
        {
            Console.Write("- - - - - USERNAME DAN PASSWORD SALAH! - - - - -");
            Console.Write("Silahkan Login Kembali \n");
            Console.ReadKey();
            login();
        }
    }

    static void lamanSiswa()
    {
        lsiswa:
        Console.Clear();
        Console.Write("\n\n - - - - SISWA MENU - - - - ");
        Console.Write($" \nHello {dataNamaSiswa[index]} \n");
        Console.Write("1  Lihat Nilai \n");
        Console.Write("2. Logout \n");
        Console.Write("3. Keluar \n");
        Console.Write(" - - - -    - - - - -     - - - -   \n ");
        Console.Write("      Pick A Number you want to do :   ");
        //Console.Write($"\n\n\tWelcome  {dataNamaSiswa[index]}\n");
        //Console.Write($"\tWalas : {usernameWalas}\n\n  ");
        string siswa = Console.ReadLine();
        switch (siswa)
        {
            case "1":
                Console.Write($"\tBerikut adalah Nilai Kamu:    \n");
                for (int k = 0; k < 5; k++)
                {
                    Console.Write($"\t | {datamapelSiswa[index, k]} nilai = {datanilaiSiswa[index, k]} |\n ");
                }
                Console.ReadKey();
                goto lsiswa;
            case "2":
                Console.Write($"Yakin Ingin Logout dari akun {dataNamaSiswa} ?");
                string LOGOUT = Console.ReadLine();
                if (LOGOUT == "Y" || LOGOUT == "y")
                {
                    Console.Write("Anda Logout");
                    login();
                    break;

                }
                else
                {
                    goto lsiswa;
                }
            case "3":
                Console.WriteLine("Yakin Ingin Keluar dari progrman ? :");
                string oout = Console.ReadLine();
                if (oout == "Y" || oout == "y")
                {
                    break;
                }
                else
                {
                    goto lsiswa;
                }
            default:
                Console.Write("Wrong number ");
                Console.ReadKey();
                goto lsiswa;
        }
        
    }

    static void lamanWalas()
    {
        walas:
        Console.Clear();
        Console.Write("\n\n - - - - WALAS MENU - - - - ");
        Console.Write($" \nHello {usernameWalas} \n");
        Console.Write("1. Input Nilai Dan Revisi Nilai \n");
        Console.Write("2. Ganti Username dan Password \n");
        Console.Write("3. Lihat data peringkat \n");
        Console.Write("4. Lihat data siswa \n");
        Console.Write("5. Logout \n");
        Console.Write("6. Keluar \n");
        Console.Write(" - - - -    - - - - -     - - - -   \n ");
        Console.Write("      Pick A Number you want to do :   ");
        string pilih = Console.ReadLine();
        switch ( pilih )
        {
            case "1":
                Console.Write("Masukkan nama siswa yang ingin diinput nilainya: ");
                string nama = Console.ReadLine();
                bool found = false;
                for (int i = 0; i< dataNamaSiswa.Length; i++)
                {
                    if (dataNamaSiswa[i] == nama )
                    {
                        found = true;
                        index = i;
                        break;
                    }
                }
                if ( found)
                {
                    Console.WriteLine("Nama siswa ditemukan. Masukkan nilai untuk setiap mata pelajaran..");
                    for (int j = 0; j < datamapelSiswa.GetLength(1);j++)
                    {
                        Console.Write(datamapelSiswa[index, j] + ": ");
                        string nilai = Console.ReadLine();
                        datanilaiSiswa[index, j] = nilai;
                    }
                }
                else
                {
                    Console.WriteLine("Nama siswa tidak ditemukan. Silakan coba lagi.");
                }
                Console.ReadKey();
                goto walas;

        case "2":
                Console.Clear ();
                Console.Write("\n\n - - - - ACCOUNT MENU - - - - " );
                Console.Write("\n1. Ganti Username Siswa \n");
                Console.Write("2. Ganti Password Siswa \n");
                Console.Write("3. Kembali \n");
                Console.Write(" - - - -    - - - - -     - - - -   \n ");
                Console.Write("      Pick A Number you want to do :   ");
                string usspass = Console.ReadLine();
                switch (usspass)
                {
                    case "1":
                        Console.Write("Masukkan nama siswa yang ingin diubah usernamenya:");
                        string change = Console.ReadLine();
                        bool changed = false;
                        for (int p = 0; p < dataNamaSiswa.Length; p++)
                        {
                            if (dataNamaSiswa[p] == change)
                            {
                                changed = true;
                                index = p;
                                break;
                            }
                        }
                        if (changed)
                        {
                            Console.WriteLine("Nama siswa ditemukan. Username saat ini adalah: " + dataNamaSiswa[index]);
                            Console.WriteLine("Masukkan username baru:  ");
                            string usernameBaru = Console.ReadLine();
                            dataNamaSiswa[index] = usernameBaru;
                            Console.WriteLine("Username berhasil dirubah.");
                        }
                        else
                        {
                            Console.WriteLine("Nama siswa tidak ditemukan. Silakan coba lihat di daftar nama siswa.");
                        }
                        Console.ReadKey();
                        goto walas;
                case "2":
                        Console.WriteLine("Masukkan nama siswa yang ingin diubah password:");
                        string pass = Console.ReadLine();
                        bool pass1 = false;
                        for (int p = 0; p < dataNamaSiswa.Length; p++)
                        {
                            if (dataNamaSiswa[p] == pass)
                            {
                                pass1 = true;
                                index = p;
                                break;
                            }
                        }
                        if (pass1)
                        {
                            Console.WriteLine("Nama siswa ditemukan. password saat ini adalah: " + datapasswordSiswa[index]);
                            Console.WriteLine("Masukkan username baru:");
                            string passwordBaru = Console.ReadLine();
                            datapasswordSiswa[index] = passwordBaru;
                            Console.WriteLine("password berhasil dirubah.");
                        }
                        else
                        {
                            Console.WriteLine("Nama siswa tidak ditemukan. Silakan coba lagi.");
                        }
                        Console.ReadKey();
                        goto walas;
                case "3":
                        goto walas;

                }
                Console.ReadKey();
                goto walas;
        case "3":
                Console.WriteLine("Sistem Belum Dibuat :>");
                Console.ReadKey();
                goto walas;

        case "4":
                string tableFormat = "{0,-10}";
                Console.WriteLine("Daftar Nama Siswa");
                Console.WriteLine(tableFormat, "Nama :");
                for (int i = 0; i < dataNamaSiswa.Length; i++)
                {
                    Console.WriteLine(tableFormat, dataNamaSiswa[i]);
                }
                Console.ReadKey();
                goto walas;


        case "5":
                Console.Write($"Yakin Ingin Logout dari akun {usernameWalas} ?      ");
                string LOGOUT = Console.ReadLine();
                if (LOGOUT == "Y" || LOGOUT == "y")
                {
                    Console.Write ("Anda Logout");
                    login();
                    break;

                }
                else
                {
                    goto walas;
                }
        case "6":
               Console.WriteLine("Yakin Ingin Keluar dari progrman ? :");
               string oout = Console.ReadLine();
               if (oout == "Y" || oout == "y")
               {
                   break;
               }
               else
               {
                   goto walas;
               }
        default:
               Console.Write("Wrong number ");
               Console.ReadKey();
               goto walas;
        }
        
    }
}
