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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Temp\input.wmf";
            string outputPath = @"C:\Temp\output.svg";

            // Verify that the input WMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    // Preserve text as text (keeps embedded fonts and layout)
                    TextAsShapes = false
                };

                // Configure rasterization options for WMF
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = wmfImage.Size,
                    RenderMode = WmfRenderMode.Auto
                };

                // Attach rasterization options to the SVG options
                saveOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer must migrate legacy WMF icons or diagrams to responsive SVG files for a web application while preserving the original text layout and embedded fonts using C# and Aspose.Imaging.
 * 2. When an automated build pipeline needs to generate high‑quality SVG assets from WMF source files for printing or documentation purposes, ensuring that text remains selectable and searchable.
 * 3. When a desktop software vendor wants to offer users the ability to export their WMF‑based reports to SVG so the graphics scale without loss and the embedded fonts are retained for accurate rendering.
 * 4. When a migration tool processes a batch of WMF files stored on a file server and converts them to SVG to integrate with modern vector‑based design tools, requiring rasterization options such as background color and page size.
 * 5. When a C# utility is required to validate that WMF drawings can be displayed correctly in browsers by converting them to SVG while keeping text as text rather than converting it to shapes.
 */