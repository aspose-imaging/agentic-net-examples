using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
            Directory.CreateDirectory(outputDir);

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var bmpImage = (BmpImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(bmpImage, options))
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
 * 1. When a developer needs to automatically strip a known rectangular logo or watermark from scanned BMP documents in a batch processing pipeline, they can define the watermark region (50,50,200,100) and use Aspose.Imaging’s TeleaWatermarkOptions to clean the image.
 * 2. When integrating a legacy BMP image archive into a modern web application, a developer may need to remove embedded watermarks positioned at fixed coordinates before displaying the images to end‑users.
 * 3. When building a C# utility that prepares BMP screenshots for OCR, the code can target the watermark area (50,50,200,100) and apply the Telea inpainting filter to improve text recognition accuracy.
 * 4. When creating an automated quality‑control tool for printed circuit board (PCB) diagrams saved as BMP files, a developer can remove the manufacturer’s watermark located at a known rectangle to compare the raw design against specifications.
 * 5. When developing a desktop application that sanitizes BMP images before sharing them on social media, the developer can define the watermark bounds and invoke Aspose.Imaging.Watermark.WatermarkRemover.PaintOver to produce a clean output file.
 */