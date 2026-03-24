using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG output
            VectorRasterizationOptions vectorRasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the image as SVG using the configured options
            image.Save(outputPath, new SvgOptions
            {
                VectorRasterizationOptions = vectorRasterizationOptions
            });
        }
    }
}