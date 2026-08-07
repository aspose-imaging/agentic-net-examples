using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

        try
        {
            // Verify that the input WMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    // Render all text as shapes to preserve layout and fonts
                    TextAsShapes = true
                };

                // Configure rasterization options for the WMF source
                WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
                {
                    // Optional: set a background color (transparent by default)
                    BackgroundColor = Color.WhiteSmoke,
                    // Use the original WMF page size
                    PageSize = wmfImage.Size,
                    // Let Aspose decide whether to render embedded EMF or WMF
                    RenderMode = WmfRenderMode.Auto
                };

                // Attach rasterization options to the SVG options
                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save the image as SVG
                wmfImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to migrate legacy WMF graphics to web‑friendly SVG for responsive UI while preserving exact text layout and embedded fonts using C# and Aspose.Imaging.
 * 2. When an automated document‑conversion service must transform WMF diagrams from Office files into scalable SVG for PDF generation without losing font fidelity.
 * 3. When a CAD application exports vector drawings as WMF and the team wants to display them in a browser‑based viewer by converting them to SVG with preserved typography.
 * 4. When a batch‑processing tool scans a folder of WMF icons and converts each to SVG sprites for modern web applications, keeping the original text positioning and fonts intact.
 * 5. When a reporting engine generates charts as WMF and the developer needs to embed them in HTML emails as SVG while ensuring the text appears exactly as designed.
 */