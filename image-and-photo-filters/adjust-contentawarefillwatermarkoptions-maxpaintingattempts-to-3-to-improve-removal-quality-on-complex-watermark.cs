using System;
using System.IO;
using Aspose.Imaging;
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
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (null-safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load image and prepare watermark removal
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                // Define mask using GraphicsPath
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                // Configure ContentAwareFillWatermarkOptions with MaxPaintingAttempts = 3
                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 3
                };

                // Perform watermark removal
                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options))
                {
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
 * 1. When processing scanned legal documents in PNG format that contain semi‑transparent watermarks, a developer can set MaxPaintingAttempts to 3 to ensure the ContentAwareFill algorithm iteratively refines the fill and removes the watermark without leaving artifacts.
 * 2. When cleaning up product photos for an e‑commerce catalog where the original PNG images have intricate logo watermarks, using MaxPaintingAttempts = 3 helps the watermark remover perform additional painting passes to better blend the background.
 * 3. When preparing archival PNG images of historical maps that include overlapping watermark patterns, a developer may increase MaxPaintingAttempts to 3 to achieve higher fidelity in the restored map details.
 * 4. When automating batch removal of complex watermarks from PNG screenshots of software UI for documentation, setting MaxPaintingAttempts to 3 allows the ContentAwareFill process to handle varying opacity levels and preserve text clarity.
 * 5. When integrating Aspose.Imaging into a C# web service that receives user‑uploaded PNG images with custom watermark shapes, configuring MaxPaintingAttempts to 3 improves the success rate of removing irregular watermark regions before further image analysis.
 */