// HOW-TO: Convert OTG to SVG with Minified XML in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.svg";

            // Verify that the input OTG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    // Enable compression (produces a smaller, minified SVG)
                    Compress = true,
                    // Set rasterization options so the SVG matches the source size
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save the image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed vector graphics from legacy OTG files into a web page and want the SVG markup to be as small as possible.
 * 2. When an automated build pipeline must convert a batch of OTG assets to SVG while minimizing bandwidth for mobile users.
 * 3. When a desktop application generates reports that include OTG diagrams and requires them in SVG format with compressed XML for faster loading.
 * 4. When migrating a design library from proprietary OTG files to a standards‑based SVG format and need to reduce storage costs by minifying the output.
 * 5. When integrating Aspose.Imaging into a C# service that receives OTG uploads and must return lightweight SVG responses to client applications.
 */
