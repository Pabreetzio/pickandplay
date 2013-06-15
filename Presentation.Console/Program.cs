using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickAndPlay;
using Newtonsoft.Json;
using System.IO;
using console = System.Console;

namespace Presentation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"Config.txt");
            PickAndPlaySettings settings = JsonConvert.DeserializeObject<PickAndPlaySettings>(text);
            PickAndPlayService service = new PickAndPlayService(settings);
            string ply;
            while(true)
            {
                try
                {
                    ply = console.ReadLine();
                    service.IssueMove(ply);
                }
                catch
                {
                    console.WriteLine("I'm sorry, your move could not be completed as entered.");
                }
            }
        }
    }
}
