// HOW-TO: Remove Watermark From PDF Page and Save As JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.pdf";
            string tempPath = "Output/temp.jpg";
            string outputPath = "Output/cleaned.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Convert PDF page to temporary JPEG
            using (Image pdfImage = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                pdfImage.Save(tempPath, jpegOptions);
            }

            // Load the temporary JPEG as RasterImage for watermark removal
            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, 100, 50)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);
                using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
                {
                    var outOptions = new JpegOptions
                    {
                        Quality = 90
                    };
                    result.Save(outputPath, outOptions);
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
 * 1. When you need to extract a page from a PDF, clean out a logo or stamp, and store the result as a high‑quality JPEG for web publishing.
 * 2. When an automated document‑processing pipeline must convert scanned PDF invoices to images and remove confidential watermarks before archival.
 * 3. When a reporting tool generates PDF charts that contain test watermarks and you must produce watermark‑free JPEG thumbnails for dashboards.
 * 4. When a legal‑tech application must redact watermarked PDF evidence by painting over it and saving the cleaned image for review.
 * 5. When a batch job processes multiple PDFs, converts each first page to JPEG, removes embedded watermarks, and saves the cleaned images for OCR preprocessing.
 */
