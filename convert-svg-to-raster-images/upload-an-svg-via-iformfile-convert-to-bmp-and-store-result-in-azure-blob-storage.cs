// HOW-TO: Convert Uploaded SVG to BMP and Save to Azure Blob in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and convert to BMP
            using (Image image = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
            }

            // Placeholder: Upload the BMP file at outputPath to Azure Blob storage using appropriate SDK or REST API.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application receives an SVG image from a user and needs to store a BMP version in Azure Blob storage for downstream processing.
 * 2. When you must standardize vector graphics to a raster format before generating thumbnails or reports stored in cloud storage.
 * 3. When integrating Aspose.Imaging into an ASP.NET Core API to transform uploaded SVG files into BMP for compatibility with legacy systems.
 * 4. When automating the conversion of design assets to BMP for use in Windows applications while keeping the files centrally in Azure.
 * 5. When you want to ensure that SVG uploads are safely persisted as BMP files in Azure Blob to avoid client‑side rendering issues.
 */
