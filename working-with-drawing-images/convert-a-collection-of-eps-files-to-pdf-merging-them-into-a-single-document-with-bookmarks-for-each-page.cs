// HOW-TO: Merge Multiple EPS Files into a Single PDF with Bookmarks in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            List<Image> images = new List<Image>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                if (!file.EndsWith(".eps", StringComparison.OrdinalIgnoreCase))
                    continue;

                Image img = Image.Load(file);
                images.Add(img);
            }

            if (images.Count == 0)
            {
                Console.WriteLine("No EPS files found.");
                return;
            }

            using (Image pdf = Image.Create(images.ToArray(), true))
            {
                PdfOptions pdfOptions = new PdfOptions();
                string outputPath = Path.Combine(outputDirectory, "Merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                pdf.Save(outputPath, pdfOptions);
            }

            foreach (var img in images)
            {
                img.Dispose();
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
 * 1. When you need to combine a series of vector EPS drawings into one searchable PDF for client delivery.
 * 2. When automating the creation of a product catalog where each EPS illustration becomes a separate bookmarked page in the final PDF.
 * 3. When generating printable reports that include EPS charts and want each chart accessible via PDF bookmarks.
 * 4. When building a batch conversion tool that processes incoming EPS files from a folder and outputs a consolidated PDF for archiving.
 * 5. When integrating Aspose.Imaging into a CI pipeline to ensure all EPS assets are merged into a single PDF document for easy distribution.
 */
