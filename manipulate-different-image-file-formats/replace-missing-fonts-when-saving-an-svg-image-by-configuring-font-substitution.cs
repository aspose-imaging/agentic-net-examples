using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When generating SVG reports on a server that uses custom fonts not installed on the deployment machine, a developer can use this code to substitute missing fonts with Arial before saving the SVG.
 * 2. When converting user‑uploaded SVG graphics to a standardized format for archival, the code ensures that any unavailable fonts are replaced with a default system font to preserve visual fidelity.
 * 3. When automating batch processing of SVG assets for a web application, the developer can apply the font substitution settings so that the saved SVG files render correctly on clients that lack the original typefaces.
 * 4. When integrating Aspose.Imaging into a C# desktop tool that edits SVG diagrams, the code guarantees that exporting the diagram will not fail due to missing fonts by falling back to a known system font.
 * 5. When creating a CI/CD pipeline that validates SVG assets, the code can be used to replace missing fonts during the build step, preventing font‑related errors in downstream image processing tasks.
 */