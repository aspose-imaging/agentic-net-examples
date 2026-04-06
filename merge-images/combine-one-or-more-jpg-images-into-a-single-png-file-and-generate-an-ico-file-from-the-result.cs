using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg"
        };

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Output paths
        string combinedPngPath = @"C:\Images\output\combined.png";
        string icoPath = @"C:\Images\output\icon.ico";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(combinedPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(icoPath));

        // Create a multipage image from the JPG files
        using (Image multiImage = Image.Create(inputPaths))
        {
            // Save the combined image as PNG
            multiImage.Save(combinedPngPath, new PngOptions());
        }

        // Load the combined PNG image
        using (Image combinedImage = Image.Load(combinedPngPath))
        {
            // Prepare ICO options (default: PNG format, 32 bits per pixel)
            var icoOptions = new IcoOptions();

            // Create an ICO image from the combined PNG
            using (IcoImage icoImage = new IcoImage(combinedImage, icoOptions))
            {
                // Save the ICO file
                icoImage.Save(icoPath);
            }
        }
    }
}