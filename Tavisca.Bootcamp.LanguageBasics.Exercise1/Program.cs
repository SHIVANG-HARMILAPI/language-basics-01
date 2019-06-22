using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
              int a = 0, b = 0, c = 0, i = 0;
            string temp = "";
            string ret = "";
            int asterix, quest, equa;

            asterix = equation.IndexOf('*'); //getting index of *
            quest = equation.IndexOf('?');//getting index of ?
            equa = equation.IndexOf('=');//getting index of =
        
            if (asterix < quest && quest < equa)// when ? lies between * and =
            {
                a = Convert.ToInt32(equation.Substring(0, asterix)); 
                c = Convert.ToInt32(equation.Split('=')[1]); 
                if (c % a == 0) //checking validity
                    b = c / a;
                else
                    return -1;
                temp = equation.Substring(asterix+1, equa-(asterix+1));
                i = temp.IndexOf('?');
                if ((asterix - quest == -1 || equa - quest == -1) &&(b.ToString()==temp.Split('?')[1]) )
                {
                    return -1;
                }
                else if ((asterix - quest == 1 || equa - quest == 1) && (b.ToString() == temp.Split('?')[0]))
                {
                    return -1;
                }
                ret = ""+b.ToString()[i];
            }
            else if (asterix < quest && equa < quest) // when ? lies after =
            {
                a = Convert.ToInt32(equation.Substring(0, asterix));
                b = Convert.ToInt32(equation.Substring(asterix + 1, equa - (asterix + 1)));
                c = a * b;
                temp = equation.Split('=')[1];
                i = temp.IndexOf('?');
                if ((asterix - quest == -1 || equa - quest == -1) && (b.ToString() == temp.Split('?')[1]))
                {
                    return -1;
                }
                else if ((asterix - quest == 1 || equa - quest == 1) && (b.ToString() == temp.Split('?')[0]))
                {
                    return -1;
                }
                ret = ""+c.ToString()[i];
            }
            else if (asterix > quest)//when ? lies before *
            {
                b = Convert.ToInt32(equation.Substring(asterix + 1, equa-(asterix+1)));
                c = Convert.ToInt32(equation.Split('=')[1]);
                if (c % b == 0)//checking validity
                    a = c / b;
                else
                    return -1;
                temp = equation.Split('*')[0];
                i = temp.IndexOf('?');
                if ((asterix - quest == -1 || equa - quest == -1) && (b.ToString() == temp.Split('?')[1])) 
                {
                    return -1;
                }
                else if ((asterix - quest == 1 || equa - quest == 1) && (b.ToString() == temp.Split('?')[0]))
                {
                    return -1;
                }
                ret = ""+a.ToString()[i];
            }
            return Convert.ToInt32(ret);
            throw new NotImplementedException();
        }
    }
}
