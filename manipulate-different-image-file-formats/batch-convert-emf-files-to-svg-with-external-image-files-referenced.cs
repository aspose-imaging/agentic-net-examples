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

            // Ensure the output directory exists (creates parent if needed)
            Directory.CreateDirectory(outputDirectory);

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG file path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory for this file exists
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
 * 1. When a developer needs to migrate a legacy Windows Metafile (EMF) asset library to scalable web‑friendly SVG files while preserving embedded raster images as external references.
 * 2. When an automation script must process dozens of EMF diagrams in a folder and generate corresponding SVGs for use in responsive HTML5 dashboards.
 * 3. When a document conversion service has to batch convert EMF charts to SVG with a white‑smoke background and consistent page size for uniform rendering in browsers.
 * 4. When a CI/CD pipeline requires converting EMF icons to SVG with text converted to shapes to ensure font‑independent display on cross‑platform devices.
 * 5. When a GIS application needs to rasterize EMF map overlays into SVG files, keeping the original vector data and external image links for efficient storage.
 */