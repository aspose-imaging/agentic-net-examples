// HOW-TO: Batch Convert WMF to SVG With Uniform Fill Color In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

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
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".svg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image
                using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
                {
                    // Set up SVG save options
                    SvgOptions saveOptions = new SvgOptions
                    {
                        TextAsShapes = true
                    };

                    // Configure rasterization options with a uniform fill color
                    WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.Blue, // uniform fill color for shapes/background
                        PageSize = wmfImage.Size,
                        RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                    };

                    saveOptions.VectorRasterizationOptions = rasterizationOptions;

                    // Save the image as SVG
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
 * 1. When you need to migrate a legacy library of Windows Metafile (WMF) icons to scalable SVG graphics for responsive web pages, applying a consistent color theme.
 * 2. When generating SVG assets from multiple WMF diagrams for documentation, and you want all shapes to share the same fill color to match corporate branding.
 * 3. When automating the conversion of batch‑processed WMF floor plans into SVG files for integration with mapping software, ensuring a uniform background color.
 * 4. When preparing vector illustrations originally stored as WMF for printing, converting them to SVG while setting a single fill color to simplify downstream color adjustments.
 * 5. When building a C# tool that processes many WMF files at once, converting each to SVG and applying a standard fill color to meet accessibility contrast requirements.
 */
