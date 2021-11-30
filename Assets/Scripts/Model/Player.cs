public class Player
{
    private int ID { get; set; }
    private string Name { get; set; }
    private string Password { get; set; }
    private int lvl { get; set; } = 1;
    private int exp { get; set; } = 0;
    public Player(int ID, string Name, string Password)
    {
        this.ID = ID;
        this.Name = Name;
        this.Password = Password;
    }

    public override string ToString() => $"{Name}\nLevel: {lvl}";

}