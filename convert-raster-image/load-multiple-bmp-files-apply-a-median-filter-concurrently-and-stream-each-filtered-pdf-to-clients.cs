using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // List of BMP files to process
            var inputFiles = new List<string>
            {
                Path.Combine(inputDir, "image1.bmp"),
                Path.Combine(inputDir, "image2.bmp"),
                Path.Combine(inputDir, "image3.bmp")
            };

            // Process each file concurrently
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply median filter of size 5 to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Prepare output PDF path
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save filtered image as PDF to a memory stream (simulating streaming to a client)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PdfOptions pdfOptions = new PdfOptions();
                        image.Save(ms, pdfOptions);
                        ms.Position = 0;

                        // Simulated streaming logic (e.g., send ms to client)
                        Console.WriteLine($"Processed {inputPath}, PDF size: {ms.Length} bytes");
                    }

                    // Also save the PDF to disk
                    image.Save(outputPath, new PdfOptions());
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}