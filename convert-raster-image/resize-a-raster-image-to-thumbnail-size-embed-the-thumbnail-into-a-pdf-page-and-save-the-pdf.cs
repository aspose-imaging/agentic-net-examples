using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "source.jpg");
        string outputPath = Path.Combine("Output", "thumbnail.pdf");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int thumbWidth = 150;
        int thumbHeight = 150;

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            sourceImage.Resize(thumbWidth, thumbHeight);

            Source pdfSource = new FileCreateSource(outputPath, false);
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.Source = pdfSource;

                using (Image pdfCanvas = Image.Create(pdfOptions, thumbWidth, thumbHeight))
                {
                    Graphics graphics = new Graphics(pdfCanvas);
                    graphics.DrawImage(sourceImage, new Rectangle(0, 0, thumbWidth, thumbHeight));
                    pdfCanvas.Save();
                }
            }
        }
    }
}