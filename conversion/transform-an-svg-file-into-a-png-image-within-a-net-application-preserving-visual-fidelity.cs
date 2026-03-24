using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG from file stream and rasterize to PNG
        using (Stream stream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(stream))
        {
            // Set up rasterization options (default values)
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

            // Configure PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}