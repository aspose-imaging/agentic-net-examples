using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\output\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image (vector image) using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for SVG
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                // Preserve original size
                PageSize = image.Size,
                // Optional: set background color, smoothing, etc.
                BackgroundColor = Color.Transparent,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Prepare PNG save options and attach rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}