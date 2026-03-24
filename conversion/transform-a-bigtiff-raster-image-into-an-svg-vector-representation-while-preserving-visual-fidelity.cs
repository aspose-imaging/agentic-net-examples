using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.tif";   // BigTIFF source
        string outputPath = @"C:\Images\output.svg"; // Desired SVG result

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if missing)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options – use the original image size as the page size
            var vectorRasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorRasterizationOptions,
                KeepMetadata = true   // preserve metadata if present
            };

            // Save the image as SVG, converting raster data to vector representation
            image.Save(outputPath, svgOptions);
        }
    }
}