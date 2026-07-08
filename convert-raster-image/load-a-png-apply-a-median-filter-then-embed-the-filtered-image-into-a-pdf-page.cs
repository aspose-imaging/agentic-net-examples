using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.png";
            string outputPath = "Output/filtered.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Apply a median filter with size 5 to the entire image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save the filtered image into a PDF document
                PdfOptions pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to clean up noisy PNG scans of handwritten forms and embed the filtered image into a PDF report for archiving.
 * 2. When a C# application must automatically remove salt‑and‑pepper noise from PNG screenshots before generating a PDF user guide.
 * 3. When an image processing pipeline requires applying a median filter to a PNG logo and then packaging the result as a PDF invoice attachment.
 * 4. When a document conversion tool has to convert PNG product photos with speckle reduction into a single‑page PDF catalog.
 * 5. When a .NET service processes uploaded PNG receipts, denoises them with a median filter, and stores the final image as a searchable PDF file.
 */