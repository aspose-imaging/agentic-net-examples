// HOW-TO: Export EMF to SVG with External Images Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            using (Image image = Image.Load(inputPath))
            {
                // Cast to specific EMF image type
                EmfImage emfImage = (EmfImage)image;

                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                // Configure EMF rasterization options for SVG conversion
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 50,
                    BorderY = 50
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG; external images will be stored alongside the SVG file
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
 * 1. When you need to convert legacy Windows Metafile (EMF) graphics to scalable SVG files while keeping embedded bitmap images as separate files for easier editing.
 * 2. When a reporting application must generate SVG charts from EMF templates and store the raster images alongside the SVG for web delivery.
 * 3. When migrating a desktop design library to a web‑based system and you require automated C# code to preserve image quality by rasterizing EMF content into SVG with external image assets.
 * 4. When creating an automated build pipeline that transforms EMF icons into SVG assets, ensuring the SVG references external PNGs placed in the same output folder.
 * 5. When a GIS tool exports map symbols in EMF format and you need to programmatically produce SVG equivalents with external image resources for use in HTML5 canvases.
 */
