using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDirectory = @"C:\InputEmf";
            string outputDirectory = @"C:\OutputSvg";

            // Ensure the output directory exists
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

                // Build the output SVG path
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
                        BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                        BorderX = 0,
                        BorderY = 0
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG (embedded raster images are encoded as Base64 by default)
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
 * 1. When a developer needs to migrate a legacy Windows vector graphics library that stores diagrams as EMF files into a web‑friendly SVG format with embedded Base64 images for seamless display in browsers.
 * 2. When an automated build pipeline must generate scalable SVG assets from a folder of EMF icons, preserving exact dimensions and embedding raster content as Base64 to avoid external image references.
 * 3. When a reporting tool creates charts as EMF and the output must be embedded in HTML emails as SVG with inline Base64 images to ensure consistent rendering across email clients.
 * 4. When a document conversion service processes bulk engineering drawings stored in EMF and requires them to be delivered as self‑contained SVG files that include any rasterized parts as Base64 data.
 * 5. When a content management system imports user‑uploaded EMF logos and needs to store them as SVG files with embedded Base64 images to support responsive design and eliminate separate image files.
 */