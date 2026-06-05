using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths and blob URL
            string blobUrl = "https://example.blob.core.windows.net/container/sample.png";
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Download image from Azure Blob Storage
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var data = httpClient.GetByteArrayAsync(blobUrl).Result;
                System.IO.File.WriteAllBytes(inputPath, data);
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load, apply a simple filter, and save
            using (var image = (PngImage)Image.Load(inputPath))
            {
                image.AdjustBrightness(20); // example filter
                image.Save(outputPath);
            }

            // Serve the processed image via HTTP
            using (var listener = new System.Net.HttpListener())
            {
                listener.Prefixes.Add("http://localhost:5000/");
                listener.Start();
                Console.WriteLine("Listening on http://localhost:5000/ ...");

                while (true)
                {
                    var context = listener.GetContext();
                    var response = context.Response;

                    if (File.Exists(outputPath))
                    {
                        var bytes = File.ReadAllBytes(outputPath);
                        response.ContentType = "image/png";
                        response.ContentLength64 = bytes.Length;
                        response.OutputStream.Write(bytes, 0, bytes.Length);
                    }
                    else
                    {
                        response.StatusCode = 404;
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
 * 1. When a web service must fetch a PNG image from Azure Blob Storage, adjust its brightness, and deliver the modified image to browsers via an HTTP endpoint.
 * 2. When building a C# microservice that processes user‑uploaded images stored in Azure, applies simple filters like brightness adjustment, and returns the result as a PNG response.
 * 3. When creating a lightweight image‑processing API that reads images from a cloud blob, performs on‑the‑fly transformations with Aspose.Imaging, and streams the output to client applications.
 * 4. When implementing a server‑side thumbnail generator that pulls high‑resolution PNG files from Azure, tweaks visual properties, saves a cached version, and serves it over HTTP.
 * 5. When developing a diagnostic tool that validates image availability in Azure Blob Storage, applies a quick visual enhancement, and exposes the processed file through a local HTTP listener for testing.
 */