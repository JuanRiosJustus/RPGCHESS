﻿using System.Drawing;
using System.Drawing.Imaging;

public class Animation
{
    private Image gifImage;
    private FrameDimension dimension;
    private Point center;
    private int frameCount;
    private int currentFrame = 0;
    private bool reverse;
    private int step = 1;

    public Animation(string path)
    {
        gifImage = Image.FromFile(path);
        center = new Point((int)gifImage.PhysicalDimension.Height, (int)gifImage.PhysicalDimension.Width);
        //initialize
        dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
        //gets the GUID
        //total frames in the animation
        frameCount = gifImage.GetFrameCount(dimension);
    }

    public int Frames { get { return frameCount; } }

    public bool ReverseAtEnd
    {
        //whether the gif should play backwards when it reaches the end
        get { return reverse; }
        set { reverse = value; }
    }

    public Image GetNextFrame()
    {

        currentFrame += step;

        //if the animation reaches a boundary...
        if (currentFrame >= frameCount || currentFrame < 1)
        {
            if (reverse)
            {
                step *= -1;
                //...reverse the count
                //apply it
                currentFrame += step;
            }
            else
            {
                currentFrame = 0;
                //...or start over
            }
        }
        return GetFrame(currentFrame);
    }

    public Image GetFrame(int index)
    {
        gifImage.SelectActiveFrame(dimension, index);
        //find the frame
        return (Image)gifImage.Clone();
        //return a copy of it
    }
}