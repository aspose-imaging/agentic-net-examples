using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_median.png";

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
                // Cast to RasterImage to use filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // TODO: Insert background removal logic here if required

                // Apply a median filter with kernel size 3 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(3));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to clean up scanned PNG documents by removing stray specks after extracting the foreground, they can use this code to apply a 3‑pixel median filter with Aspose.Imaging in C#.
 * 2. When preparing product photos for an e‑commerce site, a programmer can remove the background and then smooth minor color noise in the resulting PNG using the median filter demonstrated above.
 * 3. When converting hand‑drawn PNG sketches into a polished digital asset, the code helps smooth jagged edges caused by background subtraction by applying a 3×3 median filter.
 * 4. When building an automated receipt‑processing pipeline, developers can load the PNG receipt, strip the background, and reduce isolated pixel artifacts with the median filter before OCR.
 * 5. When creating a batch‑processing tool for medical imaging PNG files, the sample shows how to eliminate tiny background remnants after segmentation by applying a median filter with a kernel size of three.
 */