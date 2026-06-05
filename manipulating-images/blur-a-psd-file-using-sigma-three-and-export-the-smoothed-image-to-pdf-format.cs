using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/blurred.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 3
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 3.0);
                raster.Filter(raster.Bounds, blurOptions);

                // Save the blurred image as PDF
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
 * 1. When a developer needs to automatically soften the details of a Photoshop PSD design before sharing it with clients as a PDF portfolio, they can use this C# code to apply a Gaussian blur with sigma 3 and export the result to PDF.
 * 2. When a web application must generate a preview PDF of a high‑resolution PSD file with a subtle blur to protect copyrighted artwork, the code demonstrates how to load the PSD, apply a sigma‑3 Gaussian blur, and save it as a PDF using Aspose.Imaging for .NET.
 * 3. When an automated reporting tool has to embed blurred background images from layered PSD files into PDF reports for visual consistency, this snippet shows the C# steps to filter the raster image and convert it to PDF format.
 * 4. When a digital asset management system needs to create low‑detail PDF thumbnails of PSD files for quick browsing, the example illustrates applying a Gaussian blur (radius 5, sigma 3) and saving the blurred image as a PDF with Aspose.Imaging.
 * 5. When a developer is building a batch‑processing pipeline that sanitizes sensitive layers in PSD files by blurring them before archiving the files as PDFs, this code provides the exact C# workflow to perform the sigma‑3 blur and PDF export.
 */