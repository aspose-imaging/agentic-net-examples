using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\test.svg";
        string outputPath = @"C:\temp\test.output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options and disable anti‑aliasing
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                SmoothingMode = Aspose.Imaging.SmoothingMode.None // disable anti‑aliasing
            };

            // Set up PNG save options with the rasterization options
            PngOptions saveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image to PNG
            svgImage.Save(outputPath, saveOptions);
        }
    }
}