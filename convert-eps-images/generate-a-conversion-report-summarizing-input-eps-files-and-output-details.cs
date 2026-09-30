// HOW-TO: Generate EPS to PDF and PNG Conversion Report with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");
            string reportPath = Path.Combine(outputDirectory, "ConversionReport.txt");

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

            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");
            var reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("FileName,Dimensions,PDFPath,PNGPath");

            foreach (string epsPath in epsFiles)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(epsPath);
                string pdfPath = Path.Combine(outputDirectory, fileName + ".pdf");
                string pngPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
                Directory.CreateDirectory(Path.GetDirectoryName(pngPath));

                using (Image image = Image.Load(epsPath))
                {
                    var epsImage = (EpsImage)image;
                    epsImage.Save(pdfPath, new PdfOptions());
                    epsImage.Save(pngPath, new PngOptions());

                    int width = image.Width;
                    int height = image.Height;
                    reportBuilder.AppendLine($"{fileName},{width}x{height},{pdfPath},{pngPath}");
                }
            }

            File.WriteAllText(reportPath, reportBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a folder of EPS artwork into PDF and PNG files while tracking each file’s dimensions and output paths.
 * 2. When an automated build process must create a printable PDF version and a web‑ready PNG thumbnail for every EPS asset in a design repository.
 * 3. When a document management system requires a CSV‑style report that lists the original EPS name, image size, and locations of the generated PDF and PNG files.
 * 4. When a migration script has to ensure output directories exist before saving converted images to avoid runtime errors.
 * 5. When troubleshooting missing or corrupted EPS files, the code logs a clear error message and stops processing to prevent further failures.
 */
