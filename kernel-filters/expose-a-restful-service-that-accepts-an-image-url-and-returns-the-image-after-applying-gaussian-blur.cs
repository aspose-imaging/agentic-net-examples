using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image as a raster image
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                // Apply Gaussian blur filter (radius: 5, sigma: 4.0)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Prepare JPEG save options with bound source
                Source source = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = source,
                    Quality = 90
                };

                // Save the processed image
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
 * 1. When building a web API that lets users provide an image URL and receive a blurred JPEG for privacy‑preserving profile pictures, a developer can use this code to load the image, apply a Gaussian blur filter, and return the processed file.
 * 2. When creating an automated content‑moderation pipeline that obscures faces or sensitive objects in images before storing them in a CDN, the code provides a simple C# method to fetch the source image, apply a Gaussian blur with Aspose.Imaging, and save the result as a high‑quality JPEG.
 * 3. When developing a mobile‑backend service that generates preview thumbnails with a soft‑focus effect for e‑commerce product listings, the developer can call this routine to download the product image, blur it, and deliver the transformed image to the client.
 * 4. When implementing a server‑side image‑processing microservice that receives image URLs from a messaging app and returns a blurred version to reduce visual clutter, the code demonstrates how to load the remote file, apply a Gaussian blur filter, and output a JPEG using Aspose.Imaging in .NET.
 * 5. When integrating a digital‑signage system that needs to display background images with a subtle blur to improve text readability, a developer can use this example to fetch the background image via URL, apply a Gaussian blur with configurable radius and sigma, and serve the processed JPEG to the signage client.
 */