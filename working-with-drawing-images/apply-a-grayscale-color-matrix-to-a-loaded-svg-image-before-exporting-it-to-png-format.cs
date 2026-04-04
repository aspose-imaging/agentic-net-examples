using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\sample_grayscale.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for SVG -> PNG conversion
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Set up PNG save options with the rasterization options
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize SVG to PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                svgImage.Save(memoryStream, pngSaveOptions);
                memoryStream.Position = 0; // Reset stream position for reading

                // Load the rasterized PNG image
                using (PngImage pngImage = (PngImage)Image.Load(memoryStream))
                {
                    // Apply grayscale transformation
                    pngImage.Grayscale();

                    // Save the final grayscale PNG to the output path
                    pngImage.Save(outputPath);
                }
            }
        }
    }
}