using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CrosswordSolver
{
    class Crossword
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start(); // to calculate the time it took to solve the Puzzle

            Console.SetWindowSize(40, 24);  // Console.SetWindowSize(15, 24);
            int thisNumberOfTimes = 0; // to calculate how many iterations been done

            int checkX = 0; // Karakterleri yerleştirme ve okumada kullanılacak
            int checkY = 0; // Karakterleri yerleştirme ve okumada kullanılacak

            int solveSpeed = 0; // Puzzle çözülürken işlemler arasındaki boşta bekleme süresi

            // Puzzle Alanını Oluştur 
            #region [ Puzzle Alanı lineN[] ] 
            // Puzzle Alanını Oluştur 
            #region [ Puzzle Alanı lineN[] ] 
            Console.WriteLine("+++++++@+++++++");  // 1.  Satır
            Console.WriteLine("++++++@++++++@+");  // 2.  Satır
            Console.WriteLine("+++++++@+++++++");  // 3.  Satır
            Console.WriteLine("++++++@++++++@+");  // 4.  Satır
            Console.WriteLine("@+@++++@++++++@");  // 5.  Satır
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

            string[] lineN = new string[16]; //15
            lineN[0] = "+++++++@+++++++"; // 1.  Satır
            lineN[1] = "++++++@++++++@+"; // 2.  Satır
            lineN[2] = "+++++++@+++++++"; // 3.  Satır
            lineN[3] = "++++++@++++++@+"; // 4.  Satır
            lineN[4] = "@+@++++@++++++@"; // 5.  Satır
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
            lineN[15] = "@@@@@@@@@@@@@@@"; // block
            #endregion
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

            #region [ IsItEmpty ] - Bir string Array'in tamamen boş olup olmadığını bulur
            bool IsItEmpty(string[] myStringArray)
            {
                int i = 0;
                int emptyArrays = 0;
                while(i < myStringArray.Length)
                {
                    if (myStringArray[i] == null)
                    {
                        emptyArrays++;
                    }
                    i++;
                }
                if (emptyArrays == myStringArray.Length)
                {
                    return true;
                }
                else return false;              
            }
            #endregion

            #region [ GetWordSpaceHorizontal ] - Bulunulan noktadan sonraki "@" karakterine kadar olan sağa doğru yatay boşluğu hesaplar ve döndürür.
            int GetWordSpaceHorizontal(int checkX, int checkY)
            {
                Console.SetCursorPosition(checkX, checkY);
                string Line = lineN[checkY];
                string PartToCheckAfter = Line[checkX..15];
                int b = PartToCheckAfter.IndexOf("@");
                if (b == -1) { return (15-checkX); }
                return b;
            }
            #endregion

            #region [ GetWordSpaceVertical ] - Bulunulan noktadan sonraki "@" karakterine kadar olan aşağı doğru dikey boşluğu hesaplar ve döndürür.
            int GetWordSpaceVertical(int checkX, int checkY)
            {
                string storedWord = "";
                Console.SetCursorPosition(checkX, checkY);
                string Line = lineN[checkY];
                for (var i = 0; i < 10; i++)
                {
                    if (Line.Substring(checkX, 1) != "@") // this was>  if (Line.Substring(checkX, checkX + 1) != "@")
                    {
                        storedWord = storedWord + Line.Substring(checkX,  1); // this was Line.Substring(checkX, checkX + 1);  
                        Console.SetCursorPosition(checkX, checkY + i);
                        if (i == 0)
                        {
                            Line = lineN[checkY + 1];
                        }
                        else Line = lineN[checkY + i + 1];
                    } else { return storedWord.Length; }
                }
                return storedWord.Length;
            }
            #endregion

            #region [ TypeVertically ] - 
            string TypeVertically(string Word) //, int wordLength
            {
                int wordLength = Word.Length; // added this after
                for (int i = 0; i < wordLength; i++)
                {                    
                    #region To use later on
                    // string d1 = lineN[checkY].Substring(0, 1 + i);
                    // string d2 = lineN[checkY].Substring(i + 1, 14 - (1 + i));
                    #endregion To use later on
                    string a = Word.Substring(i, 1);
                    string d1 = lineN[checkY].Substring(0, checkX);
                    string d2 = lineN[checkY].Substring(checkX + 1, 15 - (1 + checkX));
                    if (checkX == 0)
                    {
                        lineN[checkY] = a + d2;
                    } else lineN[checkY] = d1 + a + d2;

                    Console.CursorTop = checkY;
                    Console.CursorLeft = checkX;
                    Console.WriteLine(a);
                    
                    if (i == 0)
                    {
                        Console.SetCursorPosition(checkX, checkY);
                    } else { Console.SetCursorPosition(checkX, checkY); }
                    checkY++;
                    System.Threading.Thread.Sleep(solveSpeed);
                }
                checkY = Console.CursorTop;
                return "";                
            }
            #endregion

            #region [ TypeVerticallySemi ] - 
            string TypeVerticallySemi(string Word)
            {
                int wordLength = Word.Length;
                for (int i = 0;    i < wordLength;     i++)
                {                    
                    string a = Word.Substring(0 + i, wordLength+1-wordLength);                  
                    Console.Write(a);
                    if (i == 0)
                    {
                        Console.CursorTop++; Console.CursorLeft--;
                    }
                    else { Console.CursorTop++; Console.CursorLeft--; }
                }
                return "";
            }
            #endregion

            #region [ ReadVertically ] - Returns the word written below the checkX and CheckY 
            string ReadVertically(int checkX, int checkY)
            {
                string readWord = "";
                Console.SetCursorPosition(checkX, checkY);
                string Line = lineN[checkY];
                for (var i = 0; i < 10; i++)
                {
                    var v = Line.Substring(checkX, checkX + 1);
                    if ((Line.Substring(checkX, checkX+1) != "@") && (Line.Substring(checkX, checkX+1) != "+"))
                    {
                        
                        readWord = readWord + Line.Substring(checkX, checkX+1);
                        Console.SetCursorPosition(checkX, checkY + i);
                        if (i == 0)
                        {
                            Line = lineN[checkY + 1];
                        }
                        else Line = lineN[checkY + i + 1];
                    }
                    else { return readWord; }
                }
                return readWord;
            }
            #endregion

            #region [ PickWord ] - int a = karakter sayısı olmak üzere bir kelime döndürür
            string PickWord(int a) // Minimum value is 3 max is 10
            {
                if (a == 3)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list3Letter.Length);
                    string[] shadowArray = new string[2];
                    System.Array.Copy(list3Letter, shadowArray, list3Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } 
                if (a == 4)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list4Letter.Length);
                    string[] shadowArray = new string[14];
                    System.Array.Copy(list4Letter, shadowArray, list4Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } 
                if (a == 5)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list5Letter.Length);
                    string[] shadowArray = new string[7];
                    System.Array.Copy(list5Letter, shadowArray, list5Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } 
                if (a == 6)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list6Letter.Length);
                    string[] shadowArray = new string[16];
                    System.Array.Copy(list6Letter, shadowArray, list6Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } 
                if (a == 7)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list7Letter.Length);
                    string[] shadowArray = new string[10];
                    System.Array.Copy(list7Letter, shadowArray, list7Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } 
                if (a == 8)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list8Letter.Length);
                    string[] shadowArray = new string[6];
                    System.Array.Copy(list8Letter, shadowArray, list8Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } 
                if (a == 9)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list9Letter.Length);
                    string[] shadowArray = new string[2];
                    System.Array.Copy(list9Letter, shadowArray, list9Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } 
                if (a == 10)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list10Letter.Length);
                    string[] shadowArray = new string[2];
                    System.Array.Copy(list10Letter, shadowArray, list10Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                }
                return "";
            }
            #endregion

            #region [ CheckWordInOrder ] - int a = karakter sayısı olmak üzere bir kelime döndürür
            string CheckWordInOrder(int a) // Minimum value is 3 max is 10
            {
                if (a == 3)
                {
                    int n = 0;
                    while (list3Letter[n] == "" && n < list3Letter.Length - 1)
                    {                                              
                        n++;
                    }
                    if (list3Letter[n] == "" && n == list3Letter.Length - 1)
                    {                      
                        return "WordNotFound";                       
                    }
                    string saveBeforeDeleting = list3Letter[n];
                    list3Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else
                if (a == 4)
                {
                    int n = 0;
                    while (list4Letter[n] == "" && n < list4Letter.Length - 1)
                    {
                        n++;
                    }
                    if (list4Letter[n] == "" && n == list4Letter.Length - 1)
                    {
                        return "WordNotFound";
                    }
                    string saveBeforeDeleting = list4Letter[n];
                    list4Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else
                if (a == 5)
                {
                    int n = 0;
                    while (list5Letter[n] == "" && n < list5Letter.Length - 1)
                    {
                        n++;
                    }
                    if (list5Letter[n] == "" && n == list5Letter.Length - 1)
                    {
                        return "WordNotFound";
                    }
                    string saveBeforeDeleting = list5Letter[n];
                    list5Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else
                if (a == 6)
                {
                    int n = 0;
                    while (list6Letter[n] == "" && n < list6Letter.Length - 1)
                    {
                        n++;
                    }
                    if (list6Letter[n] == "" && n == list6Letter.Length - 1)
                    {
                        return "WordNotFound";
                    }
                    string saveBeforeDeleting = list6Letter[n];
                    list6Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else
                if (a == 7)
                {
                    int n = 0;
                    while (list7Letter[n] == "" && n < list7Letter.Length - 1)
                    {
                        n++;
                    }
                    if (list7Letter[n] == "" && n == list7Letter.Length - 1)
                    {
                        return "WordNotFound";
                    }
                    string saveBeforeDeleting = list7Letter[n];
                    list7Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else
                if (a == 8)
                {
                    int n = 0;
                    while (list8Letter[n] == "" && n < list8Letter.Length - 1)
                    {
                        n++;
                    }
                    if (list8Letter[n] == "" && n == list8Letter.Length - 1)
                    {
                        return "WordNotFound";
                    }
                    string saveBeforeDeleting = list8Letter[n];
                    list8Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else
                if (a == 9)
                {
                    int n = 0;
                    while (list9Letter[n] == "" && n < list9Letter.Length - 1)
                    {
                        n++;
                    }
                    if (list9Letter[n] == "" && n == list9Letter.Length - 1)
                    {
                        return "WordNotFound";
                    }
                    string saveBeforeDeleting = list9Letter[n];
                    list9Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else
                if (a == 10)
                {
                    int n = 0;
                    while (list10Letter[n] == "" && n < list10Letter.Length - 1)
                    {
                        n++;
                    }
                    if (list10Letter[n] == "" && n == list10Letter.Length - 1)
                    {
                        return "WordNotFound";
                    }
                    string saveBeforeDeleting = list10Letter[n];
                    list10Letter[n] = "";
                    return saveBeforeDeleting;
                }
                else return "";
            }
            #endregion

            #region [ Reset Lines & Word Arrays]
            void ResetThePuzzle()
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                checkX = 0;
                checkY = 0;
                // Re-write the Puzzle
                // Puzzle Alanını Oluştur 
                #region [ Puzzle Alanı lineN[] ] 
                Console.WriteLine("+++++++@+++++++");  // 1.  Satır
                Console.WriteLine("++++++@++++++@+");  // 2.  Satır
                Console.WriteLine("+++++++@+++++++");  // 3.  Satır
                Console.WriteLine("++++++@++++++@+");  // 4.  Satır
                Console.WriteLine("@+@++++@++++++@");  // 5.  Satır
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

                //string[] lineN = new string[15]; //15
                lineN[0] = "+++++++@+++++++"; // 1.  Satır
                lineN[1] = "++++++@++++++@+"; // 2.  Satır
                lineN[2] = "+++++++@+++++++"; // 3.  Satır
                lineN[3] = "++++++@++++++@+"; // 4.  Satır
                lineN[4] = "@+@++++@++++++@"; // 5.  Satır
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
                lineN[15] = "@@@@@@@@@@@@@@@"; // block
                #endregion

                //string[] list3Letter = new string[2];
                list3Letter[0] = "GNU";
                list3Letter[1] = "TOE";

                //string[] list4Letter = new string[14];
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

                //string[] list5Letter = new string[7];
                list5Letter[0] = "AGREE";
                list5Letter[1] = "EMILE";
                list5Letter[2] = "GELID";
                list5Letter[3] = "IVORY";
                list5Letter[4] = "RAINS";
                list5Letter[5] = "SOLES";
                list5Letter[6] = "SPUDS";

                //string[] list6Letter = new string[16];
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

                //string[] list7Letter = new string[10];
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

                //string[] list8Letter = new string[6];
                list8Letter[0] = "AMORETTO";
                list8Letter[1] = "INVESTOR";
                list8Letter[2] = "PERICARP";
                list8Letter[3] = "SNOWSHOE";
                list8Letter[4] = "SURVIVAL";
                list8Letter[5] = "UNCLOAKS";

                //string[] list9Letter = new string[2];
                list9Letter[0] = "EASTEREGG";
                list9Letter[1] = "RETURNING";

                //string[] list10Letter = new string[2];
                list10Letter[0] = "UNDERNEATH";
                list10Letter[1] = "VIRTUOSITY";

                thisNumberOfTimes++;
            }
            #endregion

            #region [ read1Letter ] reads a char on the given (x,y)
            char read1Letter(int checkX, int checkY)
            {
                Console.SetCursorPosition(checkX, checkY);
                string Line = lineN[checkY];
                char readLetter = char.Parse(Line.Substring(checkX, 1));
                Console.SetCursorPosition(checkX, checkY); // This line is probably unnecessary, should delete          
                return readLetter; 
            }
            #endregion

            #region [ DeleteWordFromArray ]
            void DeleteWordFromArray(string[] array, string word)
            {

                int i = 0;
                while(array[i] != null)
                { 
                    if (array[i].Contains(word))
                    {
                        array[i] = null;
                    }
                    if (i<array.Length-1)
                    {
                        i++;
                    } else { break; }
                }
                while(array[i] == null && (i+1 != array.Length))
                {
                    i++;                  
                }                           

            }
            #endregion

            #region [ getTheArray ] - Removes the given word from the list its inside
            string[] getTheArray(int wordLength)
            {               
                if (wordLength == 3)
                {
                    return list3Letter;                   
                }
                if (wordLength == 4)
                {
                    return list4Letter;
                }
                if (wordLength == 5)
                {
                    return list5Letter;
                }
                if (wordLength == 6)
                {
                    return list6Letter;
                }
                if (wordLength == 7)
                {
                    return list7Letter;
                }
                if (wordLength == 8)
                {
                    return list8Letter;
                }
                if (wordLength == 9)
                {
                    return list9Letter;
                }
                if (wordLength == 10)
                {
                    return list10Letter;
                }
                return null;
            }
            #endregion

            System.Threading.Thread.Sleep(solveSpeed);
        #region Auto Solver NEW
        start:
            ResetThePuzzle();
            Console.SetCursorPosition(0, 0);
            string Line = lineN[checkY];
            checkX = Console.CursorLeft;
            checkY = Console.CursorTop;
        #region PART [1] START
            
            #region Type the first word at (0,0)                
            if ((Line.Substring(checkX, checkX) != "@") && (Line.Substring(checkX, checkX + 2) != "@"))
            {
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string hWord = PickWord(hLength);
                // Re-write the lineN[] array with the hWord included
                string restOfTheLine = lineN[checkY].Substring(hLength, 15 - hLength);
                lineN[checkY] = hWord + restOfTheLine;
                // Delete the used word from the array its in
                DeleteWordFromArray(getTheArray(hLength), hWord);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(hWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the First VERTICAL Letter and pick a word that starts with that letter to type with it (Aiming to pick "APER" by chance)
            {
                checkX = 0;
                checkY = 0; // go to (0, 0)               
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                int vSpace = GetWordSpaceVertical(Console.CursorLeft, Console.CursorTop);
                string pickedWord = PickWord(vSpace);

                int tryN = 0;
                if (pickedWord != "" && pickedWord != null)
                {
                    while ((pickedWord.ElementAt(0) != letter) && tryN < 41)
                    {
                        pickedWord = PickWord(vSpace);
                        if (tryN >= 40)
                        {
                            goto start;
                        }
                        tryN++;
                    }
                }
                TypeVertically(pickedWord);
                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the (0, 1) letter and type a HORIZONTAL word with it
            {
                checkX = 0;
                checkY = 1; // go to (0, 1)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = PickWord(hLength);

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 41)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 40)
                    {
                        goto start;
                    }
                    tryN++;
                }

                // Re-write the lineN[] array with the hWord included
                string restOfTheLine = lineN[checkY].Substring(hLength, 15 - hLength);
                lineN[checkY] = pickedWord + restOfTheLine;
                // Delete the used word from the array its in
                DeleteWordFromArray(getTheArray(hLength), pickedWord);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the (0, 2) letter and type a HORIZONTAL word with it
            {
                checkX = 0;
                checkY = 2; // go to (0, 2)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = PickWord(hLength);

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 41)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 40)
                    {
                        goto start;
                    }
                    tryN++;
                }

                // Re-write the lineN[] array with the hWord included
                string restOfTheLine = lineN[checkY].Substring(hLength, 15 - hLength);
                lineN[checkY] = pickedWord + restOfTheLine;
                // Delete the used word from the array its in
                DeleteWordFromArray(getTheArray(hLength), pickedWord);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the (0, 3) letter and type a HORIZONTAL word with it
            {
                checkX = 0;
                checkY = 3; // go to (0, 3)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = PickWord(hLength); 

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 41)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 40)
                    {
                        goto start;
                    }
                }

                // Re-write the lineN[] array with the hWord included
                string restOfTheLine = lineN[checkY].Substring(hLength, 15 - hLength);
                lineN[checkY] = pickedWord + restOfTheLine;
                // Delete the used word from the array its in
                DeleteWordFromArray(getTheArray(hLength), pickedWord);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #endregion PART [1] END

            #region PART [2] START

            #region Check 4 letters Type the VERTICAL word created at (1,0) (aiming to pick "MODERN" by chance) // Done, working
            {
                checkX = 1;
                checkY = 0; // go to (1, 0)
                Console.SetCursorPosition(checkX, checkY);
            
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop+1);
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop+1);
                char letter4 = read1Letter(Console.CursorLeft, Console.CursorTop+1);
                // Get vertical space 
                Console.CursorLeft = 1;
                Console.CursorTop = 0;           
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 1;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);
                char let4 = pickedWord.ElementAt(3);

                int tryN = 0; 
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next1;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41) 
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            let4 = pickedWord.ElementAt(3);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next1;
                            }
                            tryN++;
                        }
                        goto start;
                    }                   
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion 
        next1:
            #region Check 4 letters Type the VERTICAL word created at (3,0) (aiming to pick "NATIVE" by chance) // Done, working
            {
                checkX = 3;
                checkY = 0; // go to (1, 0)
                Console.SetCursorPosition(checkX, checkY);

                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                char letter4 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                // Get vertical space 
                Console.CursorLeft = 3;
                Console.CursorTop = 0;
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 3;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);
                char let4 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next1;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            let4 = pickedWord.ElementAt(3);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next2;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next2:
            #region Check 4 letters Type the VERTICAL word created at (4,0) (aiming to pick "ICINESS" by chance) // Done, working
            {
                checkX = 4;
                checkY = 0; // go to (1, 0)
                Console.SetCursorPosition(checkX, checkY);

                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                char letter4 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                // Get vertical space 
                Console.CursorLeft = 4;
                Console.CursorTop = 0;
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 4;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);
                char let4 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next1;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            let4 = pickedWord.ElementAt(3);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next3;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next3:
            #region Check 4 letters Type the VERTICAL word created at (5,0) (aiming to pick "TENANT" by chance) // Done, working
            {
                checkX = 5;
                checkY = 0; // go to (1, 0)
                Console.SetCursorPosition(checkX, checkY);

                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                char letter4 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                // Get vertical space 
                Console.CursorLeft = 5;
                Console.CursorTop = 0;
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 5;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);
                char let4 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next1;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            let4 = pickedWord.ElementAt(3);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next4;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next4:
            #region Check the (3, 4) 3 letter and type a HORIZONTAL word with it (aiming to pick "VENT" by chance) // Done, working
            {
                checkX = 3;
                checkY = 4; // go to (3, 4) 
                Console.CursorLeft = 3;
                Console.CursorTop = 4;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 3;
                Console.CursorTop = 4;
                char letter2 = read1Letter(Console.CursorLeft + 1, Console.CursorTop);
                Console.CursorLeft = 3;
                Console.CursorTop = 4;
                char letter3 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 3;
                Console.CursorTop = 4;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 3;
                Console.CursorTop = 4;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next5;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next5;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next5:
            #region Check the (0, 5) 4 letter and type a HORIZONTAL word with it (aiming to pick "INVESTOR" by chance) // Done, working
            {
                checkX = 0;
                checkY = 5; // go to (0, 5) 
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft+1, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                char letter2 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                char letter3 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                char letter4 = read1Letter(Console.CursorLeft + 5, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);
                char let2 = pickedWord.ElementAt(3);
                char let3 = pickedWord.ElementAt(4);
                char let4 = pickedWord.ElementAt(5);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next6;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next6;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion       
        next6:
            #region Check the First VERTICAL Letter at (0,5) and pick a word that starts with that letter to type with it (Aiming to pick "IVORY" by chance) // Done, working
            {
                checkX = 0;
                checkY = 5; // go to (0, 5)               
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                int vSpace = GetWordSpaceVertical(Console.CursorLeft, Console.CursorTop);
                string pickedWord = "IVORY"; // replace string pickedWord = PickWord(vSpace);

                int tryN = 0;
                if (pickedWord != "" && pickedWord != null)
                {
                    while ((pickedWord.ElementAt(0) != letter) && tryN < 41)
                    {
                        pickedWord = PickWord(vSpace);
                        if (tryN >= 40)
                        {
                            goto start;
                        }
                        tryN++;
                    }
                }
                TypeVertically(pickedWord);
                // Delete the used word from the array its in
                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next7:
            #region Check the (0, 7) letter and type a HORIZONTAL word with it // aiming to pick "OARS" by chance // Done working
            {
                checkX = 0;
                checkY = 7; // go to (0, 7)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = "OARS"; // replace string pickedWord = PickWord(hLength);

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 41)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 40)
                    {
                        goto start;
                    }
                    tryN++;
                }

                // Re-write the lineN[] array with the hWord included
                string restOfTheLine = lineN[checkY].Substring(hLength, 15 - hLength);
                lineN[checkY] = pickedWord + restOfTheLine;
                // Delete the used word from the array its in
                DeleteWordFromArray(getTheArray(hLength), pickedWord);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next8:
            #region Check 2 letters Type the VERTICAL word created at (2,5) (aiming to pick "VIRTUOSITY" by chance) // Done, working
            {
                checkX = 2;
                checkY = 5; // go to (2, 5)
                Console.SetCursorPosition(checkX, checkY);

                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 2);
                // Get vertical space 
                Console.CursorLeft = 2;
                Console.CursorTop = 5;
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 2;
                Console.CursorTop = 5;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next9;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next9;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next9:
            #region Check the (0, 9) letter and type a HORIZONTAL word with it // aiming to pick "YOUR" by chance // Done working
            {
                checkX = 0;
                checkY = 9; // go to (0, 9)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = "YOUR"; // replace string pickedWord = PickWord(hLength);

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 41)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 40)
                    {
                        goto start;
                    }
                    tryN++;
                }

                // Re-write the lineN[] array with the hWord included
                string restOfTheLine = lineN[checkY].Substring(hLength, 15 - hLength);
                lineN[checkY] = pickedWord + restOfTheLine;
                // Delete the used word from the array its in
                DeleteWordFromArray(getTheArray(hLength), pickedWord);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next10:
            #region Check the (0, 8) 4 letter and type a HORIZONTAL word with it (aiming to pick "RETURNING" by chance)
            {
                checkX = 0;
                checkY = 8; // go to (0, 5) 
                Console.CursorLeft = 0;
                Console.CursorTop = 8;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 8;
                char letter2 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 0;
                Console.CursorTop = 8;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) ) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next11;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(2);
                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next11;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next11:
            #region Check 3 letters Type the VERTICAL word created at (3,7) (aiming to pick "SURVIVAL" by chance) // Done, working
            {
                checkX = 3;
                checkY = 7; // go to (3, 7)
                Console.SetCursorPosition(checkX, checkY);

                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 3;
                Console.CursorTop = 7;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                Console.CursorLeft = 3;
                Console.CursorTop = 7;
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 2);
                // Get vertical space 
                Console.CursorLeft = 3;
                Console.CursorTop = 7;
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 3;
                Console.CursorTop = 7;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next12;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next12;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next12:
            #region Check the (1, 10) 1 letter and type a HORIZONTAL word with it (aiming to pick "NOVELS" by chance)
            {
                checkX = 1;
                checkY = 10; // go to (1, 10) 
                Console.CursorLeft = 1;
                Console.CursorTop = 10;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft+1, Console.CursorTop);
                Console.CursorLeft = 1;
                Console.CursorTop = 10;
                char letter2 = read1Letter(Console.CursorLeft+2, Console.CursorTop);
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 1;
                Console.CursorTop = 10;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);
                char let2 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next13;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(1);
                            let2 = pickedWord.ElementAt(2);
                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next13;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next13:
            #region Check the (2, 11) 2 letter and type a HORIZONTAL word with it (aiming to pick "SIMOOM" by chance)
            {
                checkX = 2;
                checkY = 11; // go to (1, 10) 
                Console.CursorLeft = 2;
                Console.CursorTop = 11;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 2;
                Console.CursorTop = 11;
                char letter2 = read1Letter(Console.CursorLeft + 1, Console.CursorTop);
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 2;
                Console.CursorTop = 11;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next14;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next14;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next14:
            #region Check 2 letters Type the VERTICAL word created at (4,10) (aiming to pick "EMILE" by chance) // Done, working
            {
                checkX = 4;
                checkY = 10; // go to (4, 10)
                Console.SetCursorPosition(checkX, checkY);

                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 4;
                Console.CursorTop = 10;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                Console.CursorLeft = 4;
                Console.CursorTop = 10;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 4;
                Console.CursorTop = 10;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next15;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next15;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next15:
            #region Check the (0, 14) 2 letter and type a HORIZONTAL word with it (aiming to pick "RAYLESS" by chance)
            {
                checkX = 0;
                checkY = 14; // go to (0, 14) 
                Console.CursorLeft = 0;
                Console.CursorTop = 14;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 14;
                char letter2 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 14;
                char letter3 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 0;
                Console.CursorTop = 14;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(2);
                char let2 = pickedWord.ElementAt(3);
                char let3 = pickedWord.ElementAt(4);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next16;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(2);
                            let2 = pickedWord.ElementAt(3);
                            let3 = pickedWord.ElementAt(4);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next16;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next16:
            #region Check the (0, 12) 2 letter and type a HORIZONTAL word with it (aiming to pick "TRIVIAL" by chance)
            {
                checkX = 0;
                checkY = 12; // go to (0, 12) 
                Console.CursorLeft = 0;
                Console.CursorTop = 12;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 12;
                char letter2 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 12;
                char letter3 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                Console.CursorLeft = 0;
                Console.CursorTop = 12;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 0;
                Console.CursorTop = 12;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(2);
                char let2 = pickedWord.ElementAt(3);
                char let3 = pickedWord.ElementAt(4);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next17;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(2);
                            let2 = pickedWord.ElementAt(3);
                            let3 = pickedWord.ElementAt(4);

                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next17;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next17:
            #region Check 2 letter Type the VERTICAL word created at (0,11) (aiming to pick "STIR" by chance) // Done, working
            {
                checkX = 0;
                checkY = 11; // go to (4, 10)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                Console.CursorLeft = 0;
                Console.CursorTop = 11;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 3);
                Console.CursorLeft = 0;
                Console.CursorTop = 11;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 0;
                Console.CursorTop = 11;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);
                char let2 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next18;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(1);
                            let2 = pickedWord.ElementAt(3);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next18;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next18:
            #region Check 5 letter Type the VERTICAL word created at (5,7) (aiming to pick "UNCLOAKS" by chance) // Done, working
            {
                checkX = 5  ;
                checkY = 7; // go to (5, 7)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                Console.CursorLeft = 5;
                Console.CursorTop = 7;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 3);
                Console.CursorLeft = 5;
                Console.CursorTop = 7;
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 4);
                Console.CursorLeft = 5;
                Console.CursorTop = 7;
                char letter4 = read1Letter(Console.CursorLeft, Console.CursorTop + 5);
                Console.CursorLeft = 5;
                Console.CursorTop = 7;
                char letter5 = read1Letter(Console.CursorLeft, Console.CursorTop + 7);
                Console.CursorLeft = 5;
                Console.CursorTop = 7;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 5;
                Console.CursorTop = 7;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);
                char let2 = pickedWord.ElementAt(3);
                char let3 = pickedWord.ElementAt(4);
                char let4 = pickedWord.ElementAt(5);
                char let5 = pickedWord.ElementAt(7);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4) && (let5 == letter5)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next19;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(1);
                            let2 = pickedWord.ElementAt(3);
                            let3 = pickedWord.ElementAt(4);
                            let4 = pickedWord.ElementAt(5);
                            let5 = pickedWord.ElementAt(7);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4) && (let5 == letter5)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next19;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next19:
            #region Check the (2, 13) 3 letter and type a HORIZONTAL word with it (aiming to pick "TALKER" by chance)
            {
                checkX = 2;
                checkY = 13; // go to (2, 13) 
                Console.CursorLeft = 2;
                Console.CursorTop = 13;
                // read already written 3 letters
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 2;
                Console.CursorTop = 13;
                char letter2 = read1Letter(Console.CursorLeft + 1, Console.CursorTop);
                Console.CursorLeft = 2;
                Console.CursorTop = 13;
                char letter3 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 2;
                Console.CursorTop = 13;
                char letter4 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 2;
                Console.CursorTop = 13;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 2;
                Console.CursorTop = 13;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);
                char let4 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next20;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            let4 = pickedWord.ElementAt(3);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next20;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next20:
            #region Check 2 letter Type the VERTICAL word created at (6,4) (aiming to pick "TOE" by chance) // Done, working
            {
                checkX = 6;
                checkY = 4; // go to (6, 4)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 6;
                Console.CursorTop = 4;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                Console.CursorLeft = 6;
                Console.CursorTop = 4;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 6;
                Console.CursorTop = 4;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next21;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next21;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next21:
            #region Check 2 letter Type the VERTICAL word created at (7,5) (aiming to pick "RAINS" by chance) // Done, working
            {
                checkX = 7;
                checkY = 5; // go to (7, 5)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 7;
                Console.CursorTop = 5;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 3);
                Console.CursorLeft = 7;
                Console.CursorTop = 5;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 7;
                Console.CursorTop = 5;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next22;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(3);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next22;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next22:
            #region Check the (6, 6) 2 letter and type a HORIZONTAL word with it (aiming to pick "EASTEREGG" by chance) // Done, working
            {
                checkX = 6;
                checkY = 6; // go to (6, 6) 
                Console.CursorLeft = 6;
                Console.CursorTop = 6;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 6;
                Console.CursorTop = 6;
                char letter2 = read1Letter(Console.CursorLeft + 1, Console.CursorTop);
                Console.CursorLeft = 6;
                Console.CursorTop = 6;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 6;
                Console.CursorTop = 6;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next23;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next23;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next23:
            #region Check 2 letter Type the VERTICAL word created at (8,8) (aiming to pick "GNU" by chance) // Done, working
            {
                checkX = 8;
                checkY = 8; // go to (8, 8)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 8;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 8;
                Console.CursorTop = 8;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next24;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);

                            if ((let1 == letter1)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next24;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next24:
            #region Check the (7, 9) 2 letter and type a HORIZONTAL word with it (aiming to pick "SNOWSHOE" by chance) // Done, working
            {
                checkX = 7;
                checkY = 9; // go to (7, 9) 
                Console.CursorLeft = 7;
                Console.CursorTop = 9;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 7;
                Console.CursorTop = 9;
                char letter2 = read1Letter(Console.CursorLeft + 1, Console.CursorTop);
                Console.CursorLeft = 7;
                Console.CursorTop = 9;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 7;
                Console.CursorTop = 9;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next25;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next25;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next25:
            #region Check 2 letter Type the VERTICAL word created at (10,8) (aiming to pick "SWOLLEN" by chance) // Done, working
            {
                checkX = 10;
                checkY = 8; // go to (10, 8)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop+1);
                Console.CursorLeft = 10;
                Console.CursorTop = 8;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 10;
                Console.CursorTop = 8;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next26;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(1);

                            if ((let1 == letter1)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next26;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next26:
            #region Check the (8, 14) 2 letter and type a HORIZONTAL word with it (aiming to pick "RENTERS" by chance) // Done, working
            {
                checkX = 8;
                checkY = 14; // go to (8, 14) 
                Console.CursorLeft = 8;
                Console.CursorTop = 14;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft+2, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 14;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 8;
                Console.CursorTop = 14;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next27;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(2);

                            if ((let1 == letter1)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next27;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
        next27:
            #region Check the (9, 11) 1 letter and type a HORIZONTAL word with it (aiming to pick "PLOVER" by chance) // Done, working
            {
                checkX = 9;
                checkY = 11; // go to (9, 11) 
                Console.CursorLeft = 9;
                Console.CursorTop = 11;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft+1, Console.CursorTop);
                Console.CursorLeft = 9;
                Console.CursorTop = 11;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 9;
                Console.CursorTop = 11;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next28;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(1);

                            if ((let1 == letter1)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next28;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next28:
            #region Check 2 letter Type the VERTICAL word created at (11,9) (aiming to pick "SNOCAT" by chance) // Done, working
            {
                checkX = 11;
                checkY = 9; // go to (11, 9)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 11;
                Console.CursorTop = 9;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 2);
                Console.CursorLeft = 11;
                Console.CursorTop = 9;
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 5);
                Console.CursorLeft = 11;
                Console.CursorTop = 9;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 11;
                Console.CursorTop = 9;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(2);
                char let3 = pickedWord.ElementAt(5);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next29;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(1);

                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next29;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next29:
            #region Check 1 letter Type the VERTICAL word created at (13,4) (aiming to pick "YOGI" by chance) // Done, working
            {
                checkX = 13;
                checkY = 4; // go to (13, 4)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop+2);
                Console.CursorLeft = 13;
                Console.CursorTop = 4;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 13;
                Console.CursorTop = 4;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next30;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(2);

                            if ((let1 == letter1)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next30;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next30:
            #region Check 1 letter Type the VERTICAL word created at (14,5) (aiming to pick "AGREE" by chance) // Done, working
            {
                checkX = 14;
                checkY = 5; // go to (14, 5)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                Console.CursorLeft = 14;
                Console.CursorTop = 5;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 4);
                Console.CursorLeft = 14;
                Console.CursorTop = 5;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 14;
                Console.CursorTop = 5;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);
                char let2 = pickedWord.ElementAt(4);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next31;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(1);
                            let2 = pickedWord.ElementAt(4);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next31;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next31:
            #region Check the (9, 13) 1 letter and type a HORIZONTAL word with it (aiming to pick "SEALED" by chance) // Done, working
            {
                checkX = 9;
                checkY = 13; // go to (9, 13) 
                Console.CursorLeft = 9;
                Console.CursorTop = 13;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 1, Console.CursorTop);
                Console.CursorLeft = 9;
                Console.CursorTop = 13;
                char letter2 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 9;
                Console.CursorTop = 13;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 9;
                Console.CursorTop = 13;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);
                char let2 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next32;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(1);
                            let2 = pickedWord.ElementAt(2);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next32;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next32:
            #region Check the (8, 12) 1 letter and type a HORIZONTAL word with it (aiming to pick "VOLCANO" by chance) // Done, working
            {
                checkX = 8;
                checkY = 12; // go to (8, 12) 
                Console.CursorLeft = 8;
                Console.CursorTop = 12;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 12;
                char letter2 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 12;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 8;
                Console.CursorTop = 12;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(2);
                char let2 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next33;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(2);
                            let2 = pickedWord.ElementAt(3);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next33;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next33:
            #region Check the (11, 7) 1 letter and type a HORIZONTAL word with it (aiming to pick "PAIR" by chance) // Done, working
            {
                checkX = 11;
                checkY = 7; // go to (11, 7) 
                Console.CursorLeft = 11;
                Console.CursorTop = 7;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 11;
                Console.CursorTop = 7;
                char letter2 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 11;
                Console.CursorTop = 7;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 11;
                Console.CursorTop = 7;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(2);
                char let2 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next34;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(2);
                            let2 = pickedWord.ElementAt(3);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next34;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next34:
            #region Check 3 letter Type the VERTICAL word created at (12,0) (aiming to pick "UNDERNEATH" by chance) // Done, working
            {
                checkX = 12;
                checkY = 0; // go to (12, 0)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop + 6);
                Console.CursorLeft = 12;
                Console.CursorTop = 0;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 7);
                Console.CursorLeft = 12;
                Console.CursorTop = 0;
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 9);
                Console.CursorLeft = 12;
                Console.CursorTop = 0;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 12;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(5);
                char let2 = pickedWord.ElementAt(7);
                char let3 = pickedWord.ElementAt(9);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next35;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(6);
                            let2 = pickedWord.ElementAt(7);
                            let3 = pickedWord.ElementAt(9);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next35;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next35:
            #region Check the (11, 5) 3 letter and type a HORIZONTAL word with it (aiming to pick "ANOA" by chance) // Done, working
            {
                checkX = 11;
                checkY = 5; // go to (11, 5) 
                Console.CursorLeft = 11;
                Console.CursorTop = 5;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 1, Console.CursorTop);
                Console.CursorLeft = 11;
                Console.CursorTop = 5;
                char letter2 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 11;
                Console.CursorTop = 5;
                char letter3 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 11;
                Console.CursorTop = 5;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 11;
                Console.CursorTop = 5;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(1);
                char let2 = pickedWord.ElementAt(2);
                char let3 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next36;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(1);
                            let2 = pickedWord.ElementAt(2);
                            let3 = pickedWord.ElementAt(3);

                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next36;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next36:
            #region Check 3 letter Type the VERTICAL word created at (11,0) (aiming to pick "PERICARP" by chance) // Done, working
            {
                checkX = 11;
                checkY = 0; // go to (11, 0)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop + 5);
                Console.CursorLeft = 11;
                Console.CursorTop = 0;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 6);
                Console.CursorLeft = 11;
                Console.CursorTop = 0;
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 7);
                Console.CursorLeft = 11;
                Console.CursorTop = 0;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 11;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(5);
                char let2 = pickedWord.ElementAt(6);
                char let3 = pickedWord.ElementAt(7);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next37;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(5);
                            let2 = pickedWord.ElementAt(6);
                            let3 = pickedWord.ElementAt(7);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next37;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next37:
            #region Check the (8, 5) 2 letter and type a HORIZONTAL word with it (aiming to pick "GASPUMP" by chance) // Done, working
            {
                checkX = 8;
                checkY = 0; // go to (8, 0) 
                Console.CursorLeft = 8;
                Console.CursorTop = 0;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 0;
                char letter2 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 0;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 8;
                Console.CursorTop = 0;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(3);
                char let2 = pickedWord.ElementAt(4);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next38;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(3);
                            let2 = pickedWord.ElementAt(4);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next38;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next38:
            #region Check the (7, 1) 2 letter and type a HORIZONTAL word with it (aiming to pick "HEMPEN" by chance) // Done, working
            {
                checkX = 7;
                checkY = 1; // go to (7, 1) 
                Console.CursorLeft = 7;
                Console.CursorTop = 1;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                Console.CursorLeft = 7;
                Console.CursorTop = 1;
                char letter2 = read1Letter(Console.CursorLeft + 5, Console.CursorTop);
                Console.CursorLeft = 7;
                Console.CursorTop = 1;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 7;
                Console.CursorTop = 1;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(4);
                char let2 = pickedWord.ElementAt(5);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next39;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(4);
                            let2 = pickedWord.ElementAt(5);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next39;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next39:
            #region Check the (8, 2) 2 letter and type a HORIZONTAL word with it (aiming to pick "LOURDES" by chance) // Done, working
            {
                checkX = 8;
                checkY = 2; // go to (8, 2) 
                Console.CursorLeft = 8;
                Console.CursorTop = 2;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 2;
                char letter2 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 2;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 8;
                Console.CursorTop = 2;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(3);
                char let2 = pickedWord.ElementAt(4);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next40;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(3);
                            let2 = pickedWord.ElementAt(4);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next40;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next40:
            #region Check the (7, 3) 2 letter and type a HORIZONTAL word with it (aiming to pick "HEMPEN" by chance) // Done, working
            {
                checkX = 7;
                checkY = 3; // go to (7, 3) 
                Console.CursorLeft = 7;
                Console.CursorTop = 3;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                Console.CursorLeft = 7;
                Console.CursorTop = 3;
                char letter2 = read1Letter(Console.CursorLeft + 5, Console.CursorTop);
                Console.CursorLeft = 7;
                Console.CursorTop = 3;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 7;
                Console.CursorTop = 3;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(4);
                char let2 = pickedWord.ElementAt(5);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next41;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(4);
                            let2 = pickedWord.ElementAt(5);

                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next41;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next41:
            #region Check the (8, 4) 3 letter and type a HORIZONTAL word with it (aiming to pick "DESCRY" by chance) // Done, working
            {
                checkX = 8;
                checkY = 4; // go to (8, 4) 
                Console.CursorLeft = 8;
                Console.CursorTop = 4;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 4;
                char letter2 = read1Letter(Console.CursorLeft + 4, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 4;
                char letter3 = read1Letter(Console.CursorLeft + 5, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 4;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 8;
                Console.CursorTop = 4;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(3);
                char let2 = pickedWord.ElementAt(4);
                char let3 = pickedWord.ElementAt(5);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next42;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(3);
                            let2 = pickedWord.ElementAt(4);
                            let3 = pickedWord.ElementAt(5);

                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next42;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next42:
            #region Check 6 letter Type the VERTICAL word created at (9,0) (aiming to pick "AMORETTO" by chance) // Done, working
            {
                checkX = 9;
                checkY = 0; // go to (9, 0)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 9;
                Console.CursorTop = 0;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 1);
                Console.CursorLeft = 9;
                Console.CursorTop = 0;
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 2);
                Console.CursorLeft = 9;
                Console.CursorTop = 0;
                char letter4 = read1Letter(Console.CursorLeft, Console.CursorTop + 3);
                Console.CursorLeft = 9;
                Console.CursorTop = 0;
                char letter5 = read1Letter(Console.CursorLeft, Console.CursorTop + 4);
                Console.CursorLeft = 9;
                Console.CursorTop = 0;
                char letter6 = read1Letter(Console.CursorLeft, Console.CursorTop + 6);
                Console.CursorLeft = 9;
                Console.CursorTop = 0;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 9;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(1);
                char let3 = pickedWord.ElementAt(2);
                char let4 = pickedWord.ElementAt(3);
                char let5 = pickedWord.ElementAt(4);
                char let6 = pickedWord.ElementAt(6);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4) && (let5 == letter5) && (let6 == letter6)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next43;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(1);
                            let3 = pickedWord.ElementAt(2);
                            let4 = pickedWord.ElementAt(3);
                            let5 = pickedWord.ElementAt(4);
                            let6 = pickedWord.ElementAt(6);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4) && (let5 == letter5) && (let6 == letter6)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next43;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next43:
            #region Check the (8, 10) 3 letter and type a HORIZONTAL word with it (aiming to pick "UPON" by chance) // Done, working
            {
                checkX = 8;
                checkY = 10; // go to (8, 10) 
                Console.CursorLeft = 8;
                Console.CursorTop = 10;
                // read already written 2 letters
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 10;
                char letter2 = read1Letter(Console.CursorLeft + 2, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 10;
                char letter3 = read1Letter(Console.CursorLeft + 3, Console.CursorTop);
                Console.CursorLeft = 8;
                Console.CursorTop = 10;
                // Get horizontal space 
                int hSpace = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above           
                Console.CursorLeft = 8;
                Console.CursorTop = 10;
                string pickedWord = PickWord(hSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(2);
                char let3 = pickedWord.ElementAt(3);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                    {
                        string d1 = lineN[checkY].Substring(0, checkX); // doğru
                        string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                        lineN[checkY] = d1 + pickedWord + d2;
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                        Console.WriteLine(pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next44;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(hSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(2);
                            let3 = pickedWord.ElementAt(3);

                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3)) // If "correct word" is picked, type it
                            {
                                string d1 = lineN[checkY].Substring(0, checkX); // doğru
                                string d2 = lineN[checkY].Substring(checkX + hSpace, 15 - (checkX + hSpace)); //fix that
                                lineN[checkY] = d1 + pickedWord + d2;
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(hSpace), pickedWord);
                                Console.WriteLine(pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next44;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                }
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next44:
            #region Check 5 letter Type the VERTICAL word created at (13,9) (aiming to pick "OPENER" by chance) // Done, working
            {
                checkX = 13;
                checkY = 9; // go to (13, 9)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 13;
                Console.CursorTop = 9;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 2);
                Console.CursorLeft = 13;
                Console.CursorTop = 9;
                char letter3 = read1Letter(Console.CursorLeft, Console.CursorTop + 3);
                Console.CursorLeft = 13;
                Console.CursorTop = 9;
                char letter4 = read1Letter(Console.CursorLeft, Console.CursorTop + 4);
                Console.CursorLeft = 13;
                Console.CursorTop = 9;
                char letter5 = read1Letter(Console.CursorLeft, Console.CursorTop + 5);
                Console.CursorLeft = 13;
                Console.CursorTop = 9;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 13;
                Console.CursorTop = 9;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(2);
                char let3 = pickedWord.ElementAt(3);
                char let4 = pickedWord.ElementAt(4);
                char let5 = pickedWord.ElementAt(5);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4) && (let5 == letter5)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next45;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(2);
                            let3 = pickedWord.ElementAt(3);
                            let4 = pickedWord.ElementAt(4);
                            let5 = pickedWord.ElementAt(5);
                            if ((let1 == letter1) && (let2 == letter2) && (let3 == letter3) && (let4 == letter4) && (let5 == letter5)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next45;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next45:
            #region Check 2 letter Type the VERTICAL word created at (14,0) (aiming to pick "PASS" by chance) // Done, working
            {
                checkX = 14;
                checkY = 0; // go to (14, 0)
                Console.SetCursorPosition(checkX, checkY);
                char letter1 = read1Letter(Console.CursorLeft, Console.CursorTop);
                Console.CursorLeft = 14;
                Console.CursorTop = 0;
                char letter2 = read1Letter(Console.CursorLeft, Console.CursorTop + 2);
                Console.CursorLeft = 14;
                Console.CursorTop = 0;
                // Get vertical space 
                int vSpace = GetWordSpaceVertical(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                Console.CursorLeft = 14;
                Console.CursorTop = 0;
                string pickedWord = PickWord(vSpace);
                // Assing the first x letters to the variables below to check after and for a cleaner code
                char let1 = pickedWord.ElementAt(0);
                char let2 = pickedWord.ElementAt(2);

                int tryN = 0;
                if (pickedWord != null)
                {
                    if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                    {
                        TypeVertically(pickedWord);
                        // Delete the used word from the array its in
                        DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                        System.Threading.Thread.Sleep(solveSpeed);
                        goto next46;
                    }
                    else // If "correct word" is not picked, pick another word
                    {
                        while (tryN < 41)
                        {
                            pickedWord = PickWord(vSpace);
                            let1 = pickedWord.ElementAt(0);
                            let2 = pickedWord.ElementAt(2);
                            if ((let1 == letter1) && (let2 == letter2)) // If "correct word" is picked, type it
                            {
                                TypeVertically(pickedWord);
                                // Delete the used word from the array its in
                                DeleteWordFromArray(getTheArray(vSpace), pickedWord);
                                System.Threading.Thread.Sleep(solveSpeed);
                                goto next46;
                            }
                            tryN++;
                        }
                        goto start;
                    }
                } // else pickedWord = PickWord(vSpace); probably unnecessary?
                System.Threading.Thread.Sleep(solveSpeed);
            }
        #endregion
        next46:


        #endregion Auto Solver NEW ^^^^^^^^
        exit:
            Console.CursorTop = 16;
            watch.Stop();
            Console.WriteLine($"Puzzle {watch.ElapsedMilliseconds} ms'de ve {thisNumberOfTimes} Denemede Cozuldu.");
            System.Threading.Thread.Sleep(900000);
            Console.ReadLine(); // Kapanmak için tuş girişini bekle            

        }
    }
}

#endregion

// Yiğit Budur (120444012) Bilgi Üniversitesi