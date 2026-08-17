// HOW-TO: Convert EMF Files to PDF with Date Header in C# (Aspose.Imaging for .NET)
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
            string inputFolder = "C:\\InputEmf";
            string outputFolder = "C:\\OutputPdf";

            Directory.CreateDirectory(outputFolder);

            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    Graphics graphics = new Graphics(image);
                    string headerText = $"Converted on {DateTime.Now:yyyy-MM-dd}";
                    Font font = new Font("Arial", 24);
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        graphics.DrawString(headerText, font, brush, 10, 10);
                    }

                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageSize = new SizeF(image.Width, image.Height)
                        }
                    };

                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to batch‑convert a folder of Windows Metafile (EMF) drawings into PDF reports and include a “Converted on” date stamp on every page.
 * 2. When generating archival PDFs from legacy EMF diagrams and want the conversion date automatically added for compliance documentation.
 * 3. When creating printable PDFs from vector graphics in a C# application and require a consistent header showing the processing date for version tracking.
 * 4. When automating the preparation of design assets for client delivery, converting multiple EMF files to PDF while embedding the current date as a header on each page.
 * 5. When building a server‑side service that receives EMF uploads, converts them to PDF, and adds a timestamp header to indicate when the conversion occurred.
 */
