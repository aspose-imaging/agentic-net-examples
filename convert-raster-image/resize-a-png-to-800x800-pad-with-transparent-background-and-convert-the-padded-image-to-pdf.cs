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
            if (!src.IsCached) src.CacheData();

            int canvasSize = 800;
            int offsetX = src.Width < canvasSize ? (canvasSize - src.Width) / 2 : 0;
            int offsetY = src.Height < canvasSize ? (canvasSize - src.Height) / 2 : 0;

            using (PngImage canvas = new PngImage(canvasSize, canvasSize))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Transparent);

                Rectangle destRect = new Rectangle(offsetX, offsetY, src.Width, src.Height);
                canvas.SaveArgb32Pixels(destRect, src.LoadArgb32Pixels(src.Bounds));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    canvas.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}