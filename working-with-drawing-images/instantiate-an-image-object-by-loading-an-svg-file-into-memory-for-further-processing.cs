using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\output\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image into memory
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Example processing: display dimensions
            Console.WriteLine($"SVG loaded. Width: {svgImage.Width}, Height: {svgImage.Height}");

            // Optional: rasterize to PNG and save
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(outputPath, pngOptions);
        }
    }
}