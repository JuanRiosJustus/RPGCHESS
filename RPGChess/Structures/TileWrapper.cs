
/// <summary>
/// Auxiliary wrapper class used for any neccessary computation.
/// </summary>
public class TileWrapper
{
    private Tile _tile;
    public Tile TILE { get { return _tile; } set { _tile = value; } }
    private int _locality;
    public int LOCALITY { get { return _locality; } set { _locality = value; } }
    public TileWrapper(Tile t, int l)
    {
        _tile = t;
        _locality = l;
    }
}