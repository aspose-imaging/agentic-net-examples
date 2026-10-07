// HOW-TO: Add 5 Pixel Border to BMPs and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string tempCanvasPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_border.bmp");
                string pdfPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

                using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
                {
                    int newWidth = bmp.Width + 10;
                    int newHeight = bmp.Height + 10;

                    Source canvasSource = new FileCreateSource(tempCanvasPath, false);
                    using (BmpOptions canvasOptions = new BmpOptions() { Source = canvasSource })
                    {
                        using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, newWidth, newHeight))
                        {
                            Graphics graphics = new Graphics(canvas);
                            graphics.Clear(Aspose.Imaging.Color.White);
                            graphics.DrawImage(bmp, new Rectangle(5, 5, bmp.Width, bmp.Height));
                            canvas.Save();
                        }
                    }
                }

                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                using (Image canvasImage = Image.Load(tempCanvasPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.PdfDocumentInfo = new Aspose.Imaging.FileFormats.Pdf.PdfDocumentInfo();
                        canvasImage.Save(pdfPath, pdfOptions);
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
 * 1. When you need to prepare a batch of BMP scans for printing by adding a uniform margin and saving each as a PDF document.
 * 2. When automating the creation of PDF portfolios from legacy BMP assets while ensuring every page has a consistent 5‑pixel frame.
 * 3. When a reporting system must process uploaded BMP images, add a small border for visual separation, and output them as PDFs for client download.
 * 4. When migrating a folder of BMP graphics to a PDF archive and you want the images to retain a defined border without manual editing.
 * 5. When generating printable PDFs from BMP screenshots in a CI pipeline, adding a thin border to meet layout guidelines before conversion.
 */
