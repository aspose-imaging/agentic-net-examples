using System;
using System.IO;
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
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each PNG file in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.png"))
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    var rasterImage = (RasterImage)image;

                    // Apply median filter with size 5 to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Prepare output PDF path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the filtered image as PDF
                    rasterImage.Save(outputPath, new PdfOptions());
                }
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
 * 1. When a developer uses Aspose.Imaging for .NET to batch‑process a folder of PNG screenshots, apply a median filter to remove noise, and save each result as a PDF for documentation archives.
 * 2. When an e‑commerce site needs to automatically denoise product PNG images with a median filter and convert them to PDF catalogs using C# and Aspose.Imaging.
 * 3. When a medical records system must cleanse PNG scans of X‑ray images with a median filter and generate PDF files for secure patient files via Aspose.Imaging.
 * 4. When a GIS application requires smoothing PNG map tiles with a median filter and exporting them as PDF pages for printed reports using Aspose.Imaging for .NET.
 * 5. When a publishing pipeline has to batch‑convert PNG illustrations to PDF after applying a median filter to improve print quality, leveraging C# and Aspose.Imaging.
 */