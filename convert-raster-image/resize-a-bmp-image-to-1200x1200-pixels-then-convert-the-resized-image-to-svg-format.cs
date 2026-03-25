using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP, resize, and save as SVG
        using (Image image = Image.Load(inputPath))
        {
            // Resize to 1200x1200 pixels
            image.Resize(1200, 1200);

            // Prepare SVG export options with rasterization settings
            var svgOptions = new SvgOptions();
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the resized image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}