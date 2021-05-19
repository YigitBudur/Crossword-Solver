using System;
using System.Windows.Input;

namespace CrosswordSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(24, 24);           // Console.SetWindowSize(15, 24);
            int wordLength;
            char letter; 
            int checkX = 0; // Karakterleri yerleştirme ve okumada kullanılacak
            int checkY = 0; // Karakterleri yerleştirme ve okumada kullanılacak

            int wLengthStorage = 0;
                
            // Puzzle Alanını Oluştur
            #region [ Puzzle Alanı ]
            Console.WriteLine("+++++++@+++++++");  // 1.  Satır
            Console.WriteLine("++++++@++++++@+");  // 2.  Satır
            Console.WriteLine("+++++++@+++++++");  // 3.  Satır
            Console.WriteLine("++++++@++++++@+");  // 4.  Satır
            Console.WriteLine("@+@++++@+++++@+");  // 5.  Satır
            Console.WriteLine("++++++++@+@++++");  // 6.  Satır
            Console.WriteLine("+@+@+@+++++++++");  // 7.  Satır
            Console.WriteLine("++++@+@+@+@++++");  // 8.  Satır
            Console.WriteLine("+++++++++@+@+@+");  // 9.  Satır
            Console.WriteLine("++++@+@++++++++");  // 10. Satır
            Console.WriteLine("@++++++@++++@+@");  // 11. Satır
            Console.WriteLine("+@++++++@++++++");  // 12. Satır
            Console.WriteLine("+++++++@+++++++");  // 13. Satır
            Console.WriteLine("+@++++++@++++++");  // 14. Satır
            Console.WriteLine("+++++++@+++++++");  // 15. Satır

            string[] lineN = new string[15];
            lineN[0] = "+++++++@+++++++"; // 1.  Satır
            lineN[1] = "++++++@++++++@+"; // 2.  Satır
            lineN[2] = "+++++++@+++++++"; // 3.  Satır
            lineN[3] = "++++++@++++++@+"; // 4.  Satır
            lineN[4] = "@+@++++@+++++@+"; // 5.  Satır
            lineN[5] = "++++++++@+@++++"; // 6.  Satır
            lineN[6] = "+@+@+@+++++++++"; // 7.  Satır
            lineN[7] = "++++@+@+@+@++++"; // 8.  Satır
            lineN[8] = "+++++++++@+@+@+"; // 9.  Satır
            lineN[9] = "++++@+@++++++++"; // 10. Satır
            lineN[10] = "@++++++@++++@+@"; // 11. Satır
            lineN[11] = "+@++++++@++++++"; // 12. Satır
            lineN[12] = "+++++++@+++++++"; // 13. Satır
            lineN[13] = "+@++++++@++++++"; // 14. Satır
            lineN[14] = "+++++++@+++++++"; // 15. Satır

            #endregion

            #region [ List Last Indexes ]
            int list3LastIndex = 0;
            int list4LastIndex = 0;
            int list5LastIndex = 0;
            int list6LastIndex = 0;
            int list7LastIndex = 0;
            int list8LastIndex = 0;
            int list9LastIndex = 0;
            int list10LastIndex = 0;
            #endregion

            #region [ listXLetter ]

            string[] list3Letter = new string[2];
            list3Letter[0] = "GNU";
            list3Letter[1] = "TOE";

            string[] list4Letter = new string[14];
            list4Letter[0] = "AEON";
            list4Letter[1] = "ANOA";
            list4Letter[2] = "APER";
            list4Letter[3] = "EMIT";
            list4Letter[4] = "OARS";
            list4Letter[5] = "PAIR";
            list4Letter[6] = "PASS";
            list4Letter[7] = "RODS";
            list4Letter[8] = "STIR";
            list4Letter[9] = "UPON";
            list4Letter[10] = "VALE";
            list4Letter[11] = "VENT";
            list4Letter[12] = "YOGI";
            list4Letter[13] = "YOUR";

            string[] list5Letter = new string[7];
            list5Letter[0] = "AGREE";
            list5Letter[1] = "EMILE";
            list5Letter[2] = "GELID";
            list5Letter[3] = "IVORY";
            list5Letter[4] = "RAINS";
            list5Letter[5] = "SOLES";
            list5Letter[6] = "SPUDS";

            string[] list6Letter = new string[16];
            list6Letter[0] = "BIRDIE";
            list6Letter[1] = "DESCRY";
            list6Letter[2] = "HEMPEN";
            list6Letter[3] = "MODERN";
            list6Letter[4] = "NATIVE";
            list6Letter[5] = "NOVELS";
            list6Letter[6] = "OPENER";
            list6Letter[7] = "OPPOSE";
            list6Letter[8] = "PLOVER";
            list6Letter[9] = "POMACE";
            list6Letter[10] = "RETINA";
            list6Letter[11] = "SEALED";
            list6Letter[12] = "SIMOOM";
            list6Letter[13] = "SNOCAT";
            list6Letter[14] = "TALKER";
            list6Letter[15] = "TENANT";

            string[] list7Letter = new string[10];
            list7Letter[0] = "AMENITY";
            list7Letter[1] = "EDITING";
            list7Letter[2] = "GASPUMP";
            list7Letter[3] = "ICINESS";
            list7Letter[4] = "LOURDES";
            list7Letter[5] = "RAYLESS";
            list7Letter[6] = "RENTERS";
            list7Letter[7] = "SWOLLEN";
            list7Letter[8] = "TRIVIAL";
            list7Letter[9] = "VOLCANO";

            string[] list8Letter = new string[6];
            list8Letter[0] = "AMORETTO";
            list8Letter[1] = "INVESTOR";
            list8Letter[2] = "PERICARP";
            list8Letter[3] = "SNOWSHOE";
            list8Letter[4] = "SURVIVAL";
            list8Letter[5] = "UNCLOAKS";

            string[] list9Letter = new string[2];
            list9Letter[0] = "EASTEREGG";
            list9Letter[1] = "RETURNING";

            string[] list10Letter = new string[2];
            list10Letter[0] = "UNDERNEATH";
            list10Letter[1] = "VIRTUOSITY";
            #endregion

            #region [ GetWordSpaceHorizontal ] - Bulunulan noktadan sonraki "@" karakterine kadar olan sağa doğru yatay boşluğu hesaplar ve döndürür.
            int GetWordSpaceHorizontal(int checkX, int checkY)
            {
                Console.SetCursorPosition(checkX, checkY);
                string Line = lineN[checkY];
                int b = Line.IndexOf("@");
                return b;
            }
            #endregion

            #region [ GetWordSpaceVertical ] - Bulunulan noktadan sonraki "@" karakterine kadar olan aşağı doğru dikey boşluğu hesaplar ve döndürür.
            int GetWordSpaceVertical(int checkX, int checkY)
            {
                Console.SetCursorPosition(checkX, checkY);
                string Line = lineN[checkY];
                int b = Line.IndexOf("@");
                return b;
            }
            #endregion

            #region [ PickWord ] - int a = karakter sayısı olmak üzere bir kelime döndürür
            string PickWord(int a) // Minimum value is 3 max is 10
            {
                if (a == 3)
                {
                    return list3Letter[list3LastIndex++];
                } else
                if (a == 4)
                {                   
                    return list4Letter[list4LastIndex++];                   
                } else
                if (a == 5)
                {
                    return list5Letter[list5LastIndex++];
                } else
                if (a == 6)
                {
                    return list6Letter[list6LastIndex++];
                } else
                if (a == 7)
                {
                    return list7Letter[list7LastIndex++];
                } else
                if (a == 8)
                {
                    return list8Letter[list8LastIndex++];
                } else                
                if (a == 9)
                {
                    return list9Letter[list9LastIndex++];
                } else                
                if (a == 10)
                {
                    return list10Letter[list10LastIndex++];
                }
                else return "Not a valid INPUT";
            }
            #endregion

            #region [ Space Checker 15x15 ] - Puzzle alanının 15x15 olup olmadığını kontrol eder
            //for (int i = 0; i < 15; i++)
            //{
            //    Console.WriteLine(""); // Alt satıra geç      
            //    for (int a = 0; a < 15; a++)
            //    {
            //        Console.Write("#");
            //    }
            //}
            #endregion           // 


            //int pStart = stringInput.IndexOf("{"); // Parantez başlangıcının indexini al
            //int pEnd = stringInput.IndexOf("}");   // Parantez sonunun indexini al

            //stringOutput = stringInput.Substring(pStart+1, pEnd-pStart-1);
            //Console.WriteLine("Parantez içi: '"+stringOutput+"'");
            //Console.SetCursorPosition(0, 0);

            int p1 = GetWordSpaceHorizontal(0, 0);
            Console.WriteLine(PickWord(p1));

            int p2 = GetWordSpaceHorizontal(0, 1);
            Console.WriteLine(PickWord(p2));

            int p3 = GetWordSpaceHorizontal(0, 2);
            Console.WriteLine(PickWord(p3));

            int p4 = GetWordSpaceHorizontal(0, 3);
            Console.WriteLine(PickWord(p4));

            int p5 = GetWordSpaceHorizontal(0, 5);
            Console.WriteLine(PickWord(p5));




            // Kapanmak için tuş girişini bekle
            Console.ReadLine();           
        }
    }
}


// Yiğit Budur (120444012) Bilgi Üniversitesi