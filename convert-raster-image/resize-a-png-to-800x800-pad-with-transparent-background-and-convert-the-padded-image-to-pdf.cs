using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/source.png";
            string paddedPngPath = "Output/padded.png";
            string pdfPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(paddedPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            const int targetSize = 800;

            using (RasterImage src = (RasterImage)Image.Load(inputPath))
            {
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

                if (!src.IsCached) src.CacheData();
                src.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                Source canvasSource = new FileCreateSource(paddedPngPath, false);
                PngOptions canvasOptions = new PngOptions() { Source = canvasSource };
                using (PngImage canvas = (PngImage)Image.Create(canvasOptions, targetSize, targetSize))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.Transparent);

                    int offsetX = (targetSize - newWidth) / 2;
                    int offsetY = (targetSize - newHeight) / 2;
                    Rectangle destRect = new Rectangle(offsetX, offsetY, newWidth, newHeight);
                    canvas.SaveArgb32Pixels(destRect, src.LoadArgb32Pixels(src.Bounds));

                    canvas.Save();
                }
            }

            using (Image pngImg = Image.Load(paddedPngPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pngImg.Save(pdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}