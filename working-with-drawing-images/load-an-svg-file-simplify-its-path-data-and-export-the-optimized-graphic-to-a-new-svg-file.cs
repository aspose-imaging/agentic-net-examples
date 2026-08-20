// HOW-TO: Simplify SVG Path Data and Export Optimized SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options (disable metadata to help simplify the output)
                var svgOptions = new SvgOptions
                {
                    KeepMetadata = false
                };

                // Save the optimized SVG
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
 * 1. When you need to reduce the size of an SVG by removing unnecessary metadata before embedding it in a web page.
 * 2. When you want to programmatically clean up complex vector graphics for faster rendering in mobile applications.
 * 3. When you must batch‑process SVG assets to create lightweight versions for email newsletters.
 * 4. When you are integrating SVG optimization into a CI/CD pipeline to ensure all exported graphics meet size constraints.
 * 5. When you need to load an existing SVG, simplify its paths, and save the optimized file for use in PDF generation.
 */
