using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Test4Problem2
{
    class Program
    {
        static string paneText = "<div id=\"text\">";
        static string divEnd = "</div>";
        static void Main(string[] args)
        {
            try
            {
                WebClient wc = new WebClient();
                string htmlData = wc.DownloadString("http://rickleinecker.com/Rick-Leinecker-Magazine-Articles-and-Writing.html");

                int index = htmlData.IndexOf(paneText);

                while (index >= 0)
                {
                    int endIndex = htmlData.IndexOf(divEnd, index);
                    string foundText = htmlData.Substring(index + paneText.Length, endIndex - (index + paneText.Length)).Trim();

                    char[] separator = {' '};
                    String[] strlist = foundText.Split(separator, StringSplitOptions.None);

                    if(strlist[0] == "COMPUTE!")
                    {
                        Console.WriteLine("Magazine:" + strlist[0] + ", Number: " + strlist[1] + ", Date:" + strlist[2] + " " + strlist[3]);
                    }

                    index = endIndex;
                    index = htmlData.IndexOf(paneText, index);

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
