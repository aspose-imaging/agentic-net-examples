// HOW-TO: Resize PNG to 800x800, Pad Transparent Background, Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.png";
        string outputPath = "Output/output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage src = (RasterImage)Image.Load(inputPath))
            {
                if (!src.IsCached) src.CacheData();

                const int targetSize = 800;
                int newWidth, newHeight;

                if (src.Width > src.Height)
                {
                    newWidth = targetSize;
                    newHeight = src.Height * targetSize / src.Width;
                }
                else
                {
                    newHeight = targetSize;
                    newWidth = src.Width * targetSize / src.Height;
                }

                src.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                PngOptions canvasOptions = new PngOptions();
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, targetSize, targetSize))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.Transparent);

                    int offsetX = (targetSize - newWidth) / 2;
                    int offsetY = (targetSize - newHeight) / 2;

                    canvas.SaveArgb32Pixels(
                        new Rectangle(offsetX, offsetY, src.Width, src.Height),
                        src.LoadArgb32Pixels(src.Bounds));

                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a square PDF thumbnail from user‑uploaded PNG logos while preserving transparency.
 * 2. When an e‑commerce platform must standardize product images to 800 × 800 pixels and embed them in PDF catalogs.
 * 3. When a reporting tool requires converting resized PNG charts into PDF pages with a transparent canvas.
 * 4. When a mobile app backend must prepare printable PDFs from variable‑size PNG assets without distorting the original graphics.
 * 5. When an automated workflow needs to batch‑process PNG icons, pad them to a uniform size, and archive them as PDF files.
 */
