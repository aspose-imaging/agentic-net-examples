// HOW-TO: Convert OTG File to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PdfOptions());
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
 * 1. When a web application needs to display vector graphics from OTG files as printable PDFs for end‑users.
 * 2. When an automated reporting system must batch‑convert archived OTG diagrams into PDF documents for archival compliance.
 * 3. When a desktop tool generates PDF invoices that include company logos stored in OTG format.
 * 4. When a cloud service processes user‑uploaded OTG images and returns PDF previews without manual intervention.
 * 5. When a migration script moves legacy OTG assets into a PDF‑based documentation repository using C#.
 */
