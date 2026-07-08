using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage src = (RasterImage)Image.Load(inputPath))
            {
                const int targetSize = 800;
                double scale = Math.Min((double)targetSize / src.Width, (double)targetSize / src.Height);
                int newWidth = (int)(src.Width * scale);
                int newHeight = (int)(src.Height * scale);

                src.Resize(newWidth, newHeight);

                PngOptions canvasOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, targetSize, targetSize))
                {
                    int offsetX = (targetSize - newWidth) / 2;
                    int offsetY = (targetSize - newHeight) / 2;

                    canvas.SaveArgb32Pixels(
                        new Rectangle(offsetX, offsetY, newWidth, newHeight),
                        src.LoadArgb32Pixels(src.Bounds));

                    canvas.Save(outputPath, new PdfOptions());
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
 * 1. When a web application must generate printable PDFs from user‑uploaded PNG avatars, resizing them to a uniform 800 × 800 canvas with transparent padding to maintain aspect ratio.
 * 2. When an e‑commerce platform needs to create product catalog PDFs from product PNG images, ensuring each image fits an 800 × 800 page without distortion by scaling and centering on a transparent background.
 * 3. When a mobile app syncs screenshots as PNG files to a server and requires server‑side conversion to PDF for archival, standardizing each page to 800 × 800 with transparent padding.
 * 4. When a document management system imports PNG logos and must embed them in PDF reports, resizing the logos to 800 × 800 and adding transparent borders to align with the report layout.
 * 5. When a batch processing script prepares marketing assets by converting a collection of PNG graphics to PDF flyers, automatically scaling each graphic to 800 × 800 and centering it on a transparent canvas.
 */