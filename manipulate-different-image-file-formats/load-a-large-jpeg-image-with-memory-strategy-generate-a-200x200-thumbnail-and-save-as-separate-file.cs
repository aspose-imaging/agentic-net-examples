// HOW-TO: Create 200x200 JPEG Thumbnail from Large Image with Memory Buffer in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "large.jpg";
            string outputPath = "thumbnail.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG with memory limit (buffer size hint in MB)
            using (Image image = Image.Load(inputPath, new LoadOptions { BufferSizeHint = 50 }))
            {
                if (image is RasterImage raster)
                {
                    // Resize to 200x200 thumbnail using nearest-neighbour resampling
                    raster.Resize(200, 200, ResizeType.NearestNeighbourResample);
                    // Save thumbnail
                    raster.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When you need to generate a small preview of a high‑resolution JPEG for a web gallery while limiting RAM usage.
 * 2. When an application must create consistent 200 × 200 thumbnails for user‑uploaded photos on a server with constrained memory.
 * 3. When processing large raster images in a batch job and you want to ensure each thumbnail is saved as a separate JPEG file.
 * 4. When you want to use Aspose.Imaging’s BufferSizeHint to prevent out‑of‑memory exceptions while resizing images in C#.
 * 5. When integrating image handling into a desktop tool that validates file existence and automatically creates the output folder for thumbnails.
 */
