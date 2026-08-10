// HOW-TO: Convert SVG To 8‑Bit Indexed BMP With Custom Palette In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.bmp";

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
                // Prepare BMP save options with an indexed (8‑bit) palette
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Use a standard 8‑bit grayscale palette (any indexed palette can be used)
                    Palette = ColorPaletteHelper.Create8BitGrayscale(false)
                };

                // Configure rasterization of the vector SVG into a bitmap
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Use the original SVG size for rasterization
                    PageSize = image.Size
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as BMP using the indexed palette
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display vector graphics on legacy systems that only support 8‑bit BMP files with an indexed color palette.
 * 2. When generating thumbnails for SVG icons to be stored in a database that requires BMP format with limited colors.
 * 3. When preparing graphics for embedded devices or printers that accept only indexed BMP images to reduce memory usage.
 * 4. When converting SVG logos to grayscale BMP files for batch processing in image analysis pipelines.
 * 5. When automating a workflow that rasterizes SVG diagrams into BMP files with a predefined palette for consistent visual output across platforms.
 */
