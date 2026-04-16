using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input directory containing SVG files
        string inputDirectory = @"C:\InputSvgs";

        // List of SVG file names to convert
        string[] svgFiles = new[]
        {
            "image1.svg",
            "image2.svg",
            "image3.svg"
        };

        // Create a single rasterization options instance to be reused
        SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

        // PNG save options that reference the shared rasterization options
        PngOptions pngSaveOptions = new PngOptions
        {
            VectorRasterizationOptions = rasterizationOptions
        };

        foreach (string fileName in svgFiles)
        {
            // Build full input path
            string inputPath = Path.Combine(inputDirectory, fileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path (same name with .png extension)
            string outputPath = Path.ChangeExtension(inputPath, ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Update page size for the current image
                rasterizationOptions.PageSize = image.Size;

                // Save as PNG using the shared options
                image.Save(outputPath, pngSaveOptions);
            }
        }
    }
}