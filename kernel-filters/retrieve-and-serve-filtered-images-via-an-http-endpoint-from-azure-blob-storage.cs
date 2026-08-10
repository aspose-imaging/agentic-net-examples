// HOW-TO: Serve Grayscale WebP Image Via HTTP In C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.webp";
            string outputPath = "Output/filtered.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var webp = (WebPImage)image;
                webp.Grayscale();

                var options = new WebPOptions();
                webp.Save(outputPath, options);
            }

            using (var listener = new System.Net.HttpListener())
            {
                listener.Prefixes.Add("http://localhost:5000/");
                listener.Start();
                Console.WriteLine("Listening on http://localhost:5000/ ...");

                var context = listener.GetContext();
                var response = context.Response;

                byte[] imageBytes = File.ReadAllBytes(outputPath);
                response.ContentType = "image/webp";
                response.ContentLength64 = imageBytes.Length;
                using (var output = response.OutputStream)
                {
                    output.Write(imageBytes, 0, imageBytes.Length);
                }

                listener.Stop();
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
 * 1. When you need to deliver a grayscale WebP version of an uploaded picture directly to a browser via a simple HTTP endpoint.
 * 2. When building a microservice that applies image filters on demand and returns the processed image without persisting intermediate files.
 * 3. When creating a lightweight preview server that serves filtered WebP images for mobile or web applications.
 * 4. When testing an Aspose.Imaging image‑processing workflow locally before moving it to Azure Blob Storage.
 * 5. When integrating on‑the‑fly image conversion into an existing C# API that must respond with the correct content‑type header.
 */
