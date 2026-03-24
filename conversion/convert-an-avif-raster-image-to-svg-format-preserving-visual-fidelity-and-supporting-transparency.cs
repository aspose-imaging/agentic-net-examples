using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.avif";
        string outputPath = @"C:\Images\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for SVG conversion
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                // Use the original image size as the page size
                PageSize = image.Size
            };

            // Configure SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Preserve transparency (default behavior)
                // TextAsShapes left as default (false) to keep text as text when possible
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}