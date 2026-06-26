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
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to 300x300
                image.Resize(300, 300);

                // Apply median filter
                RasterImage raster = (RasterImage)image;
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
 * 1. When a developer needs to convert legacy BMP scans of documents into compact 300 × 300 PDF files while reducing noise with a median filter, this code provides a quick C# solution using Aspose.Imaging.
 * 2. When an e‑commerce platform must generate product catalog pages from high‑resolution BMP images, resizing them to a uniform 300 × 300 thumbnail, smoothing artifacts, and saving as PDF for printing, the example shows how to automate the process.
 * 3. When a medical imaging system requires batch processing of BMP X‑ray images to a standard 300 × 300 size, apply a 5‑pixel median filter to remove speckle, and archive the results as searchable PDF reports, the code demonstrates the necessary steps.
 * 4. When a government agency needs to digitize archived BMP maps, normalize them to a 300 × 300 resolution, clean up noise with a median filter, and distribute the final maps as PDF files, this snippet illustrates the workflow in C#.
 * 5. When a desktop application must allow users to import BMP screenshots, automatically resize them to 300 × 300, apply a median filter for visual smoothing, and export the cleaned image as a PDF document, the provided code handles the entire pipeline.
 */