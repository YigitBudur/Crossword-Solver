﻿using System;
using System.Windows.Input;
using System.Collections.Generic; // do I need this?
using System.Linq;
using System.IO;

namespace CrosswordSolver
{
    class Crossword
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 24);           // Console.SetWindowSize(15, 24);
            int thisNumberOfTimes = 0;
            int wordLength;
            int checkX = 0; // Karakterleri yerleştirme ve okumada kullanılacak
            int checkY = 0; // Karakterleri yerleştirme ve okumada kullanılacak

            int solveSpeed = 0;
            int wLengthStorage = 0;
            //string storedWord = "";

            // Puzzle Alanını Oluştur 
            #region [ Puzzle Alanı lineN[] ] 
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

            string[] lineN = new string[15]; //15
            lineN[0]  = "+++++++@+++++++"; // 1.  Satır
            lineN[1]  = "++++++@++++++@+"; // 2.  Satır
            lineN[2]  = "+++++++@+++++++"; // 3.  Satır
            lineN[3]  = "++++++@++++++@+"; // 4.  Satır
            lineN[4]  = "@+@++++@+++++@+"; // 5.  Satır
            lineN[5]  = "++++++++@+@++++"; // 6.  Satır
            lineN[6]  = "+@+@+@+++++++++"; // 7.  Satır
            lineN[7]  = "++++@+@+@+@++++"; // 8.  Satır
            lineN[8]  = "+++++++++@+@+@+"; // 9.  Satır
            lineN[9]  = "++++@+@++++++++"; // 10. Satır
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

            static bool IsItEmpty(string[] myStringArray)
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
                
                //Source of this method: "https://www.codeproject.com/Questions/237141/how-to-check-string-array-is-Null-or-Empty"
            }

            void increaseLastIndex(int index)
            {
                if (index == 3)
                {
                    list3LastIndex++;
                }
                if (index == 4)
                {
                    list4LastIndex++;
                }
                if (index == 5)
                {
                    list5LastIndex++;
                }
                if (index == 6)
                {
                    list6LastIndex++;
                }
                if (index == 7)
                {
                    list7LastIndex++;
                }
                if (index == 8)
                {
                    list8LastIndex++;
                }
                if (index == 9)
                {
                    list9LastIndex++;
                }
                if (index == 10)
                {
                    list10LastIndex++;
                }
               
            }

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
                    string d1 = lineN[checkY].Substring(0, 1 + checkX);
                    string d2 = lineN[checkY].Substring(checkX + 1, 15 - (1 + checkX));
                    if (checkX == 0)
                    {
                        lineN[checkY] = a + d2;
                    } else lineN[checkY] = d1 + a + d2;

                    Console.CursorTop = checkY;
                    Console.WriteLine(a);
                    if (i == 0)
                    {
                        Console.SetCursorPosition(checkX, checkY);
                    } else { Console.SetCursorPosition(checkX, checkY); }
                    checkY++;
                    System.Threading.Thread.Sleep(solveSpeed);
                }
                return "";
                checkY = Console.CursorTop;
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
                    Array.Copy(list3Letter, shadowArray, list3Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } else
                if (a == 4)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list4Letter.Length);
                    string[] shadowArray = new string[14];
                    Array.Copy(list4Letter, shadowArray, list4Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } else
                if (a == 5)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list5Letter.Length);
                    string[] shadowArray = new string[7];
                    Array.Copy(list5Letter, shadowArray, list5Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } else
                if (a == 6)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list6Letter.Length);
                    string[] shadowArray = new string[16];
                    Array.Copy(list6Letter, shadowArray, list6Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } else
                if (a == 7)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list7Letter.Length);
                    string[] shadowArray = new string[10];
                    Array.Copy(list7Letter, shadowArray, list7Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } else
                if (a == 8)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list8Letter.Length);
                    string[] shadowArray = new string[6];
                    Array.Copy(list8Letter, shadowArray, list8Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } else
                if (a == 9)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list9Letter.Length);
                    string[] shadowArray = new string[2];
                    Array.Copy(list9Letter, shadowArray, list9Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                } else
                if (a == 10)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, list10Letter.Length);
                    string[] shadowArray = new string[2];
                    Array.Copy(list10Letter, shadowArray, list10Letter.Length);
                    while (shadowArray[number] == null)
                    {
                        number = rnd.Next(0, shadowArray.Length);
                    }
                    string saveBeforeDeleting = shadowArray[number];
                    shadowArray[number] = null;
                    return saveBeforeDeleting;
                }
                else return "";
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

                //string[] lineN = new string[15]; //15
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

            #region 
            char read1Letter(int checkX, int checkY)
            {
                Console.SetCursorPosition(checkX, checkY);
                string Line = lineN[checkY];
                char readLetter = char.Parse(Line.Substring(checkX, 1));
                Console.SetCursorPosition(checkX, checkY);               
                return readLetter; 
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
                lineN[checkY] = hWord + lineN[checkY].Substring(hLength, 15 - hLength);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(hWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the First Vertical Letter and pick a word that starts with that letter to type with it
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
                    while ((pickedWord.ElementAt(0) != letter) && tryN < 20)
                    {
                        pickedWord = PickWord(vSpace);
                        if (tryN >= 19)
                        {
                            goto start;
                        }
                        tryN++;
                    }
                }
                TypeVertically(pickedWord);
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the (0, 1) letter and type a horizontal word with it
            {
                checkX = 0;
                checkY = 1; // go to (0, 0)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = PickWord(hLength);

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 20)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 19)
                    {
                        goto start;
                    }
                    tryN++;
                }

                // Re-write the lineN[] array with the hWord included
                lineN[checkY] = pickedWord + lineN[checkY].Substring(hLength, 15 - hLength);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the (0, 2) letter and type a horizontal word with it
            {
                checkX = 0;
                checkY = 2; // go to (0, 0)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = PickWord(hLength);

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 20)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 19)
                    {
                        goto start;
                    }
                    tryN++;
                }

                // Re-write the lineN[] array with the hWord included
                lineN[checkY] = pickedWord + lineN[checkY].Substring(hLength, 15 - hLength);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion

            #region Check the (0, 3) letter and type a horizontal word with it
            {
                checkX = 0;
                checkY = 3; // go to (0, 0)
                Console.CursorLeft = checkX;
                Console.CursorTop = checkY;
                char letter = read1Letter(Console.CursorLeft, Console.CursorTop);
                // Get horizontal space if theres not a "@" in the following 3 characters
                int hLength = GetWordSpaceHorizontal(checkX, checkY);
                // Pick a word according to that Length gotten from the line above
                string pickedWord = PickWord(hLength);

                int tryN = 0;
                while ((pickedWord.ElementAt(0) != letter) && tryN < 20)
                {
                    pickedWord = PickWord(hLength);
                    if (tryN >= 19)
                    {
                        goto start;
                    }
                }

                // Re-write the lineN[] array with the hWord included
                lineN[checkY] = pickedWord + lineN[checkY].Substring(hLength, 15 - hLength);
                // Assign the re-rewritten word to a variable
                string asd = lineN[checkY];
                // Type the hWord to the current x,y
                Console.WriteLine(pickedWord);
                checkY++;
                System.Threading.Thread.Sleep(solveSpeed);
            }
            #endregion
            #endregion PART [1] END

            #region PART [2]

            #region Type the vertical word created at (1,0) (aiming to pick "MODERN" by chance)
            { 
                checkX = 1;
                checkY = 0; // go to (0, 0)
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

                int tryN = 0; 
                if (pickedWord != null)
                { 
                    while ((pickedWord.ElementAt(0) != letter1) && (pickedWord.ElementAt(1) != letter2) && (pickedWord.ElementAt(2) != letter3) && (pickedWord.ElementAt(3) != letter4) && tryN < 20)
                    {
                        if ((pickedWord.ElementAt(0) == letter1) && (pickedWord.ElementAt(1) == letter2) && (pickedWord.ElementAt(2) == letter3) && (pickedWord.ElementAt(3) == letter4))
                        {
                            TypeVertically(pickedWord);
                            // we cant detect 4 pre known letter words
                            goto exit;
                            break;
                        }
                        pickedWord = PickWord(vSpace);
                        if (tryN >= 19)
                        {
                            goto start;
                        }
                        tryN++;
                    }
                    TypeVertically(pickedWord);
                    goto start;
                } else pickedWord = PickWord(vSpace);
                System.Threading.Thread.Sleep(solveSpeed);

                 

            }

            #endregion

            #endregion Auto Solver NEW ^^^^^^^^

            /* 
            string b = ReadVertically(1, 0);
            if (b != "")
            {
                Console.SetCursorPosition(0, 16);
                Console.WriteLine(b);
            }
            */
            // only type horizontally if theres 3 char space for a word

            exit:
            Console.CursorTop = 16;
            Console.WriteLine("Puzzle Cozuldu.");
            System.Threading.Thread.Sleep(9000);
            Console.ReadLine(); // Kapanmak için tuş girişini bekle            

        }
    }
}

#endregion

// Yiğit Budur (120444012) Bilgi Üniversitesi