using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Input BMP file and output PDF file paths
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply a median filter with size 5 to the whole image
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                // Save the filtered image as a PDF
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to clean up scanned BMP documents by removing noise with a median filter before archiving them as searchable PDF files.
 * 2. When an application must convert legacy BMP graphics from an industrial system into PDF reports while smoothing pixelated edges using Aspose.Imaging's median filter in C#.
 * 3. When a web service processes user‑uploaded BMP images, applies a 5‑pixel median filter to improve visual quality, and returns the result as a PDF for easy viewing.
 * 4. When a batch job automates the transformation of BMP screenshots into PDF manuals, using the median filter to reduce speckle artifacts in the final document.
 * 5. When a developer integrates Aspose.Imaging into a C# workflow to normalize BMP image noise and generate PDF invoices that meet corporate document standards.
 */