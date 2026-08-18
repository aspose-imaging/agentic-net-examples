// HOW-TO: Batch Convert EMF Files to SVG with Embedded Base64 Images in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputEmf";
            string outputDir = @"C:\OutputSvg";

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EMF files in the input directory
            string[] emfFiles = Directory.GetFiles(inputDir, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output SVG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EMF image and convert to SVG with embedded Base64 images
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Configure SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true // render text as shapes
                    };

                    // Configure rasterization options for EMF
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = Color.WhiteSmoke,
                        PageSize = emfImage.Size,
                        RenderMode = EmfRenderMode.Auto,
                        BorderX = 50,
                        BorderY = 50
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG; embedded images are stored as Base64 by default
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
 * 1. When you need to migrate a library of Windows Metafile (EMF) graphics to scalable SVG files for web display while preserving raster images as Base64 data URIs.
 * 2. When an application must generate SVG reports from EMF charts and embed the chart images directly in the SVG to avoid external file dependencies.
 * 3. When a build pipeline has to automatically convert multiple EMF assets into SVG format for inclusion in responsive UI components without losing image fidelity.
 * 4. When you want to create SVG versions of EMF logos that contain embedded raster graphics, enabling them to be used in email newsletters that only support inline images.
 * 5. When a document conversion service requires batch processing of EMF diagrams into SVG with text rendered as shapes and images encoded in Base64 for consistent rendering across browsers.
 */
