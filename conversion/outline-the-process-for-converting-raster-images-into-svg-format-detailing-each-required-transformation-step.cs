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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image (PNG, JPEG, etc.) using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG output
            // PageSize is set to the original image size to preserve dimensions
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Create SVG save options and attach the rasterization settings
            SvgOptions saveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Optional: set Compress = false for plain SVG (true would produce SVGZ)
                Compress = false
            };

            // Save the image as SVG
            image.Save(outputPath, saveOptions);
        }
    }
}