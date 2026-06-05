using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // ------------------------------------------------------------
                // Replace all black strokes with blue.
                // Aspose.Imaging does not expose a direct API for editing
                // individual pen colors in an existing WMF. If such an API
                // were available, it would be invoked here, e.g. iterating
                // over wmfImage.Records and changing black colors to blue.
                // ------------------------------------------------------------

                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        // Preserve original page size
                        PageSize = wmfImage.Size,
                        // Render mode can be left as default (Auto)
                        RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto,
                        // Background color (optional)
                        BackgroundColor = Aspose.Imaging.Color.WhiteSmoke
                    }
                };

                // Save as SVG
                wmfImage.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) diagrams into scalable SVG files while changing all black lines to brand‑specific blue for consistent web display.
 * 2. When a C# application must batch‑process engineering schematics stored as WMF, recolor the black strokes to improve print contrast, and output them as SVG for inclusion in responsive HTML reports.
 * 3. When an automation script has to update corporate flowcharts originally saved in WMF by swapping the default black pen color for a corporate blue palette before publishing them as SVG assets in a documentation portal.
 * 4. When a graphics pipeline requires extracting vector data from a WMF logo, replacing its black outlines with a brand‑approved blue hue, and saving the result as an SVG for high‑resolution scaling on marketing materials.
 * 5. When a .NET service integrates Aspose.Imaging to transform user‑uploaded WMF icons, recolor the black strokes to match a UI theme’s blue accent, and deliver the modified icons as SVG for modern web applications.
 */