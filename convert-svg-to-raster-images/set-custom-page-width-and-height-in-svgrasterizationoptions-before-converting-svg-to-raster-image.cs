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
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

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
            // Configure rasterization options with custom page width and height
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                // Set desired dimensions (in pixels)
                PageWidth = 800,   // custom width
                PageHeight = 600,  // custom height

                // Optional: set background color, smoothing, etc.
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Prepare PNG save options and attach rasterization settings
            PngOptions saveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image
            svgImage.Save(outputPath, saveOptions);
        }
    }
}