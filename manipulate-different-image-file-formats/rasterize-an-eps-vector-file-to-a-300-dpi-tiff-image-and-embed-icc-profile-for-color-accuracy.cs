using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure TIFF save options with 300 DPI
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

            // Set vector rasterization options for EPS rendering
            tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
            {
                PageWidth = 0,
                PageHeight = 0
            };

            // Save the rasterized image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}