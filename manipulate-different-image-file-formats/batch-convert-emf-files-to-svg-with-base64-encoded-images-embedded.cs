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
            // Hard‑coded list of EMF files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.emf",
                @"C:\Images\sample2.emf",
                @"C:\Images\sample3.emf"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same folder, .svg extension)
                string outputPath = Path.ChangeExtension(inputPath, ".svg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true // render text as shapes
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = ((EmfImage)image).Size,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                        BorderX = 0,
                        BorderY = 0
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG; embedded raster images are stored as Base64 by default
                    image.Save(outputPath, saveOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a developer needs to migrate legacy Windows vector graphics stored as EMF files into a web‑friendly SVG format for responsive UI components, they can use this code to batch convert and embed raster parts as Base64.
 * 2. When an automated build pipeline must generate printable SVG assets from design assets saved as EMF, ensuring that any embedded bitmap elements are self‑contained via Base64 encoding, this code provides the conversion step.
 * 3. When a document management system imports user‑uploaded EMF charts and must display them in browsers without external image files, the batch conversion to SVG with embedded Base64 images enables seamless inline rendering.
 * 4. When a reporting tool creates charts as EMF and needs to embed them in HTML email templates, converting them to SVG with Base64‑encoded raster data ensures the graphics are displayed correctly across email clients.
 * 5. When a GIS application stores map overlays as EMF and wants to export them to a portable SVG package for sharing with collaborators, this code batch processes the files and embeds any raster layers as Base64 to keep the package self‑contained.
 */