using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ImageConversion
{
    static void Main()
    {
        // Path of the source image (any supported format)
        string sourcePath = @"c:\temp\sample.jpg";

        // Desired output path with the new format extension (e.g., PNG)
        string destinationPath = @"c:\temp\sample_converted.png";

        // Load the image using Aspose.Imaging's generic loader
        using (Image image = Image.Load(sourcePath))
        {
            // Save the image in PNG format using PngOptions.
            // The Save method with ImageOptions ensures the correct format is used.
            image.Save(destinationPath, new PngOptions());
        }

        Console.WriteLine("Image conversion completed.");
    }
}