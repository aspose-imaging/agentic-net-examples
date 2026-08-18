// HOW-TO: Convert WMF to SVG with White Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected errors
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
                SvgOptions svgOptions = new SvgOptions
                {
                    // Render text as vector shapes (optional but common)
                    TextAsShapes = true
                };

                // Configure rasterization options, setting the background to white
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White, // Desired background color
                    PageSize = wmfImage.Size,                     // Preserve original size
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                // Attach rasterization options to the SVG options
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as SVG
                wmfImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display legacy WMF graphics on a web page, converting them to SVG with a white background ensures compatibility with modern browsers.
 * 2. When preparing vector icons from old Windows Metafile files for a cross‑platform mobile app, you can rasterize them to SVG while enforcing a consistent white backdrop.
 * 3. When generating printable documents that require vector images without transparent backgrounds, this code converts WMF logos to SVG with a solid white canvas.
 * 4. When automating a batch migration of corporate branding assets from WMF to SVG, setting the background to white guarantees uniform appearance across all assets.
 * 5. When integrating WMF diagrams into a reporting system that only accepts SVG input, this conversion adds a white background to avoid rendering issues in the final report.
 */
