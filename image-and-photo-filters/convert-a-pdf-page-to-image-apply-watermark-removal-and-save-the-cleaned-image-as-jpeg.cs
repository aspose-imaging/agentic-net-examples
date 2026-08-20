// HOW-TO: How To Convert PDF Page To JPEG And Remove Watermark In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.pdf";
            string outputPath = "Output/cleaned.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Rasterize PDF page to JPEG in memory
                var rasterizeOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = pdfImage.Width,
                        PageHeight = pdfImage.Height
                    }
                };

                using (var memoryStream = new MemoryStream())
                {
                    pdfImage.Save(memoryStream, rasterizeOptions);
                    memoryStream.Position = 0;

                    // Load rasterized image as RasterImage
                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        // Define mask for watermark removal (example ellipse)
                        var mask = new GraphicsPath();
                        var figure = new Figure();
                        figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                        mask.AddFigure(figure);

                        var watermarkOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                        // Remove watermark
                        using (RasterImage cleaned = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, watermarkOptions))
                        {
                            var saveOptions = new JpegOptions();
                            cleaned.Save(outputPath, saveOptions);
                        }
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
 * 1. When you need to extract a clean image from a PDF invoice that contains a semi‑transparent logo and save it as a JPEG for further processing.
 * 2. When an application must automatically strip watermarks from scanned PDF pages before performing OCR or archival storage.
 * 3. When a web service generates thumbnail previews of PDF documents and must ensure the thumbnails are free of embedded watermarks.
 * 4. When you are converting legal PDF documents to JPEG format for e‑discovery while preserving the original page dimensions and removing confidential watermarks.
 * 5. When a desktop tool batch‑processes PDF reports, rasterizes each page to JPEG, and cleans the images by masking out unwanted watermark shapes.
 */
