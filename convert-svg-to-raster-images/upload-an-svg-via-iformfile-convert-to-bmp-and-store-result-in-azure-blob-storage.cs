using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions options = new BmpOptions())
                {
                    image.Save(outputPath, options);
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
 * 1. When a web application needs to accept user‑uploaded SVG logos via an IFormFile, convert them to BMP for legacy Windows printing, and store the resulting bitmap in Azure Blob storage for centralized access.
 * 2. When an e‑commerce platform must transform scalable vector product illustrations uploaded through an ASP.NET Core form into BMP thumbnails and save them in Azure Blob containers for fast CDN delivery.
 * 3. When a document management system receives SVG diagrams via IFormFile, uses Aspose.Imaging to rasterize them to BMP format, and archives the bitmap files in Azure Blob storage for compliance retention.
 * 4. When a mobile backend service processes SVG icons submitted from a client app, converts them to BMP to meet a third‑party API’s bitmap requirement, and uploads the converted images to Azure Blob storage for later retrieval.
 * 5. When a reporting tool generates SVG charts, needs to export them as BMP files using C# code, and stores the output in Azure Blob storage so that other services can consume the raster images.
 */