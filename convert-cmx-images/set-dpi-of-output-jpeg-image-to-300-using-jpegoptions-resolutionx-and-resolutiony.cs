// HOW-TO: Set JPEG Image DPI to 300 Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.jpg";
        string outputPath = "Output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions options = new JpegOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };
                image.Save(outputPath, options);
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
 * 1. When preparing photos for high‑quality print, a developer can set the JPEG DPI to 300 to ensure the printer receives the correct resolution.
 * 2. When converting scanned documents to JPEG for archival, adjusting the DPI guarantees consistent sizing across different viewing platforms.
 * 3. When generating thumbnails for a web gallery that must retain print‑ready dimensions, setting the output resolution with Aspose.Imaging preserves aspect and size.
 * 4. When integrating a C# application with a publishing workflow, specifying 300 DPI in the JPEG output meets the specifications of many publishing standards.
 * 5. When automating batch processing of images for a marketing campaign, using JpegOptions.ResolutionSettings standardizes the DPI across all files for uniform printing results.
 */
