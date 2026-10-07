// HOW-TO: Merge Multiple JPEG Images Horizontally and Vertically with Timestamped Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] jpgFiles = Directory.GetFiles(inputFolder, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputFolder, "*.jpeg");
            List<string> imageFiles = new List<string>();
            imageFiles.AddRange(jpgFiles);
            imageFiles.AddRange(jpegFiles);

            if (imageFiles.Count == 0)
            {
                Console.WriteLine("No JPEG images found in the input directory.");
                return;
            }

            List<Size> sizes = new List<Size>();
            foreach (string filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Horizontal merge
            int horizWidth = sizes.Sum(s => s.Width);
            int horizHeight = sizes.Max(s => s.Height);
            string horizBaseName = Path.GetFileNameWithoutExtension(imageFiles[0]);
            string horizTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string horizOutputPath = Path.Combine(outputFolder, $"{horizBaseName}_{horizTimestamp}.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(horizOutputPath));

            Source horizSource = new FileCreateSource(horizOutputPath, false);
            JpegOptions horizOptions = new JpegOptions() { Source = horizSource, Quality = 100 };

            using (JpegImage horizCanvas = (JpegImage)Image.Create(horizOptions, horizWidth, horizHeight))
            {
                int offsetX = 0;
                foreach (string filePath in imageFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(filePath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        horizCanvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                horizCanvas.Save();
            }

            // Vertical merge
            int vertWidth = sizes.Max(s => s.Width);
            int vertHeight = sizes.Sum(s => s.Height);
            string vertBaseName = Path.GetFileNameWithoutExtension(imageFiles[0]);
            string vertTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string vertOutputPath = Path.Combine(outputFolder, $"{vertBaseName}_v_{vertTimestamp}.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(vertOutputPath));

            Source vertSource = new FileCreateSource(vertOutputPath, false);
            JpegOptions vertOptions = new JpegOptions() { Source = vertSource, Quality = 100 };

            using (JpegImage vertCanvas = (JpegImage)Image.Create(vertOptions, vertWidth, vertHeight))
            {
                int offsetY = 0;
                foreach (string filePath in imageFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(filePath))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        vertCanvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }
                vertCanvas.Save();
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
 * 1. When you need to combine a series of product photos into a single panoramic JPEG for a web catalog while preserving the original image quality.
 * 2. When you want to generate a composite image of scanned receipts for batch processing and include a unique timestamp in the filename to avoid overwriting.
 * 3. When an automated reporting system must stitch together daily camera snapshots into one image and store it with a date‑time suffix for archival.
 * 4. When a desktop application creates side‑by‑side before‑and‑after comparisons of JPEG files and needs distinct output names for each comparison.
 * 5. When a batch script processes user‑uploaded JPEGs, merges them into a single image, and saves the result with a timestamp to ensure traceability in audit logs.
 */
