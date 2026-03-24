using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.apng";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG rasterization options based on the source image size
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Optional: compress the SVG output (set to false for plain SVG)
                Compress = false
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}