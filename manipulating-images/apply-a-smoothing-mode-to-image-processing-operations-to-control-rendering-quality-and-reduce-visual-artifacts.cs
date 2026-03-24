using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\test.svg";
        string outputPath = @"c:\temp\test.output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options with smoothing mode
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                // Set background color (optional)
                BackgroundColor = Color.White,
                // Use the original SVG size
                PageSize = svgImage.Size,
                // Apply anti-aliasing to reduce visual artifacts
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                // Optional: improve text rendering
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
            };

            // Set PNG save options and attach rasterization options
            PngOptions saveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image
            svgImage.Save(outputPath, saveOptions);
        }
    }
}