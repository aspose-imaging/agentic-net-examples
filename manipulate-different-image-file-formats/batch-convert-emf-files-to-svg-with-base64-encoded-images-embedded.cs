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

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output SVG file path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Configure SVG save options with embedded raster images (Base64) by default
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true,
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            BackgroundColor = Color.WhiteSmoke,
                            PageSize = emfImage.Size,
                            RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                            BorderX = 0,
                            BorderY = 0
                        }
                    };

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
 * 1. When a developer needs to migrate a large collection of legacy EMF diagrams to web‑ready SVG files with Base64‑encoded raster images for seamless embedding in HTML pages, this batch conversion code using Aspose.Imaging for .NET provides an automated solution.
 * 2. When creating email newsletters that require vector graphics with embedded images to avoid external asset links, the code can convert multiple EMF assets to self‑contained SVGs in C# for reliable rendering across mail clients.
 * 3. When generating documentation portals that display technical drawings, a developer can use this script to batch convert EMF files to SVG while preserving text as shapes and embedding raster content, ensuring consistent visual quality on the web.
 * 4. When building a responsive web application that loads vector icons on demand, the code enables bulk transformation of EMF icons into compact SVGs with Base64 images, reducing HTTP requests and simplifying asset management in C#.
 * 5. When archiving engineering schematics for offline viewing, a developer can employ this routine to convert EMF files into single‑file SVGs that embed all raster elements, making the archives portable and viewable without external resources.
 */