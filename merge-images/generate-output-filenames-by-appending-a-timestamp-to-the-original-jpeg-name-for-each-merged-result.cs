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
            // Hardcoded input JPEG files
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string inputPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Generate output filename with timestamp
            string firstNameWithoutExt = Path.GetFileNameWithoutExtension(inputPaths[0]);
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string outputFileName = $"{firstNameWithoutExt}_{timestamp}.jpg";
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPaths[0]) ?? "", outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG canvas bound to the output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image
                canvas.Save();
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
 * 1. When a developer needs to create a time‑stamped composite JPEG of product photos for daily inventory reports.
 * 2. When an automated image‑processing pipeline must merge user‑uploaded screenshots and store each result with a unique filename to avoid overwriting previous builds.
 * 3. When a web service generates side‑by‑side before‑and‑after medical images and requires the output file name to include the exact processing time for audit trails.
 * 4. When a desktop application combines multiple scanned documents into a single JPEG and uses a timestamped name to keep a chronological archive of merged files.
 * 5. When a scheduled batch job concatenates security camera snapshots and saves the merged image with a timestamp to simplify log correlation and retrieval.
 */