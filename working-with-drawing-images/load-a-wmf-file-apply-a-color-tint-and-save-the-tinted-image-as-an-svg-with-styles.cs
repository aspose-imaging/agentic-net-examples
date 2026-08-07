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
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                // Configure rasterization options with a color tint (light blue background)
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.FromArgb(255, 200, 200, 255), // tint color
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) diagrams into scalable SVG files while applying a light‑blue background tint for consistent branding in a C# web application.
 * 2. When an automated reporting tool must embed WMF charts into HTML pages, requiring the images to be rasterized with a specific background color and saved as SVG with text converted to shapes using Aspose.Imaging for .NET.
 * 3. When a desktop publishing workflow has to batch‑process WMF icons, add a uniform color tint to match a UI theme, and output them as SVG vectors for high‑resolution displays.
 * 4. When a GIS system imports WMF map overlays, needs to apply a semi‑transparent tint to improve visual contrast, and stores the result as SVG for further styling with CSS.
 * 5. When a migration script updates old WMF assets in a legacy database, applying a corporate color scheme and converting them to SVG with vector rasterization options to ensure compatibility with modern browsers.
 */