﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePrj
{
    internal class Snake

    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WindowHeight = 16;
                Console.WindowWidth = 32;
                int screenwidth = Console.WindowWidth;
                int screenheight = Console.WindowHeight;
                Random randomnummer = new Random();
                int score = 5;
                int gameover = 0;
                pixel snakehead = new pixel();
                snakehead.xpos = screenwidth / 2;
                snakehead.ypos = screenheight / 2;
                snakehead.block = ConsoleColor.Red;
                string movement = "RIGHT";
                List<int> xposlijf = new List<int>();
                List<int> yposlijf = new List<int>();
                int berryx = randomnummer.Next(0, screenwidth);
                int berryy = randomnummer.Next(0, screenheight);
                DateTime tijd = DateTime.Now;
                DateTime tijd2 = DateTime.Now;
                string buttonpressed = "no";

                // We only draw the border once. It doesn't change.
                DrawBorder(screenwidth, screenheight);

                bool paused = false;
                while (true)
                {
                    ClearConsole(screenwidth, screenheight);
                    if (snakehead.xpos == screenwidth - 1 || snakehead.xpos == 0 || snakehead.ypos == screenheight - 1 || snakehead.ypos == 0)
                    {
                        gameover = 1;
                    } 

                    if (!paused)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.ForegroundColor = ConsoleColor.Green;

                    if (berryx == snakehead.xpos && berryy == snakehead.ypos)
                    {
                        score++;
                        berryx = randomnummer.Next(1, screenwidth - 2);
                        berryy = randomnummer.Next(1, screenheight - 2);
                    }
                    for (int i = 0; i < xposlijf.Count(); i++)
                    {
                        Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                        Console.Write("¦");
                        if (xposlijf[i] == snakehead.xpos && yposlijf[i] == snakehead.ypos)
                        {
                            gameover = 1;
                        }
                    }
                    if (gameover == 1)
                    {
                        break;
                    }
                    Console.SetCursorPosition(snakehead.xpos, snakehead.ypos);
                    Console.ForegroundColor = snakehead.block;
                    Console.Write("■");
                    Console.SetCursorPosition(berryx, berryy);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("■");
                    Console.CursorVisible = false;
                    tijd = DateTime.Now;
                    buttonpressed = "no";
                    while (true)
                    {
                        tijd2 = DateTime.Now;
                        if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo toets = Console.ReadKey(true);
                            //Console.WriteLine(toets.Key.ToString());
                            if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                            {
                                movement = "UP";
                                buttonpressed = "yes";
                            }
                            if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                            {
                                movement = "DOWN";
                                buttonpressed = "yes";
                            }
                            if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                            {
                                movement = "LEFT";
                                buttonpressed = "yes";
                            }
                            if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                            {
                                movement = "RIGHT";
                                buttonpressed = "yes";
                            }
                                if (toets.Key.Equals(ConsoleKey.P))
                                {
                                    paused = !paused;
                                }
                                if (toets.Key.Equals(ConsoleKey.Escape))
                                {
                                    Environment.Exit(0);
                                }
                            }

                        }
                    xposlijf.Add(snakehead.xpos);
                    yposlijf.Add(snakehead.ypos);
                    switch (movement)
                    {
                        case "UP":
                            snakehead.ypos--;
                            break;
                        case "DOWN":
                            snakehead.ypos++;
                            break;
                        case "LEFT":
                            snakehead.xpos--;
                            break;
                        case "RIGHT":
                            snakehead.xpos++;
                            break;
                    }
                    if (xposlijf.Count() > score)
                    {
                        xposlijf.RemoveAt(0);
                        yposlijf.RemoveAt(0);
                    }
                        else
                        {
                            Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                            Console.WriteLine("Game Paused. Press 'P' to resume.");
                        }
                    }
                }
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                Console.WriteLine("Game over, Score: " + score);
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
            }

            private static void ClearConsole(int screenwidth, int screenheight)
            {
                var blackLine = string.Join("", new byte[screenwidth - 2].Select(b => " ").ToArray());
                Console.ForegroundColor = ConsoleColor.Black;
                for (int i = 1; i < screenheight - 1; i++)
                {
                    Console.SetCursorPosition(1, i);
                    Console.Write(blackLine);
                }
            }

            private static void DrawBorder(int screenwidth, int screenheight)
            {
                var horizontalBar = string.Join("", new byte[screenwidth].Select(b => "■").ToArray());

                Console.SetCursorPosition(0, 0);
                Console.Write(horizontalBar);
                Console.SetCursorPosition(0, screenheight - 1);
                Console.Write(horizontalBar);

                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                    Console.SetCursorPosition(screenwidth - 1, i);
                    Console.Write("■");
                }
            }

            class pixel
            {
                public int xpos { get; set; }
                public int ypos { get; set; }
                public ConsoleColor block { get; set; }
            }
        }
    }
}
