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
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.pdf";

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
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Resize to 640x480
                raster.Resize(640, 480);

                // Apply median filter with size 5
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save as PDF
                image.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to convert legacy BMP screenshots into compact PDF reports while standardizing them to a 640×480 resolution and reducing noise with a median filter.
 * 2. When an application must batch‑process scanned BMP documents, resize them for consistent layout, apply a median filter to improve readability, and save the results as searchable PDF files.
 * 3. When a web service receives user‑uploaded BMP images, needs to generate thumbnail‑size PDFs for email attachments, and wants to smooth the images using a 5‑pixel median filter.
 * 4. When a desktop utility has to prepare BMP graphics for printing by scaling them to 640×480, removing speckles with a median filter, and exporting the final artwork as a PDF portfolio.
 * 5. When an automated workflow converts BMP assets from a legacy system into PDF catalogs, ensuring each page is uniformly sized and visually cleaned with a median filter before archiving.
 */