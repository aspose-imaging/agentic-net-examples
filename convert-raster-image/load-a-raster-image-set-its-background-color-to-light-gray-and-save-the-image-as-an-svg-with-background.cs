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

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image rasterImage = Image.Load(inputPath))
            {
                // Prepare SVG save options with background color
                SvgOptions svgOptions = new SvgOptions
                {
                    // Convert raster image to SVG using vector rasterization options
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        // Set the background color to light gray
                        BackgroundColor = Aspose.Imaging.Color.LightGray,
                        // Use the original image size as the page size
                        PageSize = rasterImage.Size
                    }
                };

                // Save the image as SVG with the specified options
                rasterImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert a PNG or JPEG raster image to a scalable SVG for responsive web design while applying a light‑gray background to match the page theme.
 * 2. When an application must generate SVG assets from user‑uploaded photos and ensure a consistent background color for printing or PDF export.
 * 3. When a C# service processes batch image files, converting them to vector‑based SVGs with a predefined background to improve loading speed on mobile devices.
 * 4. When a desktop tool creates SVG diagrams from raster screenshots and wants to set a neutral gray canvas to enhance visual contrast.
 * 5. When an automated workflow adds a background color to raster‑to‑SVG conversions to meet branding guidelines before storing the files in a content management system.
 */