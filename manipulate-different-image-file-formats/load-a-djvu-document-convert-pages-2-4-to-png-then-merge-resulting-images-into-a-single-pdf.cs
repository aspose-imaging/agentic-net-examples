using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPdfPath = "output.pdf";
            string tempPngPath = "merged.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                List<string> pngPaths = new List<string>();

                foreach (DjvuPage page in djvu.Pages)
                {
                    if (page.PageNumber >= 2 && page.PageNumber <= 4)
                    {
                        string pngPath = $"page_{page.PageNumber}.png";
                        Directory.CreateDirectory(Path.GetDirectoryName(pngPath) ?? ".");
                        page.Save(pngPath, new PngOptions());
                        pngPaths.Add(pngPath);
                    }
                }

                List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
                foreach (string p in pngPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(p))
                    {
                        sizes.Add(img.Size);
                    }
                }

                int canvasWidth = sizes.Max(s => s.Width);
                int canvasHeight = sizes.Sum(s => s.Height);

                Source canvasSource = new FileCreateSource(tempPngPath, false);
                PngOptions canvasOptions = new PngOptions() { Source = canvasSource };
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    int offsetY = 0;
                    foreach (string p in pngPaths)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(p))
                        {
                            Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetY += img.Height;
                        }
                    }

                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPdfPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}