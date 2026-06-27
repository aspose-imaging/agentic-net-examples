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
            string inputDir = @"C:\InputEmf";
            string outputDir = @"C:\OutputSvg";

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image and convert to SVG
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true,
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            BackgroundColor = Color.WhiteSmoke,
                            PageSize = emfImage.Size,
                            RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                            BorderX = 50,
                            BorderY = 50
                        }
                    };

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
 * 1. When a developer needs to migrate a legacy Windows Metafile (EMF) icon library to scalable web‑friendly SVG assets for responsive UI design.
 * 2. When an automated build pipeline must generate SVG versions of engineering diagrams stored as EMF files to embed them in HTML documentation.
 * 3. When a GIS application requires converting batch EMF map overlays into SVG with external image references for high‑resolution printing.
 * 4. When a content management system needs to transform user‑uploaded EMF logos into SVG thumbnails while preserving vector fidelity and background color.
 * 5. When a reporting tool must export chart images originally saved as EMF into SVG format for cross‑platform analytics dashboards.
 */