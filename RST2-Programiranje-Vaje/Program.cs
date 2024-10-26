namespace RST2_Programiranje_Vaje
{
    internal class Program
    {
        enum Sections
        {
            Vaje_1 = 1, //  3. 10. 2024
            Vaje_2 = 2, //  4. 10. 2024
            Vaje_3 = 3, //  9. 10. 2024
            Vaje_4 = 4, // 19. 10. 2024
            Vaje_5 = 5, // 26. 10. 2024
            Vaje_6 = 6, // 30. 10. 2024
        }

        static void Main(string[] args)
        {
            switch (InterfaceFunctions.ChooseSection<Sections>())
            {
                case Sections.Vaje_1:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje1>())
                        {
                            case Vaje1.Naloga112:
                                {
                                    Vaje_1.Naloga112();
                                }
                                break;
                            case Vaje1.Naloga123:
                                {
                                    Console.Write("Vpišite številko meseca: ");
                                    int mesec = int.Parse(Console.ReadLine());
                                    int stDni = Vaje_1.Naloga123(mesec);
                                    Console.WriteLine($"V {mesec}. mesecu je {stDni} dni.");
                                }
                                break;
                            case Vaje1.Naloga131:
                                {
                                    Vaje_1.Naloga131();
                                }
                                break;
                            case Vaje1.Naloga141:
                                {
                                    int x = 10;
                                    int y = 20;
                                    (int NSV, int NSD) = Vaje_1.Naloga141(x, y);
                                    Console.WriteLine($"Najmanjši skupni večkratnik števil {x} in {y} je {NSV}.");
                                    Console.WriteLine($"Največji skupni delitelj števil {x} in {y} je {NSD}.");
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_2:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje2>())
                        {
                            case Vaje2.Naloga135:
                                {
                                    Vaje_2.Naloga135();
                                }
                                break;
                            case Vaje2.Naloga142:
                                {
                                    int x = 11;
                                    int y = 17;
                                    int NSV = Vaje_2.Naloga142(x, y, out int? NSD, findGCD: true);
                                    Console.WriteLine($"Najmanjši skupni večkratnik števil {x} in {y} je {NSV}.");
                                    Console.WriteLine($"Največji skupni delitelj števil {x} in {y} je {NSD}.");
                                }
                                break;
                            case Vaje2.Naloga143:
                                {
                                    var newList = new List<double>()
                                            {
                                                0.9, 1.2, 3.5
                                            };

                                    Vaje_2.Naloga143(ref newList);
                                    Console.WriteLine(newList.Count);
                                }
                                break;
                            case Vaje2.Naloga152:
                                {
                                    Vaje_2.Naloga152();
                                }
                                break;
                            case Vaje2.Naloga171:
                                {
                                    Vaje_2.Naloga171();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_3:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje3>())
                        {
                            case Vaje3.Naloga182:
                                {
                                    Vaje_3.Naloga182(10_000);
                                }
                                break;
                            case Vaje3.Naloga211:
                                {
                                    Vaje_3.Naloga211();
                                }
                                break;
                            case Vaje3.Naloga212:
                                {
                                    Vaje_3.Naloga212();
                                }
                                break;
                            case Vaje3.Naloga213:
                                {
                                    Vaje_3.Naloga213();
                                }
                                break;
                        }
                    }
                    break;
                
                case Sections.Vaje_4:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje4>())
                        {
                            case Vaje4.Naloga221:
                                {
                                    Vaje_4.Naloga221();
                                }
                                break;
                            case Vaje4.Naloga222:
                                {
                                    Vaje_4.Naloga222();
                                }
                                break;
                            case Vaje4.Naloga232:
                                {
                                    Vaje_4.Naloga232();
                                }
                                break;
                            case Vaje4.Naloga233:
                                {
                                    Vaje_4.Naloga233();
                                }
                                break;
                        }
                    }
                    break;
                
                case Sections.Vaje_5:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje5>())
                        {
                            case Vaje5.Naloga244:
                                {
                                    Vaje_5.Naloga244();
                                }
                                break;
                            case Vaje5.Naloga245:
                                {
                                    Vaje_5.Naloga245();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_6:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje6>())
                        {
                            case Vaje6.NalogaXY:
                                {
                                    Vaje_6.NalogaXY();
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
