using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure vector rasterization options to preserve size and fidelity
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the image as SVG using the configured options
            image.Save(outputPath, new SvgOptions { VectorRasterizationOptions = vectorOptions });
        }
    }
}