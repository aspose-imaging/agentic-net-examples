using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

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

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            int canvasWidth = Math.Max(raster.Width, 800);
            int canvasHeight = Math.Max(raster.Height, 800);
            int offsetX = (canvasWidth - raster.Width) / 2;
            int offsetY = (canvasHeight - raster.Height) / 2;

            PdfOptions pdfOptions = new PdfOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image pdfCanvas = Image.Create(pdfOptions, canvasWidth, canvasHeight))
            {
                Graphics graphics = new Graphics(pdfCanvas);
                graphics.DrawImage(raster, new Rectangle(offsetX, offsetY, raster.Width, raster.Height));
                pdfCanvas.Save();
            }
        }
    }
}