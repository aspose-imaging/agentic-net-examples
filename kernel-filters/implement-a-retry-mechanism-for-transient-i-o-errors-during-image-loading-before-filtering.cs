using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Retry mechanism for loading the image
            const int maxAttempts = 3;
            int attempt = 0;
            RasterImage rasterImage = null;
            while (attempt < maxAttempts)
            {
                try
                {
                    // Load the image as RasterImage
                    rasterImage = (RasterImage)Image.Load(inputPath);
                    break; // Success
                }
                catch (IOException)
                {
                    attempt++;
                    if (attempt >= maxAttempts)
                    {
                        Console.Error.WriteLine($"Failed to load image after {maxAttempts} attempts.");
                        return;
                    }
                    // Optionally wait before retrying
                    System.Threading.Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error loading image: {ex.Message}");
                    return;
                }
            }

            using (rasterImage)
            {
                // Apply a Gaussian blur filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare JPEG options with a bound file source
                Source outputSource = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = outputSource,
                    Quality = 90
                };

                // Save the filtered image
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to load user‑uploaded PNG files from a temporary folder and apply a Gaussian blur before saving them as JPEGs, the retry logic protects against occasional file‑lock or network glitches.
 * 2. When a Windows service processes a nightly batch of images stored on a network share, the code ensures transient I/O errors do not abort the entire conversion pipeline.
 * 3. When an automated image‑processing pipeline in a CI/CD workflow reads PNG assets from a shared repository and outputs blurred JPEG previews, the retry mechanism handles intermittent disk latency.
 * 4. When a desktop utility converts scanned PNG documents to compressed JPEGs and applies a blur filter for privacy, the retry loop safeguards against temporary read failures caused by scanner driver delays.
 * 5. When a cloud‑based microservice streams PNG images from a mounted blob storage, applies a Gaussian blur, and writes JPEG results, the retry pattern helps recover from brief connectivity interruptions.
 */