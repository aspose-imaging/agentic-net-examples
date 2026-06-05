using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_eps";
            string outputFolder = "output_pdf";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            var epsFiles = Directory.GetFiles(inputFolder, "*.eps");
            foreach (var epsPath in epsFiles)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(epsPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
                {
                    epsImage.Save(outputPath, new PdfOptions());
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
 * 1. When a graphics studio must batch convert dozens of EPS artwork files into PDF documents for client delivery using C# and Aspose.Imaging’s Image.Load and PdfOptions.
 * 2. When an automated reporting system generates EPS charts and needs to transform them into PDF pages in a single run to embed in corporate reports.
 * 3. When a legal team receives EPS‑based contracts and wants to archive them as searchable PDF files by processing an entire folder with Aspose.Imaging in .NET.
 * 4. When a print shop receives EPS print proofs and requires a quick C# script to convert the whole batch to PDF for electronic proof‑reading and approval.
 * 5. When a web portal ingests vendor‑supplied EPS logos and must create PDF versions for preview and download, processing all files in a directory with Aspose.Imaging.
 */