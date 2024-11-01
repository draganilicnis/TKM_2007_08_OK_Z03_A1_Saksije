// https://arena.petlja.org/sr-Latn-RS/competition/tkm-100-ok-100#tab_89119 
// https://arena.petlja.org/competition/r1-11-utvrdjivanje-tkm-k003#tab_89119 
// https://arena.petlja.org/competition/tkm-003-ok-do-2017#tab_89119 
// https://www.petlja.org/biblioteka/r/Problems/2008-okruzno-ss-saksije 

using System;

class TKM_2007_08_OK_Z03_A1_Saksije
{
    static void Main()
    {
        Main_01();
    }
    static void Main_01()
    {
        // ULAZ
        string[] s = Console.ReadLine().Split();
        long N = long.Parse(s[0]);
        long K = long.Parse(s[1]);

        long W = 0;
        if (N > 0)
        {
            char C;           
            long B = 0;
            long X = 0;
            bool bOk = true;  // Procitan je ispravan karakter
            while (bOk)
            {
                C = (char)Console.Read();
                if (bOk)
                {
                    if (C == ' ')
                    {
                        long A = B;
                        B = 0;
                        X = A + X - K;          // U kofu X stavljamo visak, odnosno manjak
                        W = W + Math.Abs(X);    // Toma nosi kofu visak do druge saksije
                    }
                    else if (C >= '0' && C <='9')
                    {
                        int cifra = C - 48;
                        B = 10 * B + cifra;
                    }
                    else
                    {
                        bOk = false;
                    }
                }
            }
        }

        long R = W % 1000000000;
        Console.WriteLine(R);
    }

    static void Main_02()
    {
        // ULAZ
        string[] s1 = Console.ReadLine().Split();
        long N = long.Parse(s1[0]);
        long K = long.Parse(s1[1]);

        // INIT
        double W = 0;

        string[] s2 = Console.ReadLine().Split(); int saksija_i = 0;
        // Ucitavamo K iz prve saksije
        if (N > 0)
        {
            long A = long.Parse(s2[saksija_i]); saksija_i++;
            double X = A - K;           // U kofu X stavljamo visak, odnosno manjak
            W = W + Math.Abs(X);        // Toma nosi kofu visak do druge saksije

            // PETLJA ide od od 2 (jer smo vec obradili prvu saksiju) do N-1
            for (long i = 2; i < N; i++)
            {
                A = long.Parse(s2[saksija_i]); saksija_i++; // Ucitavamo K za i-tu saksiju
                X = (A + X) - K;                            // Dodajemo visak/manjak i novi visak
                W = W + Math.Abs(X);                        // Sabiramo utrosnu energiju
            }

            // Za svaki slucaj zbog test primera ucitavamo i poslednju saksiju
            A = long.Parse(s2[saksija_i]); saksija_i++;
        }

        // Ovo je bilo bitno iz zadatka za 5 test primera
        long R = (long)Math.Round(W) % 1000000000;

        // Izlaz
        Console.WriteLine(R);
    }
}
