using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
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
            // Load EPS image with default load options
            using (EpsImage image = (EpsImage)Image.Load(inputPath, new EpsLoadOptions()))
            {
                // NOTE: Aspose.Imaging does not provide a direct API to replace gradients with solid colors.
                // If such processing is required, it would involve parsing the EPS content and modifying
                // the PostScript commands, which is beyond the scope of this example.
                // The image is saved directly as SVG, preserving the vector data.

                // Prepare SVG save options
                var svgOptions = new SvgOptions();

                // Configure vector rasterization options to match the source dimensions
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to convert legacy EPS artwork into modern SVG files for responsive web design using C# and Aspose.Imaging.
 * 2. When an automated build pipeline must batch‑process EPS logos and output SVG versions to integrate with a company's branding system.
 * 3. When a desktop application has to load an EPS diagram, ensure the output directory exists, and save it as SVG while preserving vector fidelity.
 * 4. When a cloud service receives user‑uploaded EPS files and must transform them into SVG format for preview in browsers without requiring external tools.
 * 5. When a migration script replaces EPS assets in a digital asset management system with SVG equivalents to improve scalability and cross‑platform compatibility.
 */