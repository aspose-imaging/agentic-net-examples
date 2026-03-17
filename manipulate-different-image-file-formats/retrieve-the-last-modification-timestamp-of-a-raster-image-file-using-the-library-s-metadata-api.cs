using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // Adjust namespace if loading a different format

class Program
{
    static void Main()
    {
        // Path to the raster image file
        string imagePath = "sample.png";

        // Load the image using Aspose.Imaging's Image.Load method
        using (RasterImage image = (RasterImage)Image.Load(imagePath))
        {
            // Retrieve the last modification timestamp.
            // The 'true' argument tells the method to fall back to FileInfo if metadata is missing.
            DateTime lastModified = image.GetModifyDate(true);

            // Output the timestamp
            Console.WriteLine($"Last modification date: {lastModified}");
        }
    }
}