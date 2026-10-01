// HOW-TO: Batch Convert Multiple PNG Images to a Single PDF Using MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputFolder = "input";
            string outputPdfPath = "output/combined.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Shared memory stream to aggregate PDFs
            using (MemoryStream aggregatedStream = new MemoryStream())
            {
                // Get all PNG files in the input folder
                string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

                foreach (string pngPath in pngFiles)
                {
                    // Validate input file existence
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        return;
                    }

                    // Load PNG image
                    using (Image image = Image.Load(pngPath))
                    {
                        // Save as PDF into the shared memory stream
                        PdfOptions pdfOptions = new PdfOptions();
                        image.Save(aggregatedStream, pdfOptions);
                    }
                }

                // Write aggregated PDF bytes to the output file
                aggregatedStream.Position = 0;
                using (FileStream fileStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write))
                {
                    aggregatedStream.CopyTo(fileStream);
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
 * 1. When you need to merge dozens of product screenshots (PNG) into one searchable PDF report without creating temporary files.
 * 2. When an automated build process must generate a single PDF portfolio from a folder of PNG assets for archiving or emailing.
 * 3. When a web service receives multiple PNG uploads and must return a combined PDF to the client while keeping the data in memory for further compression.
 * 4. When you want to consolidate scanned PNG pages into a single PDF document before applying Aspose.Imaging’s PDF compression features.
 * 5. When a desktop application needs to batch‑convert user‑selected PNG files into a combined PDF for printing or offline viewing.
 */
