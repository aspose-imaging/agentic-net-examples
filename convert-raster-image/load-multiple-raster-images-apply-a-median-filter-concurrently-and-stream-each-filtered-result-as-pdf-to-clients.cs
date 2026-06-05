using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = {
                @"C:\Images\image1.png",
                @"C:\Images\image2.jpg"
            };

            string[] outputPaths = {
                @"C:\Output\image1.pdf",
                @"C:\Output\image2.pdf"
            };

            // Process each image concurrently
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

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a median filter (size = 5) to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Prepare PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the filtered image as a PDF file
                    rasterImage.Save(outputPath, pdfOptions);

                    // Additionally, stream the PDF to a memory stream (simulating client streaming)
                    using (MemoryStream ms = new MemoryStream())
                    {
                        rasterImage.Save(ms, pdfOptions);
                        // Example: output the size of the streamed PDF
                        Console.WriteLine($"Processed {Path.GetFileName(inputPath)} -> {Path.GetFileName(outputPath)} ({ms.Length} bytes)");
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