public struct Toy
{
    private string _name;
    private int _price;
    private int _ageFrom;
    private int _ageTo;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public int Price
    {
        get
        {
            return _price;
        }
        set
        {
            _price = value;
        }
    }
    public int AgeFrom
    {
        get
        {
            return _ageFrom;
        }
        set
        {
            _ageFrom = value;
        }
    }
    public int AgeTo
    {
        get
        {
            return _ageTo;
        }
        set
        {
            _ageTo = value;
        }
    }

    public Toy(string name, int price, int ageFrom, int ageTo)
    {
        _name = name;
        _price = price;
        _ageFrom = ageFrom;
        _ageTo = ageTo;
    }
}