using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input.odg";
        string outputPath = @"C:\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image and save as SVG
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG rasterization options
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure SVG save options
            var saveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Simplify output by converting text to shapes (optional)
                TextAsShapes = true
            };

            // Save the image as SVG
            image.Save(outputPath, saveOptions);
        }
    }
}