// HOW-TO: Convert Multiple EPS Files To PDF In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "input_eps";
            string outputDir = "output_pdf";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add EPS files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] epsFiles = Directory.GetFiles(inputDir, "*.eps");
            foreach (string epsPath in epsFiles)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(epsPath);
                string pdfPath = Path.Combine(outputDir, fileName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                using (EpsImage epsImage = (EpsImage)Aspose.Imaging.Image.Load(epsPath))
                {
                    epsImage.Save(pdfPath, new PdfOptions());
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
 * 1. When you need to automatically convert a folder of vector EPS artwork into PDF documents for client delivery or archival using C#.
 * 2. When a publishing workflow requires batch processing of EPS files into PDF format before sending them to a print service.
 * 3. When you want to integrate EPS‑to‑PDF conversion into a .NET backend that generates reports containing embedded vector graphics.
 * 4. When you must create a script that scans an input directory, converts each EPS file to PDF, and saves the results to a separate output folder for further processing.
 * 5. When you are building a document management system that needs to standardize incoming EPS files as searchable PDFs without manual intervention.
 */
