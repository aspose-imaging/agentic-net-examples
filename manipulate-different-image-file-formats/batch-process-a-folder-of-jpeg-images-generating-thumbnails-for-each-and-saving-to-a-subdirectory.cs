using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");
            string thumbDir = Path.Combine(outputDir, "Thumbnails");

            // Ensure input and output directories exist
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(thumbDir);

            string[] files = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(thumbDir, fileName + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached) image.CacheData();

                    // Create thumbnail preserving aspect ratio, max dimension 150
                    const int maxSize = 150;
                    int width = image.Width;
                    int height = image.Height;
                    double ratio = (double)width / height;
                    int thumbWidth, thumbHeight;

                    if (width >= height)
                    {
                        thumbWidth = maxSize;
                        thumbHeight = (int)(maxSize / ratio);
                    }
                    else
                    {
                        thumbHeight = maxSize;
                        thumbWidth = (int)(maxSize * ratio);
                    }

                    image.Resize(thumbWidth, thumbHeight);

                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        jpegOptions.Quality = 90;
                        image.Save(outputPath, jpegOptions);
                    }
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
 * 1. When a developer needs to generate web‑ready thumbnail previews for a large batch of JPEG or JPEG‑2000 photos stored in a folder, this C# Aspose.Imaging code creates 150‑pixel thumbnails while preserving aspect ratio and saves them to an Output/Thumbnails subdirectory.
 * 2. When an e‑commerce platform must display product image previews on category pages, the code can batch‑process the original high‑resolution JPEG assets and produce uniformly sized thumbnails for faster page loads.
 * 3. When a content management system imports user‑uploaded JPEG images and requires low‑resolution preview files for the admin dashboard, this snippet automates the thumbnail creation and organizes them in a dedicated folder.
 * 4. When a digital asset management tool needs to sync a local photo archive with a cloud service that only accepts small thumbnail files, the program quickly converts each JPEG in the Input folder to a cached RasterImage and writes the scaled‑down versions to Output/Thumbnails.
 * 5. When a Windows desktop application must display a scrollable gallery of images from a directory, the code can pre‑generate the required JPEG thumbnails to improve UI responsiveness and reduce memory usage.
 */