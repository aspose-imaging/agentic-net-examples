// HOW-TO: Replace Missing Fonts When Saving SVG with Font Substitution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
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

        try
        {
            // Configure font substitution: use a default font and allow system alternatives
            FontSettings.DefaultFontName = "Arial";
            FontSettings.GetSystemAlternativeFont = true;

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the SVG image; missing fonts will be substituted according to the settings above
                image.Save(outputPath);
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
 * 1. When generating SVG reports on a server that lacks the original fonts, you can substitute missing fonts to ensure the SVG renders correctly.
 * 2. When converting user‑uploaded SVG files to a standardized format in a web application, you need to replace unavailable fonts with a default like Arial.
 * 3. When automating batch processing of SVG assets for a mobile app, font substitution prevents rendering errors caused by missing typefaces.
 * 4. When rendering SVG diagrams in a CI/CD pipeline on build agents without custom fonts, configuring Aspose.Imaging font settings guarantees consistent output.
 * 5. When creating SVG thumbnails for a catalog where the source files reference fonts not installed on the host machine, you can use font substitution to maintain visual fidelity.
 */
