using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = Path.Combine(@"C:\Images\templates", Path.GetFileName(inputPath));

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
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Here you could apply any filtering to the SVG.
                // For demonstration, we simply save the image unchanged.

                // Save the SVG back to the templates folder preserving the original filename
                SvgOptions saveOptions = new SvgOptions();
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
 * 1. When a web application generates dynamic SVG graphics and needs to store the processed version in a templates directory while keeping the original filename for later reuse.
 * 2. When an automated build pipeline applies filters to SVG assets and must save the modified files back to the project's template folder without renaming them.
 * 3. When a desktop C# utility updates company branding SVG logos and writes the updated images to a shared templates folder, preserving the original file names for consistency across marketing materials.
 * 4. When a batch script processes a collection of SVG icons, applies transformations, and saves each result to a templates directory so that other services can reference the unchanged filenames.
 * 5. When a content management system imports SVG illustrations, runs a validation filter, and stores the verified files in the templates repository while maintaining their original names for version control.
 */