using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input image path
            string inputPath = "Input/sample.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Set up a simple HTTP listener
            using (var listener = new System.Net.HttpListener())
            {
                listener.Prefixes.Add("http://localhost:8080/");
                listener.Start();
                Console.WriteLine("Listening on http://localhost:8080/ ...");

                // Wait for a single request
                var context = listener.GetContext();
                var response = context.Response;
                response.ContentType = "image/png";

                // Load the source image and convert to PNG directly into the response stream
                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(response.OutputStream, pngOptions);
                }

                // Close the response
                response.OutputStream.Close();
                response.Close();

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
 * 1. When a web application needs to let users download a JPEG photo as a PNG file without storing the converted image on the server, a developer can use this code to convert and stream the PNG directly to the HTTP response.
 * 2. When building a lightweight image‑conversion microservice that receives a request and returns the converted PNG instantly, this pattern of loading the source image with Aspose.Imaging and saving to response.OutputStream is ideal.
 * 3. When integrating on‑the‑fly format conversion into an ASP.NET Core endpoint for a mobile app that expects PNG thumbnails, developers can employ this approach to avoid temporary files and reduce I/O overhead.
 * 4. When creating a secure intranet tool that serves confidential scanned documents as PNGs over HTTPS, the code demonstrates how to validate the source file, convert it with PngOptions, and stream it directly to the client.
 * 5. When implementing a custom HTTP listener for a kiosk or IoT device that must deliver PNG images generated from existing JPEG assets in real time, this snippet shows the necessary C# operations to load, convert, and write the image to the response stream.
 */