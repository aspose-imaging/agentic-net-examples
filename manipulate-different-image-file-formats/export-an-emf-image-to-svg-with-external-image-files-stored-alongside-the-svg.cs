using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.emf";
        string outputPath = "C:\\temp\\output.svg";

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
                // Configure SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // Render text as shapes
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG; external images (if any) will be stored alongside the SVG
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
 * 1. When a developer needs to convert legacy EMF diagrams from a Windows reporting tool into web‑friendly SVG while preserving any embedded bitmap images as external files, this code provides a ready‑to‑use solution.
 * 2. When migrating engineering drawings stored as EMF to a responsive UI, developers can use this code to render text as shapes and export the drawings to SVG for consistent cross‑browser display.
 * 3. When automating batch conversion of EMF icons from a desktop application to SVG for a cross‑platform mobile app, the code saves the vector graphics and any raster images alongside the SVG for easy asset management.
 * 4. When preparing SEO‑optimized web pages that include charts exported as EMF, developers can convert them to SVG with external high‑resolution raster images using this code.
 * 5. When integrating EMF‑to‑SVG conversion into a CI/CD pipeline to generate printable SVG assets from EMF templates, this code allows control over background color, page size, and rasterization options via Aspose.Imaging.
 */