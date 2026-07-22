using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Build a mask consisting of multiple ellipses
                var mask = new GraphicsPath();

                // First ellipse
                var figure1 = new Figure();
                figure1.AddShape(new EllipseShape(new RectangleF(100, 80, 200, 150)));
                mask.AddFigure(figure1);

                // Second ellipse
                var figure2 = new Figure();
                figure2.AddShape(new EllipseShape(new RectangleF(250, 120, 180, 130)));
                mask.AddFigure(figure2);

                // Third ellipse
                var figure3 = new Figure();
                figure3.AddShape(new EllipseShape(new RectangleF(400, 60, 220, 160)));
                mask.AddFigure(figure3);

                // Create Telea algorithm options with the custom mask
                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                // Remove the watermark
                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options))
                {
                    // Save the processed image
                    result.Save(outputPath);
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
 * 1. When a developer needs to erase a multi‑ellipse watermark from a PNG file before publishing it on a website, they can create a custom GraphicsPath mask with several EllipseShape objects and call Aspose.Imaging.Watermark.WatermarkRemover.PaintOver.
 * 2. When an image‑processing pipeline must automatically clean scanned documents that contain overlapping circular stamps, this C# code builds a combined mask of ellipses and uses TeleaWatermarkOptions to restore the original content.
 * 3. When a batch job processes product photos stored as PNGs and must remove brand logos that consist of irregular oval shapes, the developer can define the mask with multiple ellipses and invoke PaintOver to generate clean output images.
 * 4. When a desktop application needs to let users remove decorative watermarks composed of several concentric ellipses from user‑uploaded images, the code demonstrates how to construct the mask and apply the Telea algorithm in Aspose.Imaging for .NET.
 * 5. When a content‑management system integrates C# image‑editing features to strip complex watermark patterns from uploaded graphics, this example shows how to combine ellipses into a single mask and perform watermark removal with PaintOver.
 */