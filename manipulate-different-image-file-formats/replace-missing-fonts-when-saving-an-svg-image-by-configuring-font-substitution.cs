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

            // Configure font substitution for missing fonts
            FontSettings.DefaultFontName = "Arial";          // fallback font
            FontSettings.GetSystemAlternativeFont = true;   // allow system alternatives

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the SVG image with the configured font settings
                var saveOptions = new SvgOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When a web service generates SVG charts on a server that lacks the custom fonts used in the charts, a developer can apply this code to substitute missing fonts with a fallback like Arial before saving the SVG.
 * 2. When migrating legacy SVG assets that reference proprietary fonts to a new environment where those fonts are unavailable, this code ensures the images render correctly by configuring system alternative fonts.
 * 3. When an automated batch job processes thousands of SVG icons for a mobile app and must guarantee consistent text appearance across different build servers, a developer can set FontSettings to use a standard fallback font during the save operation.
 * 4. When exporting SVG diagrams from a C# desktop application to share with clients who may not have the original font files installed, this code replaces missing fonts with a widely supported fallback to prevent broken text.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline that validates SVG assets, the code can automatically substitute missing fonts so the validation step does not fail due to unavailable typefaces.
 */