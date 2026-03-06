using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToGifConverter
{
    static void Main()
    {
        // Define the folder where the source WebP and the output GIF will be stored.
        string dir = @"C:\temp\";

        // Load the WebP image from file.
        using (WebPImage webPImage = new WebPImage(dir + "input.webp"))
        {
            // Save the loaded image as GIF.
            // GifOptions can be customized if needed; here we use the default options.
            webPImage.Save(dir + "output.gif", new GifOptions());
        }

        Console.WriteLine("Conversion completed.");
    }
}