using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source WebP file and where the GIF will be saved
        string dir = @"c:\temp\";

        // Load the WebP image from a file
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Convert and save the image as GIF using default GifOptions
            webPImage.Save(dir + "output.gif", new GifOptions());
        }
    }
}