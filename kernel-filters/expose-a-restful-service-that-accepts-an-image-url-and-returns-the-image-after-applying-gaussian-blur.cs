// HOW-TO: Create C# REST API to Apply Gaussian Blur to Image URL (Aspose.Imaging for .NET)
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
            // Hardcoded paths for temporary storage
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up a simple HTTP listener
            var listener = new System.Net.HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();
            Console.WriteLine("Listening on http://localhost:5000/ ...");

            while (true)
            {
                var context = listener.GetContext(); // Wait for a request
                var request = context.Request;
                var response = context.Response;

                // Expect a query parameter named 'url'
                string imageUrl = request.QueryString["url"];
                if (string.IsNullOrEmpty(imageUrl))
                {
                    response.StatusCode = 400;
                    using (var writer = new StreamWriter(response.OutputStream))
                    {
                        writer.Write("Missing 'url' query parameter.");
                    }
                    response.Close();
                    continue;
                }

                // Download the image to the hardcoded input path
                using (var client = new System.Net.WebClient())
                {
                    client.DownloadFile(imageUrl, inputPath);
                }

                // Verify the downloaded file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    response.StatusCode = 500;
                    response.Close();
                    continue;
                }

                // Load, apply Gaussian blur, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    Source src = new FileCreateSource(outputPath, false);
                    PngOptions pngOptions = new PngOptions() { Source = src };
                    raster.Save(outputPath, pngOptions);
                }

                // Return the processed image
                byte[] resultBytes = File.ReadAllBytes(outputPath);
                response.ContentType = "image/png";
                response.ContentLength64 = resultBytes.Length;
                response.OutputStream.Write(resultBytes, 0, resultBytes.Length);
                response.OutputStream.Close();
                response.Close();
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
 * 1. When you need a lightweight web endpoint that receives a remote JPEG or PNG, blurs it with Aspose.Imaging, and returns the processed image to a web or mobile client.
 * 2. When building a microservice that automatically sanitizes user‑uploaded photos by applying a Gaussian blur before storing them in a CDN.
 * 3. When creating a server‑side image preview generator that accepts an image URL, adds a soft blur effect, and streams the result without saving intermediate files.
 * 4. When integrating image processing into an existing C# application that must expose a simple HTTP listener for on‑the‑fly photo transformations.
 * 5. When developing a proof‑of‑concept API for testing how Gaussian blur impacts OCR accuracy on images fetched from external sources.
 */
