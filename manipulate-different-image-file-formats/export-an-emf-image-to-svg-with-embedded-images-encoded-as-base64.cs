using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.svg";

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
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG; embedded raster images are encoded as Base64 by default
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
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) diagrams into web‑friendly SVG files that can be displayed in browsers without external image dependencies.
 * 2. When an application must embed raster images from an EMF into the resulting SVG as Base64 strings to ensure a single self‑contained file for email or API transmission.
 * 3. When a reporting tool generates charts as EMF and the developer wants to export them to scalable SVG for inclusion in PDF or HTML reports while preserving text as shapes.
 * 4. When a document conversion service processes batch EMF assets and requires automated C# code to rasterize them with a white‑smoke background and save them as SVG with embedded images for archival.
 * 5. When a GIS or CAD system exports map symbols stored in EMF and the developer needs to embed those symbols directly into SVG for use in responsive web mapping applications.
 */