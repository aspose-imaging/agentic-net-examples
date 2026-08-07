using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\large.jpg";
            string outputPath = "output\\thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG with memory limit
            using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 50 }))
            {
                // Resize to 200x200 thumbnail
                image.Resize(200, 200, ResizeType.NearestNeighbourResample);

                // Save thumbnail as JPEG
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to generate small preview images from large JPEG photos without exhausting server memory, a developer can use this code to load the image with a buffer size hint, resize it to 200 × 200, and save the thumbnail as a separate JPEG file.
 * 2. When an e‑commerce platform must create product thumbnail images on the fly from high‑resolution JPEG uploads while keeping the process lightweight, this C# snippet demonstrates how to limit memory usage and output a 90‑quality thumbnail.
 * 3. When a desktop utility processes user‑selected photos and needs to store low‑resolution versions for quick browsing, the code shows how to verify file existence, create the output folder, and produce a 200 × 200 JPEG thumbnail using Aspose.Imaging.
 * 4. When a batch‑processing service runs nightly to prepare image galleries and wants to avoid out‑of‑memory crashes on large JPEG files, the example illustrates using LoadOptions.BufferSizeHint and ResizeType.NearestNeighbourResample to safely generate thumbnails.
 * 5. When a mobile backend service receives large JPEG uploads and must return a small preview for API responses, this C# example provides a straightforward way to load the image with a memory limit, resize it, and save the thumbnail with configurable quality.
 */