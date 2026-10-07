// HOW-TO: Asynchronously Convert WMF To JPEG Using Task Run In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output\\output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            await Task.Run(() =>
            {
                using (Image image = Image.Load(inputPath))
                {
                    var options = new JpegOptions();
                    image.Save(outputPath, options);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to batch‑process legacy WMF vector graphics and store them as JPEG thumbnails without blocking the UI.
 * 2. When a web service receives WMF uploads and must generate JPEG previews on a background thread to keep request latency low.
 * 3. When an automated build pipeline converts design assets from WMF to JPEG for inclusion in documentation or marketing material.
 * 4. When a Windows service monitors a folder of WMF files and asynchronously creates JPEG versions for downstream image‑processing workflows.
 * 5. When a mobile‑oriented .NET Core app needs to render WMF icons as JPEG images on demand while preserving responsiveness.
 */
