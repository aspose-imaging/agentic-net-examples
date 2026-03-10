using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToGifConverter
{
    static void Main()
    {
        // Define the folder containing the source WebP file and the output GIF file.
        string dir = @"c:\temp\";

        // Load the WebP image from the specified file.
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Convert and save the loaded WebP image as a GIF.
            // GifOptions can be customized if needed (e.g., set animation options).
            webPImage.Save(dir + "output.gif", new GifOptions());
        }
    }
}