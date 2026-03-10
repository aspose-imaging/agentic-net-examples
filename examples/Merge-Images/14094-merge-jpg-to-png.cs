using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define source JPEG and destination PNG file paths
        string dir = @"c:\temp\";
        string jpegPath = System.IO.Path.Combine(dir, "input.jpg");
        string pngPath = System.IO.Path.Combine(dir, "output.png");

        // Load the JPEG image using the Aspose.Imaging.Image.Load method
        using (Image image = Image.Load(jpegPath))
        {
            // Save the loaded image as PNG using default PNG options
            image.Save(pngPath, new PngOptions());
        }
    }
}