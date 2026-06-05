using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.wmf";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Increase canvas size by 10%
                int extraWidth = (int)(wmfImage.Width * 0.1);
                int extraHeight = (int)(wmfImage.Height * 0.1);
                int newWidth = wmfImage.Width + extraWidth;
                int newHeight = wmfImage.Height + extraHeight;

                // Resize the canvas (adds space to the right and bottom)
                wmfImage.ResizeCanvas(new Rectangle(0, 0, newWidth, newHeight));

                // Set up SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                // Configure rasterization options for WMF to SVG conversion
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = wmfImage.Size,
                    RenderMode = WmfRenderMode.Auto
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the enlarged image as SVG
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
 * 1. When a developer needs to embed legacy WMF illustrations into a modern web page and must add extra white space around the graphic for responsive layout, they can load the WMF, enlarge the canvas by 10 %, and save it as SVG.
 * 2. When converting corporate branding assets stored as WMF to scalable SVG files while preserving original dimensions plus a margin for print bleed, this code resizes the canvas and outputs a vector‑friendly format.
 * 3. When an automated build pipeline must generate SVG thumbnails of WMF diagrams with a consistent padding for documentation PDFs, the script loads the WMF, expands the canvas, and exports the result as SVG.
 * 4. When a C# application needs to programmatically increase the drawing area of a WMF chart before converting it to SVG for inclusion in an interactive dashboard, the code performs the canvas resize and vector conversion.
 * 5. When a migration tool has to batch‑process legacy WMF icons, add a 10 % border to meet UI design guidelines, and store them as SVG for cross‑platform use, this snippet provides the required image processing steps.
 */