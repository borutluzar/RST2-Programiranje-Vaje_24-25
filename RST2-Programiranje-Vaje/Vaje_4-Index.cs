class Index
{
    // Pomožen slovar, ki ga uporabljamo za shranjevanje vrednosti indekserja
    private Dictionary<Predmet, int> dicOcene = new Dictionary<Predmet, int>();

    /// <summary>
    /// Indekser za objekt Index
    /// </summary>
    public int? this[Predmet predmet]
    {
        get
        {
            if (dicOcene.ContainsKey(predmet))
            {
                return dicOcene[predmet];
            }
            else { return null; }
        }

        set
        {
            if (dicOcene.ContainsKey(predmet))
            {
                dicOcene[predmet] = value.Value;
            }
            else
            {
                dicOcene.Add(predmet, value.Value);
            }
        }
    }

    public string Ime { get; set; }
    public string Priimek { get; set; }
    public int VpisnaSt { get; set; }
    public double PovprecnaOcena
    {
        get
        {
            return dicOcene.Values.Average();
        }
    }

}

/// <summary>
/// Seznam predmetov zapišemo v obliki enumeracije
/// </summary>
public enum Predmet
{
    Programiranje = 1,
    DiskretnaMatematika = 2,
    Algoritmi = 3
}

