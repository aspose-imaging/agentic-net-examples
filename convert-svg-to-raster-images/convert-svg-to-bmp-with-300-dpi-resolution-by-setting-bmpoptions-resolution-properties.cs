using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output\\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP save options with 300 DPI resolution
            BmpOptions bmpOptions = new BmpOptions
            {
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // Set vector rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            bmpOptions.VectorRasterizationOptions = rasterOptions;

            // Save as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}