// HOW-TO: Load JPEG2000 Image With 4 MB Buffer And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.jp2";
        string outputPath = @"C:\temp\sample.output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up JPEG2000 load options with a 4 MB buffer size hint
            var loadOptions = new Jpeg2000LoadOptions
            {
                BufferSizeHint = 4 // Buffer size in megabytes
            };

            // Load the JPEG2000 image using the custom load options
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Save the image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When processing large JPEG2000 files on a memory‑constrained server, you can limit RAM usage by setting a 4 MB buffer before converting to PNG.
 * 2. When building a desktop utility that batch‑converts high‑resolution JP2 images to PNG while preventing out‑of‑memory crashes, this code provides a safe load option.
 * 3. When integrating image conversion into a cloud function that has strict memory quotas, the buffer size hint ensures the function stays within limits.
 * 4. When developing a medical imaging viewer that reads JP2 scans and needs to display them as PNG thumbnails, controlling the buffer helps maintain responsive performance.
 * 5. When creating an automated pipeline that extracts JPEG2000 assets from archives and saves them as PNG for downstream processing, the custom buffer reduces peak memory consumption.
 */
