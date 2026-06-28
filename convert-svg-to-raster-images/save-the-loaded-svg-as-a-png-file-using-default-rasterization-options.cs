using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(stream))
            {
                // Set up rasterization options (default)
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

                // Set up PNG save options and attach rasterization options
                PngOptions saveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save as PNG
                svgImage.Save(outputPath, saveOptions);
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
 * 1. When a web application uses Aspose.Imaging for .NET to generate PNG thumbnails from user‑uploaded SVG logos for faster browser rendering.
 * 2. When a reporting service converts vector SVG charts into raster PNG images with default rasterization options to embed them in PDF or Word reports.
 * 3. When an e‑commerce site rasterizes SVG product icons to PNG files using C# and Aspose.Imaging so they display correctly on legacy mobile browsers.
 * 4. When a desktop batch‑processing tool iterates over a directory of SVG files and saves each as a PNG using default rasterization to prepare assets for email newsletters.
 * 5. When a CI/CD pipeline validates design assets by programmatically converting SVG mockups to PNGs with Aspose.Imaging for visual regression testing.
 */