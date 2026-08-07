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
            // Hard‑coded input PSD files
            string[] inputPaths = {
                @"C:\Images\image1.psd",
                @"C:\Images\image2.psd",
                @"C:\Images\image3.psd"
            };

            // Corresponding sigma values for each image
            double[] sigmas = { 2.0, 4.5, 3.2 };

            // Fixed blur radius (same for all images)
            int radius = 5;

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path (same folder, same name, .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage raster = (RasterImage)image;

                    // Apply Gaussian blur with specified radius and sigma
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(radius, sigmas[i]));

                    // Save the blurred image as PNG
                    raster.Save(outputPath);
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
 * 1. When a marketing team needs to batch‑process a set of Photoshop PSD files to create soft‑focused preview PNGs for a web gallery, a developer can use this code to apply custom Gaussian blur sigma values per image and save the results as PNG.
 * 2. When an e‑learning platform must generate blurred background images from layered PSD assets for slide templates, the code lets a C# developer load each PSD, apply a radius‑based Gaussian blur with image‑specific sigma, and output PNG files.
 * 3. When a digital asset management system requires automated conversion of high‑resolution PSD artwork into low‑resolution PNG thumbnails with varying blur intensity for privacy compliance, this snippet provides the necessary file‑format conversion and per‑image blur control.
 * 4. When a game developer wants to pre‑process character portrait PSDs by applying different levels of Gaussian blur before packaging them as PNG textures for performance‑optimized loading, the code handles the batch processing in .NET.
 * 5. When a publishing workflow needs to create print‑ready PNG proofs from source PSD files while softening each page with a custom sigma to reduce visual noise, a developer can employ this Aspose.Imaging example to automate the task.
 */