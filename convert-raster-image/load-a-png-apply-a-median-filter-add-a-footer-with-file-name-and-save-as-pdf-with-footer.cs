using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

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

            // Apply median filter with size 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Draw footer with file name
            Graphics graphics = new Graphics(image);
            Font font = new Font("Arial", 12);
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                float x = 10;
                float y = image.Height - 20;
                graphics.DrawString(Path.GetFileName(inputPath), font, brush, new PointF(x, y));
            }

            // Save as PDF
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}