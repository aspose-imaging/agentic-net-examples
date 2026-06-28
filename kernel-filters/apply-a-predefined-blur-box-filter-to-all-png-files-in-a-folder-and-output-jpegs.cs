using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists (will be called for each file as required)
            // This call is placed inside the loop per the safety rule.
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .jpg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (acts as a blur box filter)
                    // Radius = 5, Sigma = 4.0 as an example
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save as JPEG with default options
                    JpegOptions jpegOptions = new JpegOptions();
                    rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to batch‑process a folder of PNG assets and apply a Gaussian blur (blur box) filter before converting them to JPEG for faster web loading, this code provides a ready‑made C# solution using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must automatically obscure product background details in uploaded PNG images and store the softened results as JPEG thumbnails, the example demonstrates how to apply the blur filter and save the output with C# file I/O.
 * 3. When a content‑management system requires nightly conversion of high‑resolution PNG graphics to compressed JPEGs while adding a subtle blur to protect copyrighted elements, the snippet shows the exact steps with Aspose.Imaging’s RasterImage filter API.
 * 4. When a mobile app backend needs to generate blurred preview images from user‑submitted PNG files and deliver them as JPEGs to reduce bandwidth, this code illustrates the end‑to‑end process in C#.
 * 5. When a digital‑signage solution must pre‑process PNG logos with a blur box effect and store them as JPEGs for compatibility with older display hardware, the example provides a concise implementation using Aspose.Imaging for .NET.
 */