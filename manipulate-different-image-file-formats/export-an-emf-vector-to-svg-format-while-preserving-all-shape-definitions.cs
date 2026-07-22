using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.svg";

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

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // Preserve text as vector shapes
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save as SVG
                emfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer uses Aspose.Imaging for .NET to convert legacy Windows EMF files into web‑compatible SVG format while preserving all vector shape definitions for responsive UI rendering.
 * 2. When an automated batch process must read multiple EMF diagrams with Aspose.Imaging, apply rasterization options, and output scalable SVG assets for inclusion in HTML or PDF reports.
 * 3. When a document conversion service needs to keep text as vector shapes during EMF‑to‑SVG conversion to avoid font embedding and ensure consistent typography across browsers.
 * 4. When a GIS or CAD application requires exporting map symbols stored as EMF to SVG so they can be styled with CSS and rendered at any resolution in a web map.
 * 5. When a CI/CD pipeline validates that EMF icons are rendered with a specific background color (e.g., WhiteSmoke) and saved as SVG using Aspose.Imaging’s SvgOptions for cross‑platform mobile app assets.
 */