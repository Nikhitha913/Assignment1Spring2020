using System;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            Console.WriteLine("Enter the input of number of stones in the bag");
            int n4 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(n4);
            Stones(n4);

        }


        private static void PrintPattern(int n)
        {
            try
            {
                int rec_num = 1;     // initialising a number for an end point


                for (rec_num = 1; rec_num <= n; rec_num++)    // creating a loop to get the numbers sequentially and is increased upto the given number
                {

                    for (int j = n - rec_num + 1; j >= 1; j--)  //In this the decremental line is taken upto 1
                    {

                        Console.Write(j);     // The numbers will be printed in the decresing manner for every one number in the outer loop

                    }

                    Console.WriteLine();
                }

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }


        private static void PrintSeries(int n2)
        {
            try
            {
                int series = 0;
                for (int i = 1; i <= n2; i++)   // loop to get the siz of numbers to iterate
                {
                    series = i * (i + 1) / 2;  // This formula is for adding the first n natural numbers where the n value is retrieved from the for loop
                    Console.Write(series);
                    Console.Write("   ");
                }
                Console.WriteLine(" ");
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }


        public static string UsfTime(string s)
        {
            try
            {
                // To easily calculate the number of seconds we need the time in 24 hour format and so converted to DateTime
                DateTime dateDate = DateTime.Parse(s);
                string date2 = dateDate.ToString("HH:mm:ss");    // The time in 24hours is taken and converted back to string
                                                                 //  Console.WriteLine(date2);


                double seconds = TimeSpan.Parse(date2).TotalSeconds;    // number of seconds in a given time
                                                                        //   Console.WriteLine(seconds);

                // The seconds obtained are converted to USF timings by dividing them into minutes and seconds
                int hours;
                int minutes;

                hours = (int)(Math.Floor((double)(seconds / 2700)));    // 60*45 = 2700
                seconds = seconds % 2700;
                minutes = (int)(Math.Floor((double)(seconds / 45)));
                seconds = seconds % 45;
                string t = hours + ":" + minutes + ":" + seconds;
                Console.WriteLine(t);
            }

            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }


        public static void UsfNumbers(int n3, int k)
        {
            try
            {

                int s = 0;
                String p = "";     // empty string is taken to store the letters in particular intervals

                for (int i = 1; i <= n3 / k; i++)   // creates a loop to check the numbers
                {

                    for (int j = 1; j <= k; j++)       // loop for 11 numbers in a line
                    {

                        double l = 0;   // initialising a variable 'l'
                        s = s + 1;    // increamenting the number by one a checking the multiples of that number

                        if (s % 3 == 0)    // checking for multiple of 3
                        {

                            p = "U";

                        }
                        else if (s % 5 == 0)    // checking for multiple of 5
                        {

                            p = "S";

                        }
                        else if (s % 7 == 0)     // checking for multiple of 7
                        {

                            p = "F";

                        }
                        else
                        {

                            p = "" + s;

                        }

                        l = s;     // The numbers which are multiples of 3 or 5 or 7 are passed into l



                        if ((l / 3) % 5 == 0)    // checking if the number is multiple of both 3 and 5
                        {

                            p = "US";



                        }
                        else if ((l / 5) % 7 == 0) // checking if the number is multiple of both 5 and 7
                        {

                            p = "SF";

                        }
                        else if ((l / 3) % 7 == 0)   // checking if the number is multiple of both 3 and 7
                        {

                            p = "UF";

                        }



                        Console.Write(p);

                        Console.Write("  ");

                    }

                    Console.WriteLine("");

                }

            }




            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }



        public static void PalindromePairs(string[] words)
        {
            try
            {


                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < words.Length; j++)
                    {
                        string rev;
                        string str = words[i] + words[j];   // concatenating strings 

                        char[] arr = str.ToCharArray();
                        Array.Reverse(arr);       // reversing the string to check the palindrome condition
                        rev = new string(arr);
                        if (i != j)
                        {
                            // ignoring the case string comparison with rev string
                            bool b = str.Equals(rev, StringComparison.OrdinalIgnoreCase);

                            if (b == true)
                            {

                                Console.Write("[");
                                Console.Write(i);
                                Console.Write(",");
                                Console.Write(j);
                                Console.Write("]");

                            }

                        }
                    }

                }
                Console.WriteLine(" ");
            }
            catch
            {

                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }



        public static void Stones(int n4)
        {
            try
            {

                // In this as we know for the multiples of 4 the player 1 never wins
                if (n4 % 4 == 0)
                    Console.WriteLine("False");
                else
                {
                    Console.Write("[");
                    for (int i = 0; n4 != 0; i++)  // loop for other than multiples of 4 numbers
                    {
                        // The other numbers (not a multiple of 4)are divided into odd and even numbers.
                        //To get the winning output for odd numbers one of the possibility is to take 3, so the maximum stones will be picked and are subtracted from the bag
                        //The remaining would be even number and is moved to other loop.
                        // The if else conditions satisfying even and odd numbers will be continued until 0 and the loop is ended. 
                        if (i % 2 != 0)
                        {
                            n4 -= 3;
                            Console.Write("3");
                            if (n4 != 0)
                                Console.Write(", ");
                        }
                        else
                        {
                            Console.Write(n4 % 4);   // The even number present is printed and continues until the number becomes 0
                            n4 -= (n4 % 4);
                            if (n4 != 0)
                                Console.Write(", ");
                        }
                    }
                    Console.Write("]");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }

    }
}


