using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_soft_focus.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)jpegImage;

                // Apply a Gaussian blur with a 7x7 kernel (soft focus effect)
                // Size = 7 (kernel dimension), Sigma = 1.0 (controls blur amount)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(7, 1.0));

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
 * 1. When a developer needs to add a soft‑focus effect to user‑uploaded JPEG photos in a web portal, they can use this Aspose.Imaging C# code to apply a normalized 7×7 Gaussian blur kernel before saving the image.
 * 2. When building a desktop photo‑editing tool that lets photographers preview a subtle blur on high‑resolution JPEGs, the code demonstrates how to load, filter, and overwrite the file with a 7×7 kernel for neutral brightness.
 * 3. When automating batch processing of product catalog images to create a gentle background blur while preserving color balance, the example shows how to apply a Gaussian blur filter with a 7×7 kernel to each JPEG file.
 * 4. When integrating image preprocessing into a machine‑learning pipeline that requires uniformly softened JPEG inputs, this snippet illustrates how to normalize the kernel and apply the filter using Aspose.Imaging for .NET.
 * 5. When developing a mobile‑backend service that receives raw JPEG uploads and needs to reduce sharp edges for a smoother UI experience, the code provides a straightforward way to apply a 7×7 Gaussian blur and save the softened image.
 */