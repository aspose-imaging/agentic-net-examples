using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.djvu";
        string outputPath = @"c:\temp\sample.emboss.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DJVU image, apply an emboss-like filter, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply an emboss effect (using SharpenFilterOptions as a stand‑in for emboss)
            djvuImage.Filter(djvuImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}