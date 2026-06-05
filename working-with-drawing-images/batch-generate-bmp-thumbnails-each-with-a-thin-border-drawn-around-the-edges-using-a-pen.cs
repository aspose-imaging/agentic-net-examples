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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                        continue;
                    }

                    if (!raster.IsCached)
                        raster.CacheData();

                    // Create thumbnail with max dimension 150 pixels
                    int maxSize = 150;
                    double scale = Math.Min((double)maxSize / raster.Width, (double)maxSize / raster.Height);
                    int thumbWidth = (int)(raster.Width * scale);
                    int thumbHeight = (int)(raster.Height * scale);
                    raster.Resize(thumbWidth, thumbHeight);

                    // Draw thin black border
                    Graphics graphics = new Graphics(raster);
                    Pen pen = new Pen(Color.Black, 1);
                    graphics.DrawRectangle(pen, 0, 0, raster.Width - 1, raster.Height - 1);

                    // Prepare output path
                    string fileName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.bmp";
                    string outputPath = Path.Combine(outputDirectory, fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to create a gallery of small preview images for a web portal, generating BMP thumbnails with a uniform thin border drawn by a Pen to maintain visual consistency.
 * 2. When an e‑commerce site must display product photos as quick‑load thumbnails on mobile devices, resizing original images to 150 px and using a Pen to add a thin border for separation.
 * 3. When a desktop application processes scanned documents in various formats and requires batch conversion to BMP thumbnails with a Pen‑drawn border for inclusion in a PDF index.
 * 4. When a digital asset management system automatically creates low‑resolution previews of high‑resolution BMP files for faster browsing, adding a subtle Pen‑drawn border to highlight each thumbnail.
 * 5. When a reporting tool needs to embed small BMP images with a consistent frame into generated PDFs or Excel sheets, resizing and drawing a border with a Pen around each image in a batch operation.
 */