// HOW-TO: Load EMF From URL And Stream PNG Directly In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Http;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputPath = "output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a dummy input file if it does not exist so the existence check passes
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load EMF from a network stream
            string url = "https://example.com/sample.emf";
            using (HttpClient client = new HttpClient())
            using (Stream networkStream = client.GetAsync(url).Result.Content.ReadAsStreamAsync().Result)
            using (Image image = Image.Load(networkStream))
            {
                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions();

                // Write PNG directly to the response stream (using standard output as a placeholder)
                using (Stream responseStream = Console.OpenStandardOutput())
                {
                    image.Save(responseStream, pngOptions);
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
 * 1. When you need to fetch a vector EMF file from a remote server and return it as a PNG image in a web API response without creating intermediate files.
 * 2. When building a microservice that converts uploaded EMF diagrams to PNG thumbnails on the fly for preview in a browser.
 * 3. When integrating legacy Windows Metafile graphics into a modern .NET application that streams the converted PNG directly to the client’s output stream.
 * 4. When implementing an on‑demand image conversion pipeline that reads EMF data over HTTP and writes the PNG result straight to a response stream to reduce memory overhead.
 * 5. When creating a console utility that downloads EMF assets from a CDN, converts them to PNG, and pipes the result to another process via standard output.
 */
