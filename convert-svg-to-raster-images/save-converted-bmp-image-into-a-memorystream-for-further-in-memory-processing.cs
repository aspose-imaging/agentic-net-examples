// HOW-TO: Convert WebP to BMP and Store in MemoryStream Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.webp";
            string outputPath = "output\\output.bmp";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WebP image
            using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
            {
                // Convert to BMP and save to MemoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BmpOptions bmpOptions = new BmpOptions();
                    webpImage.Save(memoryStream, bmpOptions);

                    // Example: write the BMP from memory to a file
                    memoryStream.Position = 0;
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(fileStream);
                    }

                    // At this point, memoryStream contains the BMP data for further in‑memory processing
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
 * 1. When you need to convert uploaded WebP images to BMP format for a legacy Windows application without writing temporary files to disk.
 * 2. When you want to process the BMP data in‑memory (e.g., apply filters or embed into a PDF) before saving or transmitting it.
 * 3. When you are building a web service that receives WebP payloads and must return BMP streams to client browsers that only support BMP.
 * 4. When you need to batch‑convert a folder of WebP files to BMP while keeping the intermediate results in memory to improve performance.
 * 5. When you are integrating Aspose.Imaging into a cloud function where disk I/O is restricted, so you store the converted BMP in a MemoryStream for further manipulation.
 */
