using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image and save it as PNG
        using (Image odgImage = Image.Load(inputPath))
        {
            odgImage.Save(outputPath, new PngOptions());
        }

        // Load the newly created PNG, apply gamma correction, and overwrite the file
        using (Image pngImage = Image.Load(outputPath))
        {
            // Cast to RasterImage to access AdjustGamma
            if (pngImage is RasterImage raster)
            {
                // Apply gamma correction (example gamma value 2.2)
                raster.AdjustGamma(2.2f);
                raster.Save(outputPath, new PngOptions());
            }
        }
    }
}