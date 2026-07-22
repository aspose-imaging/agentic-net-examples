using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputEmf";
            string outputDirectory = @"C:\OutputSvg";

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path
                string outputPath = Path.Combine(
                    outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                        BorderX = 50,
                        BorderY = 50
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to migrate a legacy collection of Windows Metafile (EMF) diagrams to web‑friendly SVG files for a corporate intranet portal, they can use this C# batch conversion code with Aspose.Imaging.
 * 2. When an automated build pipeline must generate scalable icons from EMF assets while preserving embedded raster images as external references, the code provides the necessary rasterization and SVG save options.
 * 3. When a document management system requires converting engineering schematics stored as EMF into searchable SVG vectors for indexing and preview, the batch process simplifies the task.
 * 4. When a marketing team wants to create responsive graphics by converting a folder of EMF logos into SVG format with consistent background color and borders, developers can employ this script.
 * 5. When a GIS application needs to export map overlays saved as EMF into SVG for integration with web mapping libraries, the code enables bulk conversion with proper handling of external image files.
 */