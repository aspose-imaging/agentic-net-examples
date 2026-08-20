// HOW-TO: Invert BMP Colors and Save as SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output\inverted.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load BMP image
            using (BmpImage bmp = (BmpImage)Image.Load(inputPath))
            {
                // Invert colors pixel by pixel
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var original = bmp.GetPixel(x, y);
                        var inverted = Color.FromArgb(
                            original.A,
                            255 - original.R,
                            255 - original.G,
                            255 - original.B);
                        bmp.SetPixel(x, y, inverted);
                    }
                }

                // Save as SVG
                var svgOptions = new SvgOptions();
                bmp.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a negative‑style version of a legacy BMP icon for use in modern web SVG graphics.
 * 2. When a batch process must convert scanned BMP documents into color‑inverted SVGs for printing with reversed tones.
 * 3. When an application requires on‑the‑fly color inversion of BMP assets before embedding them in vector‑based reports.
 * 4. When you want to preserve image resolution while transforming a BMP into a scalable SVG after applying a pixel‑level filter.
 * 5. When automating a workflow that reads BMP files, applies custom pixel manipulation, and outputs them as SVG files for cross‑platform compatibility.
 */
