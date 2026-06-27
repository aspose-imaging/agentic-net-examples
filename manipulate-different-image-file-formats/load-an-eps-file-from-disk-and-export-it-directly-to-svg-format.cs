using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG export options
                var svgOptions = new SvgOptions
                {
                    // Set vector rasterization options to match the source size
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as SVG
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
 * 1. When a developer needs to convert legacy EPS artwork into web‑friendly SVG files for responsive design using C# and Aspose.Imaging.
 * 2. When an automated build pipeline must batch‑process print‑ready EPS logos and generate scalable SVG assets for branding guidelines.
 * 3. When a desktop application imports user‑provided EPS diagrams and saves them as SVG to enable editing in vector editors without losing quality.
 * 4. When a server‑side service receives EPS files via API and must return SVG responses for browser rendering in a .NET environment.
 * 5. When a migration script replaces EPS icons in a legacy database with SVG equivalents to improve loading speed on modern devices.
 */