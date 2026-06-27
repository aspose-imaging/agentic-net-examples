using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output/output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image, apply filter, and save filtered version
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply Gaussian blur filter
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

                // Save filtered image as WebP
                WebPOptions saveOptions = new WebPOptions();
                image.Save(outputPath, saveOptions);
            }

            // Start simple HTTP server to serve the filtered image
            using (System.Net.HttpListener listener = new System.Net.HttpListener())
            {
                listener.Prefixes.Add("http://localhost:8080/");
                listener.Start();
                Console.WriteLine("Listening on http://localhost:8080/");

                while (true)
                {
                    System.Net.HttpListenerContext context = listener.GetContext();
                    System.Net.HttpListenerResponse response = context.Response;
                    response.ContentType = "image/webp";

                    // Load filtered image into memory and write to response
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (RasterImage img = (RasterImage)Image.Load(outputPath))
                        {
                            WebPOptions opts = new WebPOptions();
                            img.Save(ms, opts);
                        }
                        ms.Position = 0;
                        ms.CopyTo(response.OutputStream);
                    }

                    response.OutputStream.Close();
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
 * 1. When a web application needs to generate a blurred preview of a user‑uploaded WebP image and deliver it instantly through a lightweight HTTP endpoint.
 * 2. When an e‑commerce site wants to create low‑resolution, privacy‑preserving thumbnails of product photos stored as WebP files before exposing them to third‑party partners.
 * 3. When a digital signage system must preprocess high‑quality WebP graphics with a Gaussian blur filter and serve the result to remote display clients over HTTP.
 * 4. When a content‑delivery network (CDN) wants to apply on‑the‑fly image smoothing to WebP assets retrieved from Azure Blob storage and stream the filtered version to browsers.
 * 5. When a mobile app backend needs to transform uploaded WebP images with a blur effect, store the processed file, and provide a simple HTTP URL for the app to fetch the filtered image.
 */