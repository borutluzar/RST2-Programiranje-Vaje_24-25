namespace RST2_Programiranje_Vaje
{
    internal class Program
    {
        enum Sections
        {
            Vaje_1 = 1
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
            }
            Console.Read();
        }
    }
}
