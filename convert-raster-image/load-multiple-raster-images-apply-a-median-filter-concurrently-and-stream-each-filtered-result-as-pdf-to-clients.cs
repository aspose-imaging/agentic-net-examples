// HOW-TO: Apply Median Filter to Multiple Images in Parallel and Save as PDF C# (Aspose.Imaging for .NET)
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
            // Hardcoded input image paths
            string[] inputPaths = new[]
            {
                @"C:\Images\image1.png",
                @"C:\Images\image2.png",
                @"C:\Images\image3.png"
            };

            // Corresponding hardcoded output PDF paths
            string[] outputPaths = new[]
            {
                @"C:\Output\image1.pdf",
                @"C:\Output\image2.pdf",
                @"C:\Output\image3.pdf"
            };

            // Validate each input file exists; if any missing, write error and exit
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Process images concurrently
            Parallel.ForEach(
                // Create a range of indices to keep input and output aligned
                Enumerable.Range(0, inputPaths.Length),
                index =>
                {
                    string inputPath = inputPaths[index];
                    string outputPath = outputPaths[index];

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the raster image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Cast to RasterImage to apply filter
                        RasterImage rasterImage = (RasterImage)image;

                        // Apply median filter with size 5 to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                        // Prepare PDF save options
                        PdfOptions pdfOptions = new PdfOptions();

                        // Save filtered image to a memory stream as PDF
                        using (MemoryStream pdfStream = new MemoryStream())
                        {
                            rasterImage.Save(pdfStream, pdfOptions);

                            // At this point pdfStream contains the PDF data.
                            // For demonstration, write the PDF to the output file.
                            // In a real scenario, the stream would be sent to the client.
                            File.WriteAllBytes(outputPath, pdfStream.ToArray());
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
 * 1. When you need to denoise a batch of PNG or JPEG photos on a server and deliver each cleaned version as a PDF report.
 * 2. When an e‑commerce platform must process product images concurrently to reduce noise before generating printable PDF catalogs.
 * 3. When a medical imaging system wants to apply a median filter to multiple scanned slides in parallel and export them as PDF for archival.
 * 4. When a document management workflow requires fast conversion of noisy raster scans into searchable PDF files using C# and Aspose.Imaging.
 * 5. When a cloud‑based API has to stream filtered image results as PDFs to multiple clients without blocking the main thread.
 */
