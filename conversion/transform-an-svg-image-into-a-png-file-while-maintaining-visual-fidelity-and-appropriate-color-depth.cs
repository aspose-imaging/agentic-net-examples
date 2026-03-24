using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify that the input SVG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG export options
            PngOptions pngOptions = new PngOptions();

            // Configure vector rasterization to render the SVG correctly
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the original SVG dimensions
                PageSize = image.Size
            };
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rendered image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}