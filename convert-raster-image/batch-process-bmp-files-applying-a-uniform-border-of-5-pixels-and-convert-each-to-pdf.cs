using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string[] inputFiles = new string[]
        {
            @"C:\Images\image1.bmp",
            @"C:\Images\image2.bmp",
            @"C:\Images\image3.bmp"
        };

        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.ChangeExtension(inputPath, ".pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage src = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int borderSize = 5;
                int newWidth = src.Width + borderSize * 2;
                int newHeight = src.Height + borderSize * 2;

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(new BmpOptions(), newWidth, newHeight))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(borderSize, borderSize, src.Width, src.Height);
                    canvas.SaveArgb32Pixels(destRect, src.LoadArgb32Pixels(src.Bounds));

                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}