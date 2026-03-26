using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input folder and SVG file names
        string baseFolder = @"C:\SvgInput";
        string[] files = new[] { "image1.svg", "image2.svg", "image3.svg" };

        // Create a single rasterization options instance to reuse for all conversions
        var rasterizationOptions = new SvgRasterizationOptions
        {
            BackgroundColor = Aspose.Imaging.Color.White,
            SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
            TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
        };

        var pngSaveOptions = new PngOptions
        {
            VectorRasterizationOptions = rasterizationOptions
        };

        foreach (var fileName in files)
        {
            string inputPath = Path.Combine(baseFolder, fileName);
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Update page size for the current image
                rasterizationOptions.PageSize = image.Size;

                // Determine output path with .png extension
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the rasterized PNG using the shared options
                image.Save(outputPath, pngSaveOptions);
            }
        }
    }
}