using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public static class AnimationHandler
{
    private static Random rand = new Random(585);
    public static void AnimateMovement(PictureBox pb, Entity ent, Tile to)
    {
        using (Graphics g = pb.CreateGraphics())
        {
            Tile from = ent.TileOfEntity;
            float fx = from.Coordinate.X;
            float fy = from.Coordinate.Y;
            float tx = to.Coordinate.X;
            float ty = to.Coordinate.Y;
            
            float inc = .0001f;

            Image i = ent.ImageOfEntity;

            
            for (float x = fx; x < tx; x = x + inc)
            {
                for (float y = fy; y < ty; y = y + inc)
                {
                    g.DrawImage(i, x, y);
                    g.Clear(Color.Transparent);
                    pb.Invalidate();
                    pb.Update();
                    pb.Refresh();
                    Console.WriteLine();
                }
            }
            // todo
        }
    }
    /// <summary>
    /// Handles the attack animations of two given entities,
    /// </summary>
    public static void AnimateCombat(PictureBox pb, Entity targeter, Entity target, Point e)
    {
        using (Graphics g = pb.CreateGraphics())
        {
            Animation ani = ImageManager.AttackAnimation();
            for (int i = 0; i < ani.Frames; i++)
            {
                g.DrawImage(ani.GetFrame(i), e.X-100 + rand.Next(-20, 20), e.Y-100 + rand.Next(-20, 20));
                g.DrawImage(ani.GetFrame(i), e.X-100 + rand.Next(-20, 20), e.Y-100 + rand.Next(-20, 20));
                g.DrawImage(ani.GetFrame(i), e.X-100 + rand.Next(-20, 20), e.Y-100 + rand.Next(-20, 20));
                pb.Invalidate();
            }
        }
    }
}