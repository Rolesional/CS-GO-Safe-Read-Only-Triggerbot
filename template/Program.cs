using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using nextcheat;
using roles;


namespace template
{
    internal class Program
    {
        [DllImport("User32.dll")]
        static extern short GetAsyncKeyState(Keys Vkey);

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n");
            Console.Write(" █▀▀█ █▀▀█ █   █▀▀ █▀▀  ▀  █▀▀█ █▀▀▄ █▀▀█ █   ▀▀█▀▀ █▀▀█  ▀  █▀▀▀ █▀▀▀ █▀▀ █▀▀█ █▀▀▄ █▀▀█ ▀▀█▀▀\n");
            Console.Write(" █▄▄▀ █  █ █   █▀▀ ▀▀█ ▀█▀ █  █ █  █ █▄▄█ █     █   █▄▄▀ ▀█▀ █ ▀█ █ ▀█ █▀▀ █▄▄▀ █▀▀▄ █  █   █  \n");
            Console.Write(" ▀ ▀▀ ▀▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀ ▀▀▀▀ ▀  ▀ ▀  ▀ ▀▀▀   ▀   ▀ ▀▀ ▀▀▀ ▀▀▀▀ ▀▀▀▀ ▀▀▀ ▀ ▀▀ ▀▀▀  ▀▀▀▀   ▀  \n");
            Console.Write(" Coded By Rolesional :)\n");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" **TRIGGERBOT ACTIVATED!**");
            Console.WriteLine(" ");
            Console.WriteLine(" **if not working please update offsets in source code!**");
            Console.WriteLine(" ");
            Console.WriteLine(" **Github Link: https://github.com/Rolesional **");
            Console.WriteLine(" ");
            Console.WriteLine(" **Hazedumper Github Link (csgo.cs): https://github.com/frk1/hazedumper **");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            var localplayer = 0xDE6964;
            var entitylist = 0x4DFBE54;
            var health = 0x100;
            var team = 0xF4;
            var crosshairid = 0x11838;


            memory roles = new memory();

            roles.GetProcess("csgo");


            var client = roles.GetModuleBase("client.dll");
            var engine = roles.GetModuleBase("engine.dll");


            while (true)
            {

                if (GetAsyncKeyState(Keys.C) < 0) //Change Key Here (Keys.YourKey)
                {
                    var buffer = roles.ReadPointer(client, localplayer);
                    var cross = BitConverter.ToInt32(roles.ReadBytes(buffer, crosshairid, 4), 0);
                    var weteam = BitConverter.ToInt32(roles.ReadBytes(buffer, team, 4), 0);


                    var enemy = roles.ReadPointer(client, entitylist + (cross - 1) * 0x10);
                    var enemyteam = BitConverter.ToInt32(roles.ReadBytes(enemy, team, 4), 0);
                    var enemyhealth = BitConverter.ToInt32(roles.ReadBytes(enemy, health, 4), 0);

                    if (weteam != enemyteam && enemyhealth > 1)
                    {
                        Thread.Sleep(1); //Trigger Delay (ms)
                        UserCMD.Execute("+attack"); Console.WriteLine(" Attacked!"); //Shooting
                        Thread.Sleep(1);
                        UserCMD.Execute("-attack"); //Shooting
                    }



                }
                Thread.Sleep(1);

            }
            


        }
    }
}
