﻿namespace RST2_Programiranje_Vaje
{
    internal class Program
    {
        enum Sections
        {
            Vaje_01 =  1, //  3. 10. 2024
            Vaje_02 =  2, //  4. 10. 2024
            Vaje_03 =  3, //  9. 10. 2024
            Vaje_04 =  4, // 19. 10. 2024
            Vaje_05 =  5, // 26. 10. 2024
            Vaje_06 =  6, // 30. 10. 2024 - skupinsko delo (Nalogi 2.5.3 in 2.5.4)
            Vaje_07 =  7, //  7. 11. 2024
            Vaje_08 =  8, // 15. 11. 2024
            Vaje_09 =  9, // 21. 11. 2024
            Vaje_10 = 10, // 29. 11. 2024
            Vaje_11 = 11, //  6. 12. 2024
            Vaje_12 = 12, // 12. 12. 2024
            Vaje_13 = 13, // 20. 12. 2024 - skupinsko delo
            Vaje_14 = 14, //  9.  1. 2025
            Vaje_15 = 15, // 15.  1. 2025
        }

        static void Main(string[] args)
        {
            switch (InterfaceFunctions.ChooseSection<Sections>())
            {
                case Sections.Vaje_01:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_01_Naloge>())
                        {
                            case Vaje_01_Naloge.Naloga112:
                                {
                                    Vaje_01.Naloga112();
                                }
                                break;
                            case Vaje_01_Naloge.Naloga123:
                                {
                                    Console.Write("Vpišite številko meseca: ");
                                    int mesec = int.Parse(Console.ReadLine());
                                    int stDni = Vaje_01.Naloga123(mesec);
                                    Console.WriteLine($"V {mesec}. mesecu je {stDni} dni.");
                                }
                                break;
                            case Vaje_01_Naloge.Naloga131:
                                {
                                    Vaje_01.Naloga131();
                                }
                                break;
                            case Vaje_01_Naloge.Naloga141:
                                {
                                    int x = 10;
                                    int y = 20;
                                    (int NSV, int NSD) = Vaje_01.Naloga141(x, y);
                                    Console.WriteLine($"Najmanjši skupni večkratnik števil {x} in {y} je {NSV}.");
                                    Console.WriteLine($"Največji skupni delitelj števil {x} in {y} je {NSD}.");
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_02:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_02_Naloge>())
                        {
                            case Vaje_02_Naloge.Naloga135:
                                {
                                    Vaje_02.Naloga135();
                                }
                                break;
                            case Vaje_02_Naloge.Naloga142:
                                {
                                    int x = 11;
                                    int y = 17;
                                    int NSV = Vaje_02.Naloga142(x, y, out int? NSD, findGCD: true);
                                    Console.WriteLine($"Najmanjši skupni večkratnik števil {x} in {y} je {NSV}.");
                                    Console.WriteLine($"Največji skupni delitelj števil {x} in {y} je {NSD}.");
                                }
                                break;
                            case Vaje_02_Naloge.Naloga143:
                                {
                                    var newList = new List<double>()
                                            {
                                                0.9, 1.2, 3.5
                                            };

                                    Vaje_02.Naloga143(ref newList);
                                    Console.WriteLine(newList.Count);
                                }
                                break;
                            case Vaje_02_Naloge.Naloga152:
                                {
                                    Vaje_02.Naloga152();
                                }
                                break;
                            case Vaje_02_Naloge.Naloga171:
                                {
                                    Vaje_02.Naloga171();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_03:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_03_Naloge>())
                        {
                            case Vaje_03_Naloge.Naloga182:
                                {
                                    Vaje_03.Naloga182(10_000);
                                }
                                break;
                            case Vaje_03_Naloge.Naloga211:
                                {
                                    Vaje_03.Naloga211();
                                }
                                break;
                            case Vaje_03_Naloge.Naloga212:
                                {
                                    Vaje_03.Naloga212();
                                }
                                break;
                            case Vaje_03_Naloge.Naloga213:
                                {
                                    Vaje_03.Naloga213();
                                }
                                break;
                        }
                    }
                    break;
                
                case Sections.Vaje_04:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_04_Naloge>())
                        {
                            case Vaje_04_Naloge.Naloga221:
                                {
                                    Vaje_04.Naloga221();
                                }
                                break;
                            case Vaje_04_Naloge.Naloga222:
                                {
                                    Vaje_04.Naloga222();
                                }
                                break;
                            case Vaje_04_Naloge.Naloga232:
                                {
                                    Vaje_04.Naloga232();
                                }
                                break;
                            case Vaje_04_Naloge.Naloga233:
                                {
                                    Vaje_04.Naloga233();
                                }
                                break;
                        }
                    }
                    break;
                
                case Sections.Vaje_05:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_05_Naloge>())
                        {
                            case Vaje_05_Naloge.Naloga244:
                                {
                                    Vaje_05.Naloga244();
                                }
                                break;
                            case Vaje_05_Naloge.Naloga245:
                                {
                                    Vaje_05.Naloga245();
                                }
                                break;
                            case Vaje_05_Naloge.Naloga246:
                                {
                                    Vaje_05.Naloga246();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_06:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_06_Naloge>())
                        {
                            case Vaje_06_Naloge.Naloga254:
                                {
                                    Vaje_06.Naloga254();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_07:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_07_Naloge>())
                        {
                            case Vaje_07_Naloge.Naloga261:
                                {
                                    Vaje_07.Naloga261();
                                }
                                break;
                            case Vaje_07_Naloge.Naloga266:
                                {
                                    Vaje_07.Naloga266();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_08:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_08_Naloge>())
                        {
                            case Vaje_08_Naloge.Naloga272:
                                {
                                    Vaje_08.Naloga272();
                                }
                                break;
                            case Vaje_08_Naloge.Naloga273:
                                {
                                    Vaje_08.Naloga273();
                                }
                                break;
                            case Vaje_08_Naloge.Naloga274:
                                {
                                    Vaje_08.Naloga274();
                                }
                                break;
                            case Vaje_08_Naloge.Naloga300:
                                {
                                    Vaje_08.Naloga300();
                                }
                                break;
                        }
                    }
                    break;
                
                case Sections.Vaje_09:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_09_Naloge>())
                        {
                            case Vaje_09_Naloge.Naloga301:
                                {
                                    Vaje_09.Naloga301();

                                    /* Ali s seznamom */
                                    var lstAuthors = Vaje_09.Naloga301();
                                    Vaje_09.Naloga301(lstAuthors);
                                }
                                break;
                            case Vaje_09_Naloge.Naloga302:
                                {                                    
                                    Vaje_09.Naloga302();
                                }
                                break;
                            case Vaje_09_Naloge.Naloga311:
                                {
                                    Vaje_09.Naloga311();
                                }
                                break;
                            case Vaje_09_Naloge.Naloga312:
                                {
                                    List<int> lst = new() { 5, 16, 25, 39, 46 };
                                    Vaje_09.Naloga312(lst, Vaje_09.MetodaZa311, Vaje_09.Metoda312PrestejKvadrate);
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_10:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_10_Naloge>())
                        {
                            case Vaje_10_Naloge.Naloga421:
                                {
                                    Vaje_10.Naloga421();
                                }
                                break;
                            case Vaje_10_Naloge.Naloga422:
                                {
                                    Vaje_10.Naloga422();
                                }
                                break;
                            case Vaje_10_Naloge.Naloga432:
                                {
                                    Vaje_10.Naloga432();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_11:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_11_Naloge>())
                        {
                            case Vaje_11_Naloge.Naloga441:
                                {
                                    Vaje_11.Naloga441();
                                }
                                break;
                            case Vaje_11_Naloge.Naloga442:
                                {
                                    Vaje_11.Naloga442();
                                }
                                break;
                            case Vaje_11_Naloge.Naloga511:
                                {
                                    Vaje_11.Naloga511();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_12:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_12_Naloge>())
                        {
                            case Vaje_12_Naloge.Naloga621:
                                {
                                    Vaje_12.Naloga621();
                                }
                                break;
                            case Vaje_12_Naloge.Naloga623:
                                {
                                    Vaje_12.Naloga623();
                                }
                                break;
                            case Vaje_12_Naloge.Naloga625:
                                {
                                    Vaje_12.Naloga625();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_13:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_13_Naloge>())
                        {
                            case Vaje_13_Naloge.Naloga711:
                                {
                                    Vaje_13.Naloga711();
                                }
                                break;
                            case Vaje_13_Naloge.Naloga721:
                                {
                                    Vaje_13.Naloga721();
                                }
                                break;
                            case Vaje_13_Naloge.Naloga722:
                                {
                                    //Vaje_13.Naloga722(); // Domača vaja!
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_14:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_14_Naloge>())
                        {
                            case Vaje_14_Naloge.Naloga731:
                                {
                                    Vaje_14.Naloga731();
                                }
                                break;
                            case Vaje_14_Naloge.Naloga732:
                                {
                                    Vaje_14.Naloga732();
                                }
                                break;
                            case Vaje_14_Naloge.Naloga741:
                                {
                                    Vaje_14.Naloga741();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_15:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_15_Naloge>())
                        {
                            case Vaje_15_Naloge.Naloga3:
                                {
                                    Vaje_15.Naloga3();
                                }
                                break;
                            case Vaje_15_Naloge.Naloga5:
                                {
                                    Vaje_15.Naloga5();
                                }
                                break;
                        }
                    }
                    break;
            }
            Console.Read();
        }
    }
}
