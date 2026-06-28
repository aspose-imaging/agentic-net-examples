using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf.Graphics;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputWmf";
            string outputDir = @"C:\OutputSvg";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all WMF files in the input directory
            string[] wmfFiles = Directory.GetFiles(inputDir, "*.wmf");

            foreach (string inputPath in wmfFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build output path with .svg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".svg");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options with a uniform fill color (e.g., LightBlue)
                    WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.LightBlue, // Uniform fill color
                        PageSize = wmfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                    };

                    saveOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as SVG
                    wmfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert a legacy collection of Windows Metafile (WMF) diagrams into scalable SVG files for web display while ensuring all shapes share a consistent background color.
 * 2. When an automation script must process dozens of WMF icons from a design repository, outputting SVG versions with a uniform fill to match a brand color palette.
 * 3. When a reporting tool generates charts in WMF format and the developer wants to batch‑convert them to SVG for inclusion in PDF reports, applying a single fill color for visual consistency.
 * 4. When a migration project requires transforming old WMF assets into modern vector graphics for a mobile app, and the code must enforce a standard fill color across all converted shapes.
 * 5. When a CI/CD pipeline needs to validate that all WMF assets in a source folder are rendered as SVG with a predefined background color before publishing to a content delivery network.
 */