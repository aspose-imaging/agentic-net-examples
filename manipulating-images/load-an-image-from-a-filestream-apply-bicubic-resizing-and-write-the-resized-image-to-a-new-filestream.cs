// HOW-TO: Resize JPEG Image From FileStream and Save Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input\\image.jpg";
                string outputPath = "output\\resized.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                using (RasterImage image = (RasterImage)Image.Load(inputStream))
                {
                    int newWidth = 200;
                    int newHeight = 200;

                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        JpegOptions options = new JpegOptions();
                        image.Save(outputStream, options);
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
 * 1. When you need to generate thumbnail previews of user‑uploaded JPEG photos on a web server without loading the whole file into memory.
 * 2. When a desktop application must batch‑process images, reading each from a stream, resizing them to a fixed dimension, and writing the results to a new location.
 * 3. When an API receives image data as a stream, requires a specific width and height for downstream processing, and must return the resized JPEG as a stream.
 * 4. When you want to conserve disk space by creating smaller versions of large JPEG files before archiving or sending them over the network.
 * 5. When integrating Aspose.Imaging into a migration script that reads legacy image files, resizes them to a standard size, and saves them in a new folder structure.
 */
