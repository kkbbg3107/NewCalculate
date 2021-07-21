using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Text
{
    public class Num : IFactory
    {
        public Calculate PostAll(Calculate cal)
        {
            if (cal.Button == ".")
            {
                if (!cal.TextboxFirst.Contains("."))
                {
                    cal.TextboxFirst += cal.Button;
                }
            }
            else
            {
                switch (cal.Button)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        try
                        {
                            cal.Label += cal.TextboxFirst;
                            if (cal.Label.Substring(cal.Label.Length - 1) == "+" || cal.Label.Substring(cal.Label.Length - 1) == "-" || cal.Label.Substring(cal.Label.Length - 1) == "*" || cal.Label.Substring(cal.Label.Length - 1) == "/")
                            {
                                cal.Label = cal.Label.Substring(0, cal.Label.Length - 1);
                                cal.Label += cal.Button;
                            }
                            else
                            {
                                cal.Label += cal.Button;
                                cal.TextboxFirst = string.Empty;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"運算子不能再最前方+{ex}");
                        }

                        break;
                    case ")":

                        cal.Label += cal.TextboxFirst + cal.Button;
                        cal.TextboxFirst = string.Empty;

                        break;
                    case "(": // 後面只能接數字  

                        cal.Label += cal.Button;

                        break;
                    case "=":

                        cal.Label += cal.TextboxFirst;
                        cal.TextboxFirst = string.Empty;

                        break;
                    case "Back":

                        if (cal.TextboxFirst != string.Empty)
                        {
                            cal.TextboxFirst = cal.TextboxFirst.Substring(0, cal.TextboxFirst.Length - 1);
                        }

                        break;
                    default:

                        cal.TextboxFirst += cal.Button;
                        break;
                }
            }
            return cal;
        }
    }
}
