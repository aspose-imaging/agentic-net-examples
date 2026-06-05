using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // List of WMF files to process (hardcoded)
            string[] wmfFiles = new[]
            {
                "sample1.wmf",
                "sample2.wmf",
                "sample3.wmf"
            };

            // Desired uniform fill color for all shapes
            Aspose.Imaging.Color uniformFillColor = Aspose.Imaging.Color.Blue;

            foreach (string fileName in wmfFiles)
            {
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".svg");

                // Load the WMF image
                using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
                {
                    // Prepare SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options with the uniform fill color as background
                    WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = uniformFillColor,
                        PageSize = wmfImage.Size,
                        RenderMode = WmfRenderMode.Auto
                    };

                    saveOptions.VectorRasterizationOptions = rasterizationOptions;

                    // Save as SVG
                    wmfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert a collection of legacy WMF diagrams into web‑ready SVG files while enforcing a corporate brand color across all shapes.
 * 2. When an automation script must batch‑process WMF logos for a marketing campaign, outputting SVGs with a uniform fill color to ensure consistent appearance on different devices.
 * 3. When a desktop application has to migrate user‑created WMF drawings to scalable SVG format for inclusion in responsive UI components, applying a single background fill to match the app’s theme.
 * 4. When a CI/CD pipeline generates SVG assets from WMF source files for documentation, and the team wants all vector shapes to share the same fill color for visual uniformity.
 * 5. When a developer is building a bulk conversion tool that reads WMF files from a folder, rasterizes them with a specified fill color, and saves them as SVGs for use in print‑ready PDFs.
 */