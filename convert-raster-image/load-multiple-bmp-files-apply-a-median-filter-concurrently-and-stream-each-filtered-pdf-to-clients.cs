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
            // Hardcoded input BMP files
            string[] inputFiles = new string[]
            {
                @"C:\Images\image1.bmp",
                @"C:\Images\image2.bmp",
                @"C:\Images\image3.bmp"
            };

            // Hardcoded output directory for PDF files
            string outputDirectory = @"C:\Output";

            // Ensure the output directory exists once (unconditional as per rule)
            Directory.CreateDirectory(outputDirectory);

            // Process each file concurrently
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply median filter with size 5 to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the filtered image as PDF to the file system
                    image.Save(outputPath, pdfOptions);

                    // Additionally, stream the PDF to a memory stream (simulating client streaming)
                    using (MemoryStream pdfStream = new MemoryStream())
                    {
                        image.Save(pdfStream, pdfOptions);
                        // Example: output the size of the streamed PDF
                        Console.WriteLine($"Streamed PDF for '{inputPath}' - {pdfStream.Length} bytes");
                        // In a real scenario, the stream would be sent to a client here.
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
 * 1. When a web service must convert uploaded BMP scans of handwritten forms into noise‑reduced PDF documents on the fly, using C# and Aspose.Imaging’s median filter with parallel processing to serve each PDF instantly to the client.
 * 2. When an enterprise batch job needs to process large collections of legacy BMP satellite imagery, apply a median filter to remove speckle noise, and stream the cleaned results as PDFs to downstream GIS applications.
 * 3. When a medical imaging portal receives BMP X‑ray images, requires concurrent denoising with a median filter before generating PDF reports that are streamed securely to clinicians’ browsers.
 * 4. When an e‑learning platform automatically transforms teacher‑uploaded BMP worksheets into high‑quality PDF handouts, applying a median filter to improve readability while handling multiple files simultaneously in C#.
 * 5. When a digital archiving system must ingest BMP photographs, apply a median filter to smooth grainy scans, and deliver each filtered image as a PDF through an API without storing intermediate files.
 */