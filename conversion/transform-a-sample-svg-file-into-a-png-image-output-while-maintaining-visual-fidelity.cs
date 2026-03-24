using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.svg";
        string outputPath = @"c:\temp\sample.output.png";

        // Verify that the input SVG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(stream))
        {
            // Set up rasterization options for converting SVG to raster format
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

            // Configure PNG save options and attach rasterization settings
            PngOptions saveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPath, saveOptions);
        }
    }
}