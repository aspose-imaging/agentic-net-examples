using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        // Verify that the input BMP file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image using Aspose.Imaging
        using (Image bmpImage = Image.Load(inputPath))
        {
            // Configure rasterization options for the SVG output
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the source image dimensions
                PageSize = bmpImage.Size
            };

            // Prepare SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Preserve metadata from the source image (optional)
                KeepMetadata = true
            };

            // Save the image as an SVG file
            bmpImage.Save(outputPath, svgOptions);
        }
    }
}