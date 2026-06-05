using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\InputEmf";
        string outputDir = @"C:\OutputSvg";

        try
        {
            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output SVG file path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = EmfRenderMode.Auto,
                        BorderX = 50,
                        BorderY = 50
                    };

                    saveOptions.VectorRasterizationOptions = rasterizationOptions;

                    // Save as SVG
                    emfImage.Save(outputPath, saveOptions);
                }
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
 * 1. When a developer needs to migrate a legacy Windows drawing library that stores graphics as EMF files to a web‑friendly SVG format for responsive UI rendering.
 * 2. When an automated build pipeline must generate scalable SVG assets from a folder of EMF diagrams to include in documentation or reports.
 * 3. When a GIS or CAD application exports vector maps as EMF and the team wants to batch‑convert them to SVG while preserving vector fidelity for interactive web maps.
 * 4. When a corporate branding team stores logo assets as EMF and requires a C# script to produce SVG versions for print‑to‑screen consistency across browsers.
 * 5. When a data‑visualization service receives user‑uploaded EMF charts and needs to convert them to SVG on the server for fast client‑side rendering.
 */