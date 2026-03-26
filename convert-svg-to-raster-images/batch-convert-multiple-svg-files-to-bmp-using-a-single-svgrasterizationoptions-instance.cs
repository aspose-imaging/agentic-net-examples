using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded list of SVG files to convert
        string[] inputFiles = new[]
        {
            @"C:\Images\sample1.svg",
            @"C:\Images\sample2.svg",
            @"C:\Images\sample3.svg"
        };

        // Single rasterization options instance reused for all conversions
        var rasterizationOptions = new SvgRasterizationOptions();

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Update page size for the current image (required for correct rasterization)
                rasterizationOptions.PageSize = svgImage.Size;

                // Prepare BMP save options and assign the shared rasterization options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Determine output path (same folder, same name, .bmp extension)
                string outputPath = Path.ChangeExtension(inputPath, ".bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the rasterized BMP image
                svgImage.Save(outputPath, bmpOptions);
            }
        }
    }
}