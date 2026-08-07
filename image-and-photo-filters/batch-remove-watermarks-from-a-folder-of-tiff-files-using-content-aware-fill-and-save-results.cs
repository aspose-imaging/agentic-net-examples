using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "C:\\InputTiffs";
            string outputFolder = "C:\\OutputTiffs";

            Directory.CreateDirectory(outputFolder);

            foreach (var filePath in Directory.GetFiles(inputFolder, "*.tif"))
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputFolder, fileName + "_cleaned.tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Image.Load(filePath))
                {
                    var raster = (RasterImage)image;

                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0, 0, image.Width, image.Height)));
                    mask.AddFigure(figure);

                    var options = new ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = 4
                    };

                    using (var result = WatermarkRemover.PaintOver(raster, options))
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
 * 1. When a scanning service needs to clean up scanned TIFF documents that contain printer watermarks before archiving them, a developer can use this code to batch‑remove the watermarks with content‑aware fill.
 * 2. When a medical imaging workflow receives DICOM‑converted TIFF files with embedded branding marks that must be stripped for patient privacy, this C# routine automates the removal across a folder.
 * 3. When a publishing house processes large batches of high‑resolution TIFF artwork that include placeholder watermarks, the code enables developers to programmatically erase them while preserving image quality.
 * 4. When a GIS department imports georeferenced TIFF maps that contain vendor watermarks and wants to generate clean map tiles, the example shows how to iterate through files and apply content‑aware fill removal.
 * 5. When an e‑commerce platform receives product catalog TIFF images watermarked by suppliers and needs to deliver unmarked images to customers, this script provides a scalable C# solution for batch watermark elimination.
 */