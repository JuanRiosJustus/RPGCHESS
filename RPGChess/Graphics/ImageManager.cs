using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

public class ImageManager
{
    private static ImagePool IM;

    private static ImagePool GetImagePoolInstance()
    {
        if (IM == null)
        {
            IM = new ImagePool();
        }
        return IM;
    }
    /// <summary>
    /// returns the main background for the program.
    /// </summary>
    /// <returns></returns>
    public static Bitmap MainBackground()
    {
        GetImagePoolInstance();
        return IM.GetMainBackground();
    }
    /// <summary>
    /// Returns teh secondary image for secondary forms for the program.
    /// </summary>
    /// <returns></returns>
    public static Bitmap SubBackground()
    {
        GetImagePoolInstance();
        return IM.GetSubBackground();
    }
    /// <summary>
    /// Returns the attack animation.
    /// </summary>
    public static Animation AttackAnimation()
    {
        GetImagePoolInstance();
        return IM.GetAttackAnimation();
    }
    /// <summary>
    /// Returns a bitmap based on the given archetype and relatio.
    /// </summary>
    /// <param name="class_type">archetype to find</param>
    /// <param name="relation">relation to find.</param>
    /// <returns></returns>
    public static Bitmap DetermineCharacterImage(Archetype class_type, Relation relation)
    {
        GetImagePoolInstance();
        return IM.GetCharacterImage(class_type.Name, relation);
    }
    /// <summary>
    /// Returns the appropriate image of the givne biome.
    /// </summary>
    /// <param name="biome"> the String representation of the biome. </param>
    /// <returns></returns>
    public static Bitmap DetermineBiomeImage(String biome)
    {
        GetImagePoolInstance();
        return IM.GetBiomeImage(biome);
    }
    /// <summary>
    /// Sets the background of the board.
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    private Image SetBackground(Graphics g)
    {
        /*
        Bitmap bitmap = new Bitmap(Convert.ToInt32(this.Display.Width * 2), Convert.ToInt32(this.Display.Height + 800), PixelFormat.Format32bppArgb);
        g = Graphics.FromImage(bitmap);

        for (int row = 0; row < ConnectedGame.GetBoardLength(0); row++)
        {
            for (int col = 0; col < ConnectedGame.GetBoardLength(1); col++)
            {
                Tile tile = ConnectedGame.GetBoardTile(row, col);

                g.DrawImage(tile.TileImage, tile.Coordinate.X, tile.Coordinate.Y);
            }
        }

        bitmap.Save(@"..\..\Assets\Backgrounds\Board.PNG", ImageFormat.Png);
        Image result = new Bitmap(@"..\..\Assets\Backgrounds\Board.PNG");
        this.backgroundIsDeveloped = true;

        return ImageManager.ResizeImage(result, this.Display.Width, this.Display.Height);*/
            return null; ;
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
        var destRect = new Rectangle(0, 0, width - 1, height - 2);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.ScaleTransform(1.50f, 1.665f);
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height + 5, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }
}