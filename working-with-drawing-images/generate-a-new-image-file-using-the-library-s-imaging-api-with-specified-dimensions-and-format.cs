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
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PNG options with a non‑temporal file source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image with the specified dimensions
        using (Image image = Image.Create(pngOptions, 800, 600))
        {
            // Save the image to the specified path
            image.Save();
        }
    }
}