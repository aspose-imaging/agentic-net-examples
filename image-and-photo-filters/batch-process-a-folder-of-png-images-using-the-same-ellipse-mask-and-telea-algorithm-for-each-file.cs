// HOW-TO: Batch Apply Elliptical Mask with Telea Inpainting to PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_masked.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    GraphicsPath mask = new GraphicsPath();
                    Figure figure = new Figure();

                    int ellipseX = raster.Width / 4;
                    int ellipseY = raster.Height / 4;
                    int ellipseWidth = raster.Width / 2;
                    int ellipseHeight = raster.Height / 2;
                    RectangleF rect = new RectangleF(ellipseX, ellipseY, ellipseWidth, ellipseHeight);
                    figure.AddShape(new EllipseShape(rect));
                    mask.AddFigure(figure);

                    TeleaWatermarkOptions options = new TeleaWatermarkOptions(mask);

                    using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
                    {
                        PngOptions saveOptions = new PngOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
                        result.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically hide the central region of dozens of PNG product photos by applying the same elliptical mask and filling the masked area with Telea inpainting.
 * 2. When you must process a large collection of scanned PNG documents to obscure sensitive information inside a consistent ellipse while preserving surrounding details using Aspose.Imaging in C#.
 * 3. When you want to generate uniform circular thumbnails from a folder of PNG images by masking each image with an ellipse and repairing the masked pixels with the Telea algorithm.
 * 4. When you are building a batch workflow that removes watermarks or logos located in the middle of PNG files by applying an ellipse mask and reconstructing the area with Telea inpainting.
 * 5. When you need to prepare PNG assets for a game or UI by batch‑applying an elliptical cut‑out and smoothly filling the cut‑out area using the Telea algorithm to maintain visual quality.
 */
