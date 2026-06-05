using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.emf";
            string outputPath = "C:\\temp\\output.svg";

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
                    // Render all text as shapes to preserve appearance
                    TextAsShapes = true
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 50, // horizontal margin
                    BorderY = 50  // vertical margin
                };

                // Assign rasterization options to SVG options
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) graphics into web‑friendly Scalable Vector Graphics (SVG) while keeping all original shapes intact for responsive UI rendering.
 * 2. When an automated reporting tool must embed high‑quality vector diagrams from EMF files into HTML dashboards without losing text styling, using Aspose.Imaging’s TextAsShapes option.
 * 3. When a batch processing pipeline has to migrate a library of engineering schematics stored as EMF into SVG format for cross‑platform viewing, preserving exact dimensions and margins.
 * 4. When a desktop application generates printable charts in EMF and wants to export them to SVG for inclusion in PDF documents while ensuring consistent background color and page size.
 * 5. When a CI/CD build script needs to validate that vector assets convert correctly by programmatically loading EMF images and saving them as SVG with rasterization settings for quality assurance testing.
 */