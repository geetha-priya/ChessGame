// Class  representing player of a game containing
// color the player is playing, name of player.
// NOTE: HasSubscription has been added to support 'Testing' TASK of assesment

public class Player {
     public string Name { get; set; }
    public Color Color { get; set; }
    public bool HasSubscription {get; set;}
    
    public Player(string name, Color color, bool hasSubscription=true)
    {
        Name = name;
        Color = color;
        HasSubscription = hasSubscription;
    }
}