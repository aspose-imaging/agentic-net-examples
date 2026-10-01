// HOW-TO: Convert OTG Image To PNG From Memory Stream In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OtgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                byte[] fileBytes = File.ReadAllBytes(inputPath);
                using (MemoryStream memoryStream = new MemoryStream(fileBytes))
                {
                    using (Image image = Image.Load(memoryStream))
                    {
                        PngOptions pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display or edit an OTG graphic in a web application that only supports PNG, you can load the OTG file into a MemoryStream and convert it to PNG with Aspose.Imaging.
 * 2. When processing scanned documents stored as OTG files on a server, you can read the bytes, load them into memory, and save them as PNG for thumbnail generation or archival.
 * 3. When integrating a legacy OTG image format into a modern C# desktop tool, you can use a memory stream to avoid temporary files and directly save the image as PNG for UI rendering.
 * 4. When building an automated batch job that receives OTG files via API, you can convert each file from the incoming byte array to PNG without writing the original file to disk.
 * 5. When creating a cloud function that transforms uploaded OTG images into PNG for downstream image‑processing pipelines, loading the file into a MemoryStream and saving as PNG ensures fast, memory‑only conversion.
 */
