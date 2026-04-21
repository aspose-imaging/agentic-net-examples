using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with 24 bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            // Create the file at the specified location (non‑temporal)
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new 500x500 image using the specified options
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // No additional processing required; just save the image
            image.Save();
        }
    }
}