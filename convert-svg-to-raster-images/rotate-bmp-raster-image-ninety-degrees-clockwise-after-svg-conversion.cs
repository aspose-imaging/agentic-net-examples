// HOW-TO: Rotate BMP Image 90 Degrees Clockwise After SVG Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputSvgPath = "input.svg";
        string intermediateBmpPath = "intermediate.bmp";
        string outputBmpPath = "output_rotated.bmp";

        try
        {
            // Verify input SVG exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediateBmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputBmpPath));

            // Load SVG and rasterize to BMP (intermediate file)
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                // Configure BMP save options with rasterization settings
                var bmpOptions = new BmpOptions();
                var vectorRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size // use original SVG size
                };
                bmpOptions.VectorRasterizationOptions = vectorRasterOptions;

                // Save rasterized BMP
                svgImage.Save(intermediateBmpPath, bmpOptions);
            }

            // Load the rasterized BMP, rotate 90° clockwise, and save final result
            using (Image bmpImage = Image.Load(intermediateBmpPath))
            {
                bmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                bmpImage.Save(outputBmpPath);
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
 * 1. When you need to generate a bitmap thumbnail from an SVG and display it in landscape orientation in a Windows desktop app.
 * 2. When a reporting tool requires BMP images rotated to match page layout after converting vector graphics.
 * 3. When automating batch processing of SVG icons to BMP assets that must be rotated for correct alignment in a game engine.
 * 4. When preparing print‑ready BMP files from SVG logos that need a 90‑degree clockwise orientation for a specific printer feed.
 * 5. When integrating legacy systems that only accept BMP files and expect them to be pre‑rotated after vector‑to‑raster conversion.
 */
