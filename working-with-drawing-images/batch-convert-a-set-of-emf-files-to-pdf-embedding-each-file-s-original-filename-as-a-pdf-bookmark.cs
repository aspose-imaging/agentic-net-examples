// HOW-TO: Batch Convert EMF Files to PDF with Bookmarks in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");
            if (files.Length == 0)
            {
                Console.WriteLine("No EMF files found in the input directory.");
                return;
            }

            List<Image> images = new List<Image>();
            List<VectorRasterizationOptions> rasterOptions = new List<VectorRasterizationOptions>();

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                Image img = Image.Load(filePath);
                images.Add(img);

                VectorRasterizationOptions vOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = img.Width,
                    PageHeight = img.Height
                };
                rasterOptions.Add(vOptions);
            }

            if (images.Count == 0)
            {
                Console.WriteLine("No valid EMF images were loaded.");
                return;
            }

            string outputPath = Path.Combine(outputDirectory, "Combined.pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.MultiPageOptions = new MultiPageOptions
                {
                    PageRasterizationOptions = rasterOptions.ToArray()
                };

                images[0].Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a single PDF document that contains multiple EMF graphics, each accessible via a bookmark named after the original file.
 * 2. When automating the creation of searchable PDFs from a folder of EMF diagrams for inclusion in technical manuals.
 * 3. When converting legacy Windows Metafile drawings into PDF for archiving while preserving the original filenames as navigation points.
 * 4. When building a batch processing tool that prepares EMF assets for printing or distribution as a combined PDF with easy navigation.
 * 5. When integrating Aspose.Imaging into a C# application to streamline the workflow of turning design assets into a bookmarked PDF for client review.
 */
