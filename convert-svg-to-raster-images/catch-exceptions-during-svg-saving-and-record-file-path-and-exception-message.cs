// HOW-TO: How to Catch SVG Save Errors and Log File Path in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.svg";

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
                try
                {
                    // Save the image as SVG
                    var options = new SvgOptions();
                    image.Save(outputPath, options);
                }
                catch (Exception ex)
                {
                    // Record save errors with file path and message
                    Console.Error.WriteLine($"Error saving file '{outputPath}': {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to process user‑uploaded SVG files and ensure any save failures are recorded for troubleshooting.
 * 2. When automating batch conversion of SVG assets and want to log the exact file that caused an error.
 * 3. When integrating Aspose.Imaging into a web service that generates SVG output and must return clear error messages.
 * 4. When building a desktop tool that edits SVG graphics and you must verify the output directory exists before saving.
 * 5. When running scheduled scripts that modify SVG diagrams and you need to capture and report unexpected exceptions.
 */
