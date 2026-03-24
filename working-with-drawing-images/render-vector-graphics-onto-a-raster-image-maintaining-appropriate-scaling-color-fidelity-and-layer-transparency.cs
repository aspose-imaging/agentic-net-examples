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

        // Load the vector image (SVG) using Aspose.Imaging unified loader
        using (SvgImage vectorImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options to control scaling, colors, and smoothing
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set background color (transparent can be used if needed)
                BackgroundColor = Color.White,
                // Preserve original dimensions
                PageSize = vectorImage.Size,
                // Enable anti-aliasing for smooth edges
                SmoothingMode = SmoothingMode.AntiAlias,
                // Render text with high quality
                TextRenderingHint = TextRenderingHint.AntiAlias,
                // Example scaling (1.0 = original size)
                ScaleX = 1.0f,
                ScaleY = 1.0f
            };

            // Prepare PNG save options and attach rasterization settings
            PngOptions saveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to the output path
            vectorImage.Save(outputPath, saveOptions);
        }
    }
}