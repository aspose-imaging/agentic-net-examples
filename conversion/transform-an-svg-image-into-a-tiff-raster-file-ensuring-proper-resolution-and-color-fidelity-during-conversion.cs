using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.tiff";

        // Verify that the input SVG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization to match the SVG's original size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up TIFF save options with default format and the rasterization options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as a TIFF file
            image.Save(outputPath, tiffOptions);
        }
    }
}