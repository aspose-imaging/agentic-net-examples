using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define the folder containing the source WebP and the destination GIF.
        string dir = @"c:\temp\";

        // Load the WebP image from file using the WebPImage constructor.
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Save the loaded image as a GIF.
            // Only the active frame is saved because GIF is a multi‑page format.
            webPImage.Save(dir + "output.gif", new GifOptions());
        }
    }
}