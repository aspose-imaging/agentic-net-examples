// HOW-TO: Batch Remove Watermarks From PNG Images Using Ellipse Mask And Telea In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputDirectory = "OutputImages";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_cleaned.png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Image.Load(inputPath))
                {
                    var pngImage = (PngImage)image;

                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
                    mask.AddFigure(figure);

                    var options = new TeleaWatermarkOptions(mask);

                    using (var result = WatermarkRemover.PaintOver(pngImage, options))
                    {
                        result.Save(outputPath);
                    }
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
 * 1. When you need to automatically clean a large collection of product photos in PNG format by removing watermarks inside a specific elliptical region using the Telea inpainting algorithm.
 * 2. When a web service must preprocess user‑uploaded PNG images to erase logo overlays that appear in a fixed ellipse before storing them in a CDN.
 * 3. When a desktop application has to batch‑process scanned PNG documents, removing stamps that are consistently placed within the same elliptical area.
 * 4. When a game developer wants to strip placeholder watermarks from sprite sheets saved as PNGs, applying the same ellipse mask to every frame.
 * 5. When an archival tool needs to restore old PNG images by filling removed watermark areas with surrounding pixels using Telea inpainting across an entire folder.
 */
