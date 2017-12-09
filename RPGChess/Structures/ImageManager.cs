using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

static class ImageManager
{
    private static readonly ArrayList BiomeTiles;
    private static readonly ArrayList ClassIcons;

    private static readonly string AssetPath;

    public static readonly Bitmap hilite;
    public static readonly Bitmap MainBackground;

    /// <summary>
    /// Default constructor for the ImageManager.
    /// </summary>
    static ImageManager()
    {
        BiomeTiles = new ArrayList();
        ClassIcons = new ArrayList();

        AssetPath = @"..\..\Assets\";

        hilite = new Bitmap(AssetPath + @"Tiles\hilite.PNG");
        MainBackground = new Bitmap(AssetPath + @"Backgrounds\MainBG.PNG");

        BiomeTiles.Add(new Bitmap(AssetPath + @"Tiles\water.PNG"));
        BiomeTiles.Add(new Bitmap(AssetPath + @"Tiles\swamp.PNG"));
        BiomeTiles.Add(new Bitmap(AssetPath + @"Tiles\plain.PNG"));
        BiomeTiles.Add(new Bitmap(AssetPath + @"Tiles\forest.PNG"));
        BiomeTiles.Add(new Bitmap(AssetPath + @"Tiles\hill.PNG"));
        BiomeTiles.Add(new Bitmap(AssetPath + @"Tiles\mountain.PNG"));
        BiomeTiles.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNgeneric.PNG"));
        
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNarcher.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNcleric.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNmage.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNmonk.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNrogue.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNwarrior.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\FRN\FRNgeneric.PNG"));

        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\NME\NMEarcher.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\NME\NMEcleric.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\NME\NMEmage.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\NME\NMEmonk.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\NME\NMErogue.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\NME\NMEwarrior.PNG"));
        ClassIcons.Add(new Bitmap(AssetPath + @"Characters\NME\NMEgeneric.PNG"));
    }

    public static Bitmap DetermineCharacterImage(Archetype class_type)
    {
        if (class_type.Equals(Archetype.ARCHER))
        {
            return (Bitmap)ClassIcons[0];
        }
        else if (class_type.Equals(Archetype.CLERIC))
        {
            return (Bitmap)ClassIcons[1];
        }
        else if (class_type.Equals(Archetype.MAGE))
        {
            return (Bitmap)ClassIcons[2];
        }
        else if (class_type.Equals(Archetype.MONK))
        {
            return (Bitmap)ClassIcons[3];
        }
        else if (class_type.Equals(Archetype.ROGUE))
        {
            return (Bitmap)ClassIcons[4];
        }
        else if (class_type.Equals(Archetype.WARRIOR))
        {
            return (Bitmap)ClassIcons[5];
        }
        else
        {
            return (Bitmap)ClassIcons[6];
        }
    }
    /// <summary>
    /// Returns the appropriate image of the givne biome.
    /// </summary>
    /// <param name="biome"> the String representation of the biome. </param>
    /// <returns></returns>
    public static Bitmap DetermineBiomeImage(String biome)
    {
        if (biome.Equals("WTR", StringComparison.CurrentCultureIgnoreCase))
        {
            // Water
            return (Bitmap)BiomeTiles[0];
        }
        else if (biome.Equals("SWP", StringComparison.CurrentCultureIgnoreCase))
        {
            // Swamp
            return (Bitmap)BiomeTiles[1];
        }
        else if (biome.Equals("PLN", StringComparison.CurrentCultureIgnoreCase))
        {
            // Plains
            return (Bitmap)BiomeTiles[2];
        }
        else if (biome.Equals("FRS", StringComparison.CurrentCultureIgnoreCase))
        {
            // Forest
            return (Bitmap)BiomeTiles[3];
        }
        else if (biome.Equals("HLL", StringComparison.CurrentCultureIgnoreCase))
        {
            // Hill
            return (Bitmap)BiomeTiles[4];
        }
        else if (biome.Equals("MTN", StringComparison.CurrentCultureIgnoreCase))
        {
            // Mountain
            return (Bitmap)BiomeTiles[5];
        }
        else
        {
            // Speecial, default, error tile.
            return (Bitmap)BiomeTiles[6];
        }
    }
    /// <summary>
    /// Resize the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    public static Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.ScaleTransform(1.50f, 1.65f);
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }
}