// HOW-TO: Create a C# REST API to Apply Gaussian Blur to Remote Images (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var listener = new System.Net.HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();
            Console.WriteLine("Listening on http://localhost:5000/ ...");

            while (true)
            {
                var context = listener.GetContext();
                var request = context.Request;
                var response = context.Response;

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

                try
                {
                    var httpClient = new System.Net.Http.HttpClient();
                    using (var imageStream = httpClient.GetStreamAsync(imageUrl).GetAwaiter().GetResult())
                    {
                        using (var rasterImage = (RasterImage)Image.Load(imageStream))
                        {
                            var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                            rasterImage.Filter(rasterImage.Bounds, blurOptions);

                            using (var outputStream = new MemoryStream())
                            {
                                var jpegOptions = new JpegOptions();
                                rasterImage.Save(outputStream, jpegOptions);
                                byte[] imageBytes = outputStream.ToArray();

                                response.ContentType = "image/jpeg";
                                response.ContentLength64 = imageBytes.Length;
                                response.OutputStream.Write(imageBytes, 0, imageBytes.Length);
                            }
                        }
                    }
                    response.StatusCode = 200;
                }
                catch (Exception ex)
                {
                    response.StatusCode = 500;
                    using (var writer = new StreamWriter(response.OutputStream))
                    {
                        writer.Write($"Error processing image: {ex.Message}");
                    }
                }
                finally
                {
                    response.Close();
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
 * 1. When you need a lightweight web endpoint that receives an image URL and returns a blurred JPEG for privacy‑preserving thumbnails.
 * 2. When building a microservice that automatically softens user‑uploaded photos before storing them in a cloud bucket.
 * 3. When integrating a C# backend that provides on‑the‑fly Gaussian blur for image‑processing pipelines without saving intermediate files.
 * 4. When creating a simple API for mobile apps to request a blurred version of any public image without handling the image data locally.
 * 5. When developing a server‑side solution that fetches remote images, applies a 5‑pixel radius Gaussian blur, and streams the result back to the client.
 */
