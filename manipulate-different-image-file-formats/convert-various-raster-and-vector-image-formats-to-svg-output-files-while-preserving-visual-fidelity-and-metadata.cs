using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded list of input image files (raster or vector formats)
        string[] inputFiles = new[]
        {
            @"C:\Images\sample.png",
            @"C:\Images\vector.wmf",
            @"C:\Images\example.svgz"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define the output SVG file path (append .svg to the original name)
            string outputPath = inputPath + ".svg";

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options: use the source image size as page size
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    KeepMetadata = true,      // Preserve original metadata
                    TextAsShapes = false,    // Keep text as text (not shapes)
                    Compress = false         // No compression for plain SVG
                };

                // Save the image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}