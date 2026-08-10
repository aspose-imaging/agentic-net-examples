// HOW-TO: Apply Median Filter to PNG and Save as Transparent PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png; // for raster image types if needed

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Prepare PDF save options with transparent background
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = rasterImage.Size
                    }
                };

                // Save the processed image as PDF
                rasterImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to clean up noise in a scanned PNG before embedding it in a PDF report with a transparent background.
 * 2. When you want to programmatically convert raster images to PDF while preserving transparency for overlay in document editors.
 * 3. When you must preprocess product photos with a median filter to remove speckles and then generate a PDF catalog page.
 * 4. When an automated workflow requires batch processing of images to improve visual quality and store the results as PDF files.
 * 5. When a web service needs to accept user‑uploaded PNGs, denoise them, and return a PDF that can be layered on top of other graphics.
 */
