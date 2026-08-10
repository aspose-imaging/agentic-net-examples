// HOW-TO: Apply Median Filter to Multiple BMPs and Convert to PDF Concurrently in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = {
                @"C:\Images\image1.bmp",
                @"C:\Images\image2.bmp",
                @"C:\Images\image3.bmp"
            };

            string[] outputPaths = {
                @"C:\Output\image1.pdf",
                @"C:\Output\image2.pdf",
                @"C:\Output\image3.pdf"
            };

            // Process each file concurrently
            Parallel.For(0, inputPaths.Length, i =>
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Apply median filter to the whole image
                    var rasterImage = (RasterImage)image;
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Prepare PDF options
                    var pdfOptions = new PdfOptions();

                    // Save filtered image to a memory stream as PDF
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, pdfOptions);

                        // Simulate streaming to client (e.g., write size to console)
                        Console.WriteLine($"Processed '{Path.GetFileName(inputPath)}' - PDF size: {memoryStream.Length} bytes");

                        // Write PDF to output file
                        File.WriteAllBytes(outputPath, memoryStream.ToArray());
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process scanned BMP documents, reduce noise with a median filter, and deliver each result as a PDF stream to a web client.
 * 2. When a web service must quickly convert user‑uploaded BMP images to PDF while applying noise‑reduction in parallel to improve throughput.
 * 3. When an automated reporting system has to generate PDF versions of multiple bitmap charts, applying a median filter to smooth visual artifacts before sending them to downstream applications.
 * 4. When a cloud‑based image‑processing pipeline requires concurrent handling of several BMP files, applying a median filter and streaming the filtered PDFs without writing intermediate files to disk.
 * 5. When a desktop application needs to load several BMP files, clean them with a median filter, and provide each cleaned image as a PDF stream for printing or email attachment.
 */
