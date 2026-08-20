// HOW-TO: Save Modified SVG Image Back to Original Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"templates\sample.svg";
        string outputPath = @"templates\sample.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage for SVG-specific operations (if needed)
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid SVG image.");
                    return;
                }

                // Perform any desired filtering here.
                // For demonstration, we simply re-save the image without modifications.

                // Save the SVG back to the templates folder, preserving the original filename
                svgImage.Save(outputPath);
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
 * 1. When you need to apply filters to an SVG template and overwrite the original file without changing its name.
 * 2. When a batch job processes SVG assets stored in a templates directory and must save the results back to the same location.
 * 3. When you want to validate that an SVG file exists before loading it with Aspose.Imaging and then re‑save it safely.
 * 4. When integrating Aspose.Imaging into a C# application that updates vector graphics in place for a web‑based design system.
 * 5. When automating a build pipeline that generates or modifies SVG icons and must keep the original filenames for downstream tools.
 */
