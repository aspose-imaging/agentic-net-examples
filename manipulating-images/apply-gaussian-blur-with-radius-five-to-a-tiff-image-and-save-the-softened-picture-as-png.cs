using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to soften the details of a high‑resolution TIFF scan (e.g., a scanned document or photograph) before publishing it as a web‑friendly PNG, they can use this code to apply a Gaussian blur with radius five and convert the format.
 * 2. When an application must generate preview thumbnails of large TIFF images for a gallery and wants the previews to have a subtle blur effect to reduce visual noise, this snippet shows how to blur and save them as PNG files.
 * 3. When integrating a document‑management system that stores original TIFF files but requires blurred PNG copies for privacy‑sensitive viewing, the code demonstrates the necessary C# steps with Aspose.Imaging.
 * 4. When a batch‑processing tool needs to automatically apply a Gaussian blur to medical imaging TIFFs (e.g., X‑ray or MRI scans) and output them as PNG for easier sharing with clinicians, this example provides the exact workflow.
 * 5. When a developer is building a reporting service that converts scanned TIFF invoices into blurred PNG images to protect confidential details while still showing layout, the code illustrates how to achieve that using Aspose.Imaging for .NET.
 */