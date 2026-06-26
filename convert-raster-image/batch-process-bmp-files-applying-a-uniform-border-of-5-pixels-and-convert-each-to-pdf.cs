using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

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

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage src = (RasterImage)Image.Load(inputPath))
                {
                    int border = 5;
                    int newWidth = src.Width + border * 2;
                    int newHeight = src.Height + border * 2;

                    BmpOptions bmpOptions = new BmpOptions();

                    using (Image canvas = Image.Create(bmpOptions, newWidth, newHeight))
                    {
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(Color.White);
                        graphics.DrawImage(src, new Rectangle(border, border, src.Width, src.Height));

                        canvas.Save(outputPath, new PdfOptions());
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
 * 1. When a company needs to archive scanned engineering drawings stored as BMP files, adding a uniform white border and converting them to PDF for consistent printing and document management.
 * 2. When an e‑learning platform wants to batch‑prepare BMP screenshots of software tutorials, framing each image with a 5‑pixel margin and packaging them as PDFs for easy distribution to learners.
 * 3. When a legal firm must submit BMP evidence images with a required margin for court filings, automatically adding the border and converting each file to PDF to meet filing standards.
 * 4. When a marketing team creates product catalogs from BMP assets and requires a clean white edge around each image before generating PDF pages for print‑ready brochures.
 * 5. When a medical imaging system exports BMP scans that need a standardized border for patient records, and the workflow converts the bordered images to PDF for secure archival in electronic health records.
 */