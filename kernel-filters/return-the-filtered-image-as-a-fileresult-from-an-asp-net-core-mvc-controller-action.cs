using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.webp";
            string outputPath = "output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var options = new WebPOptions();
                image.Save(outputPath, options);
            }

            Console.WriteLine($"Image saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to convert uploaded WebP images to a standardized format and stream the processed file back to the browser as a FileResult in an ASP.NET Core MVC action.
 * 2. When an e‑commerce site wants to apply server‑side compression to product photos and deliver the optimized WebP image directly to the client without storing a temporary file.
 * 3. When a content management system must generate thumbnails on the fly from original WebP assets and return them as downloadable files via a controller endpoint.
 * 4. When a mobile backend API has to resize or re‑encode user‑submitted WebP pictures and send the transformed image back as an HTTP response using FileResult.
 * 5. When a reporting dashboard requires on‑demand conversion of legacy image formats to WebP and needs to serve the resulting file through an ASP.NET Core MVC controller for immediate preview.
 */