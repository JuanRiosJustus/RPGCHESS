using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Class that containts graphical representation for certain classes.
/// </summary>
public class ImagePool
{
    private Bitmap MainBackground;
    private Bitmap SubBackground;
    private Animation attackAnimation;

    private List<ImagePoolNode> tiles;
    private List<ImagePoolNode> friend;
    private List<ImagePoolNode> foe;
    /// <summary>
    /// definition of an image pool node.
    /// </summary>
    public class ImagePoolNode
    {
        public readonly Bitmap Picture;
        public readonly string Name;
        public readonly Relation Relation;

        public ImagePoolNode(Bitmap picture, string name, Relation relation)
        {
            Picture = picture;
            Name = name.ToLower(); // <?>
            Relation = relation;
        }
    }
    /// <summary>
    /// Constructor for image pool. 
    /// </summary>
    public ImagePool()
    {
        MainBackground = new Bitmap(@"..\..\Assets\Backgrounds\MainBG.PNG");
        SubBackground = new Bitmap(@"..\..\Assets\Backgrounds\SubBG.PNG");
        attackAnimation = new Animation(@"..\..\Assets\Animations\attack.gif");

        tiles = new List<ImagePoolNode>();
        friend = new List<ImagePoolNode>();
        foe = new List<ImagePoolNode>();

        /********** GET ALL IMAGES **********/
        PopulateTileList();
        PopulateFriendList();
        PopulateFoeList();
    }
    /// <summary>
    /// populates the list of tiles with image pool nodes.
    /// </summary>
    private void PopulateTileList()
    {
        /// TILE IMAGES
        DirectoryInfo dir = new DirectoryInfo(@"..\..\Assets\Tiles\");
        FileInfo[] Files = dir.GetFiles(@"*.PNG");
        foreach (FileInfo file in Files)
        {
            string path = @"..\..\Assets\Tiles\" + file.Name;
            string name = file.Name.Substring(0, file.Name.IndexOf("."));
            Bitmap b = new Bitmap(path);
            ImagePoolNode ipn = new ImagePoolNode(b, name, Relation.Foe);
            tiles.Add(ipn);
        }
    }
    /// <summary>
    /// populates the list of friends with image pool nodes.
    /// </summary>
    private void PopulateFriendList()
    {
        /// FRIENDLY IMAGES
        DirectoryInfo dir = new DirectoryInfo(@"..\..\Assets\Tiles\");
        dir = new DirectoryInfo(@"..\..\Assets\Characters\FRN\");
        FileInfo[] Files1 = dir.GetFiles(@"*.PNG");
        foreach (FileInfo file in Files1)
        {
            string path = @"..\..\Assets\Characters\FRN\" + file.Name;
            string name = file.Name.Substring(0, file.Name.IndexOf("."));
            Console.WriteLine(file.Name);
            Bitmap b = new Bitmap(path);
            ImagePoolNode ipn = new ImagePoolNode(b, name, Relation.Friend);
            friend.Add(ipn);
        }
    }
    /// <summary>
    /// Populates the list of foes with imagepoolnodes.
    /// </summary>
    private void PopulateFoeList()
    {
        /// ENEMY IMAGES
        DirectoryInfo dir = new DirectoryInfo(@"..\..\Assets\Tiles\");
        dir = new DirectoryInfo(@"..\..\Assets\Characters\FOE\");
        FileInfo[] Files2 = dir.GetFiles(@"*.PNG");
        foreach (FileInfo file in Files2)
        {
            string path = @"..\..\Assets\Characters\FOE\" + file.Name;
            string name = file.Name.Substring(0, file.Name.IndexOf("."));
            Console.WriteLine(file.Name);
            Bitmap b = new Bitmap(path);
            ImagePoolNode ipn = new ImagePoolNode(b, name, Relation.Foe);
            foe.Add(ipn);
        }
    }


    public Bitmap GetMainBackground()
    {
        return MainBackground;
    }
    public Bitmap GetSubBackground()
    {
        return SubBackground;
    }
    public Animation GetAttackAnimation()
    {
        return attackAnimation;
    }
    public Bitmap GetImage(int index)
    {
        return friend[index].Picture;
    }
    /// <summary>
    /// Returns an image with respect to relation of entity and name.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="relation"></param>
    /// <returns></returns>
    public Bitmap GetCharacterImage(string name, Relation relation)
    {
        if (relation == Relation.Friend)
        {
            for (int i = 0; i < friend.Count; i++)
            {
                ImagePoolNode ipn = friend[i];
                if (ipn.Name.Contains(name.ToLower()))
                {
                    return ipn.Picture;
                }
            }
        }
        else if (relation == Relation.Foe)
        {
            for (int i = 0; i < foe.Count; i++)
            {
                ImagePoolNode ipn = foe[i];
                if (ipn.Name.Contains(name.ToLower()))
                {
                    return ipn.Picture;
                }
            }
        }
        return null;
    }
    /// <summary>
    /// Returns the image representing the given string.
    /// </summary>
    public Bitmap GetBiomeImage(string name)
    {
        for (int i = 0; i < friend.Count; i++)
        {
            ImagePoolNode cur = tiles[i];
            if (cur.Name.ToLower().Contains(name.ToLower()))
            {
                return tiles[i].Picture;
            }
        }
        return null;
    }
}
