// HOW-TO: Extract a 200x200 Region from DjVu and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.djvu";
            string outputPath = "output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                using (RasterImage page = (RasterImage)djvuImage.Pages[0])
                {
                    Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(100, 100, 200, 200);
                    page.Crop(rect);
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    page.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate a high‑resolution TIFF thumbnail of a specific area of a scanned DjVu document for printing or archival.
 * 2. When a legal or medical application requires extracting a precise page segment from a DjVu file to embed in a report as a TIFF image.
 * 3. When you want to convert a selected region of a multi‑page DjVu ebook into a TIFF file for OCR processing.
 * 4. When a web service must serve only a portion of a large DjVu map as a TIFF image to reduce bandwidth.
 * 5. When an automated workflow extracts a defined rectangle from DjVu drawings to create TIFF assets for CAD integration.
 */
