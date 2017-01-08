using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            SerialPort port = new SerialPort("COM4",9600,Parity.None,8,StopBits.Two);
            port.Handshake = Handshake.None;
            
            //M1 мотор на 225
            byte[] M1225 = new byte[9] { 0xff, 0x55, 0x06, 0x00, 0x02, 0x0a, 0x09, 0xff, 0x00 };

            //M2 мотор на 225
            byte[] M2225 = new byte[9] {0xff, 0x55, 0x06 ,0x00 ,0x02 ,0x0a ,0x0a ,0x01 ,0xff};
            
            //M1 мотор на -225
            byte[] M1225m = new byte[9] { 0xff, 0x55, 0x06, 0x00, 0x02, 0x0a, 0x09, 0x01, 0xff };
            
            //M2 мотор на -225
            byte[] M2225m = new byte[9] { 0xff, 0x55, 0x06, 0x00, 0x02, 0x0a, 0x0a, 0xff, 0x00 };


            //M1 стоп
            byte[] M1stop = new byte[9] { 0xff, 0x55, 0x06, 0x00, 0x02, 0x0a, 0x09, 0x00, 0x00 };

            //M2 стоп
            byte[] M2stop = new byte[9] { 0xff, 0x55, 0x06, 0x00, 0x02, 0x0a, 0x0a, 0x00, 0x00 };

            String Asr = "open";
            Console.WriteLine("подверждение open ");
                string A = Convert.ToString(Console.ReadLine());
                if (A == Asr)
                {

                    
                    port.Open();
                    Console.WriteLine("OK");
                }
                while (true)
                {
                    if(Console.ReadKey().Key != 0)
                    {

                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.NumPad8:

                                Console.WriteLine("NumPad8");
                                port.Write(M1225, 0, 9);
                                port.Write(M2225, 0, 9);
                                break;

                            case ConsoleKey.NumPad2:

                                Console.WriteLine("NumPad2");
                                port.Write(M1225m, 0, 9);
                                port.Write(M2225m, 0, 9);
                                break;

                            case ConsoleKey.NumPad4:

                                Console.WriteLine("NumPad4");
                                port.Write(M1225, 0, 9);
                                port.Write(M2225m, 0, 9);
                                break;
                            case ConsoleKey.NumPad6:

                                Console.WriteLine("NumPad6");
                                port.Write(M1225m, 0, 9);
                                port.Write(M2225, 0, 9);
                                break;
                            //default:

                                //Console.WriteLine("Stop");
                                //port.Write(M1stop, 0, 9);
                                //port.Write(M2stop, 0, 9);
                                //break;

                        }
                    }
                     else
                     {
                        Console.WriteLine("Stop");
                        port.Write(M1stop, 0, 9);
                        port.Write(M2stop, 0, 9);
                     }
                    }
                }

            }
        }
    

