// HOW-TO: Batch Convert EMF Files to PDF with Date Header in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    Graphics graphics = new Graphics(image);
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        string header = $"Converted on {DateTime.Now:yyyy-MM-dd}";
                        graphics.DrawString(header, font, brush, new Point(10, 10));
                    }

                    PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to generate printable PDF reports from a collection of EMF vector graphics and include the conversion date on each page.
 * 2. When an automated workflow must archive legacy EMF diagrams as PDFs while adding a timestamp for audit compliance.
 * 3. When a desktop application has to batch‑process user‑uploaded EMF files and produce PDF versions with a consistent header for branding.
 * 4. When a server‑side service converts EMF assets to PDF for downstream systems and requires a date stamp to track processing time.
 * 5. When you want to create a searchable PDF catalog of EMF illustrations and need the conversion date displayed on every page for version control.
 */
