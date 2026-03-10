using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the images.
        string dir = @"c:\temp\";

        // Load the lossless WebP image from file.
        using (Image webpImage = Image.Load(dir + "input.webp"))
        {
            // Convert and save the image as GIF using default GifOptions.
            webpImage.Save(dir + "output.gif", new GifOptions());
        }
    }
}