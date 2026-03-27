using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with anti‑aliasing
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions();
            rasterOptions.PageSize = image.Size;                     // Preserve original size
            rasterOptions.SmoothingMode = SmoothingMode.AntiAlias;   // Enable anti‑aliasing

            // Set PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}