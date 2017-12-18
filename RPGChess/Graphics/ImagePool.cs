using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ImagePool
{
    public class ImagePoolNode
    {
        public readonly Bitmap Picture;
        public readonly string Name;
        public readonly Relation Relation;

        public ImagePoolNode(Bitmap picture, string name, Relation relation)
        {
            Picture = picture;
            Name = name; // <?>
            Relation = relation;
        }
    }

    public ImagePool()
    {
        MainBackground = new Bitmap(@"..\..\Assets\Backgrounds\MainBG.PNG");
        SubBackground = new Bitmap(@"..\..\Assets\Backgrounds\SubBG.PNG");

        Bitmaps = new List<ImagePoolNode>();
        
        /********** GET ALL IMAGES **********/
        /// TILE IMAGES
        DirectoryInfo dir = new DirectoryInfo(@"..\..\Assets\Tiles\");
        FileInfo[] Files = dir.GetFiles(@"*.PNG");
        foreach (FileInfo file in Files)
        {
            string path = @"..\..\Assets\Tiles\" + file.Name;
            string name = file.Name.Substring(0, file.Name.IndexOf("."));
            Bitmap b = new Bitmap(path);
            ImagePoolNode ipn = new ImagePoolNode(b, name, Relation.Enemy);
            Bitmaps.Add(ipn);
        }

        /// FRIENDLY IMAGES

        dir = new DirectoryInfo(@"..\..\Assets\Characters\FRN\");
        FileInfo[] Files1 = dir.GetFiles(@"*.PNG");
        foreach (FileInfo file in Files1)
        {
            string path = @"..\..\Assets\Characters\FRN\" + file.Name;
            string name = file.Name.Substring(0, file.Name.IndexOf("."));
            Console.WriteLine(file.Name);
            Bitmap b = new Bitmap(path);
            ImagePoolNode ipn = new ImagePoolNode(b,name, Relation.Friendly);
            Bitmaps.Add(ipn);
        }

        /// ENEMY IMAGES
        
        dir = new DirectoryInfo(@"..\..\Assets\Characters\NME\");
        FileInfo[] Files2 = dir.GetFiles(@"*.PNG");
        foreach (FileInfo file in Files2)
        {
            string path = @"..\..\Assets\Characters\NME\" + file.Name;
            string name = file.Name.Substring(0, file.Name.IndexOf("."));
            Console.WriteLine(file.Name);
            Bitmap b = new Bitmap(path);
            ImagePoolNode ipn = new ImagePoolNode(b, name, Relation.Enemy);
            Bitmaps.Add(ipn);
        }

    }

    private Bitmap MainBackground;
    private Bitmap SubBackground;

    private List<ImagePoolNode> Bitmaps;

    public Bitmap GetMainBackground()
    {
        return MainBackground;
    }
    public Bitmap GetSubBackground()
    {
        return SubBackground;
    }
    public Bitmap GetImage(int index)
    {
        return Bitmaps[index].Picture;
    }
    public Bitmap GetImage(string name, Relation relation)
    {
        for (int i = 0; i < Bitmaps.Count; i++)
        {
            if (Bitmaps[i].Name.ToLower().Contains(name.ToLower()))
            {
                if (Bitmaps[i].Relation == relation)
                {
                    return Bitmaps[i].Picture;
                }
            }
        }
        return null;
    }
    public Bitmap GetImage(string name)
    {
        for (int i = 0; i < Bitmaps.Count; i++)
        {
            if (Bitmaps[i].Name.ToLower().Contains(name.ToLower()))
            {
                return Bitmaps[i].Picture;
            }
        }
        return null;
    }
}
