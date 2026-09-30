// HOW-TO: Batch Convert EPS Files To PDF Using C# Foreach Loop (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchEpsToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "InputEps";
                string outputDirectory = "OutputPdf";

                Directory.CreateDirectory(outputDirectory);

                string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

                foreach (string inputPath in epsFiles)
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
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically transform a folder of vector EPS artwork into printable PDF documents in a .NET application.
 * 2. When a publishing workflow requires converting multiple design files to PDF without manual intervention, using Aspose.Imaging in C#.
 * 3. When you want to generate PDF versions of EPS logos for web or email attachments during a batch processing job.
 * 4. When an automated build script must ensure all EPS assets are available as PDFs for downstream QA testing.
 * 5. When a desktop utility must read EPS files from a directory, convert each to PDF, and store them in a separate output folder for archiving.
 */
