// HOW-TO: How To Properly Dispose SvgImage And Options In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image and ensure it is disposed properly
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Create SVG options and ensure they are disposed properly
                using (SvgOptions options = new SvgOptions())
                {
                    // Configure rasterization options
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = svgImage.Size;
                    options.VectorRasterizationOptions = rasterOptions;

                    // Save the SVG image using the specified options
                    svgImage.Save(outputPath, options);
                }
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
 * 1. When you need to load an SVG file, apply custom rasterization settings, and ensure the image and options objects are released automatically in a C# application.
 * 2. When converting or re‑saving an SVG with Aspose.Imaging while preventing memory leaks by using `using` statements for `SvgImage` and `SvgOptions`.
 * 3. When processing batch SVG files on a server and want reliable cleanup of unmanaged resources after each file is saved.
 * 4. When integrating Aspose.Imaging into a .NET service that must guarantee proper disposal of vector image objects to maintain high performance.
 * 5. When updating an SVG’s page size or other vector rasterization parameters before saving, and you need deterministic disposal of the involved objects.
 */
