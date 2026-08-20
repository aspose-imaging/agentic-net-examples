// HOW-TO: Batch Convert Multiple PNG Images to PDF Using Shared MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputPngs";
            string outputDirectory = @"C:\OutputPdfs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Collect individual PDF streams for later processing
            List<MemoryStream> pdfStreams = new List<MemoryStream>();

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PDF options (default settings)
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the image to a shared memory stream as PDF
                    MemoryStream pdfStream = new MemoryStream();
                    image.Save(pdfStream, pdfOptions);
                    pdfStream.Position = 0; // Reset for reading later
                    pdfStreams.Add(pdfStream);

                    // Determine the output PDF file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists (already created above, but follow rule)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Write the PDF stream to the output file
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        pdfStream.CopyTo(fileStream);
                    }

                    // Reset the memory stream for potential further use
                    pdfStream.Position = 0;
                }
            }

            // At this point, pdfStreams contains all PDFs in memory for further compression
            // (Compression logic would be added here as needed)
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate individual PDF files from a folder of PNG scans for archival or distribution.
 * 2. When you want to collect PDF streams in memory before applying a single compression step to reduce overall file size.
 * 3. When an automated batch job must convert product‑catalog images to PDFs without writing temporary files to disk.
 * 4. When a web service receives PNG uploads and must return PDF versions while keeping the conversion process efficient.
 * 5. When you are preparing printable PDF documents from PNG assets and need to manage the output paths programmatically.
 */
