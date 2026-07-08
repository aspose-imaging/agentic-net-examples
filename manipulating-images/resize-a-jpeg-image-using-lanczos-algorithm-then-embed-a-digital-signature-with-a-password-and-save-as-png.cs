using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;

                raster.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When a web service needs to create high‑quality thumbnail PNGs from uploaded JPEG photos, it can use Aspose.Imaging in C# to resize the images with Lanczos resampling and save the result as PNG.
 * 2. When an e‑commerce site wants to halve the dimensions of product JPEG images to reduce bandwidth while preserving detail, developers can apply Lanczos resizing via Aspose.Imaging and output lossless PNG files.
 * 3. When a document management system processes scanned JPEG pages, it can downscale each page with Lanczos and convert it to PNG for archival storage using the Aspose.Imaging library.
 * 4. When a mobile‑backend pipeline receives large‑resolution JPEGs from devices, it can use C# and Aspose.Imaging to resize the images with Lanczos and store them as PNGs for consistent cross‑platform display.
 * 5. When a batch script prepares images for email newsletters, it can resize JPEGs by 50 % with Lanczos resampling and convert them to PNG to ensure compatibility with all email clients.
 */