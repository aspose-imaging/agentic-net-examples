// HOW-TO: Batch Convert Images to PDF with Current Date Watermark in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

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

            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    Graphics graphics = new Graphics(image);
                    string watermarkText = DateTime.Now.ToString("yyyy-MM-dd");
                    Font font = new Font("Arial", 24);
                    SolidBrush brush = new SolidBrush(Color.Yellow);
                    float x = image.Width - (font.Size * watermarkText.Length) - 10;
                    float y = image.Height - font.Size - 10;
                    graphics.DrawString(watermarkText, font, brush, new PointF(x, y));

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
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
 * 1. When a company needs to archive daily scanned receipts as PDF files and stamp each with the processing date automatically.
 * 2. When a photographer wants to generate PDF portfolios from a folder of JPEGs while adding a date watermark to protect copyright.
 * 3. When an invoicing system must convert PNG invoice images to PDF and embed the current date as a verification mark before sending to clients.
 * 4. When a legal firm needs to batch‑process evidence photos into PDFs and include the capture date as a visible watermark for chain‑of‑custody records.
 * 5. When a document management workflow requires converting various raster image formats to PDF and tagging each file with the generation date for audit trails.
 */
