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
            // Hardcoded input JPEG paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Validate each input file
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Generate output filename with timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string baseName = Path.GetFileNameWithoutExtension(inputPaths[0]);
            string outputPath = $"{baseName}_{timestamp}.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create JPEG canvas
            Source src = new FileCreateSource(outputPath, false);
            JpegOptions options = new JpegOptions() { Source = src, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image (bound image saves to the source path)
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
 * 1. When a developer needs to automatically combine product photos into a single horizontal strip for an e‑commerce catalog and keep each version uniquely identified by a timestamped JPEG filename.
 * 2. When a batch‑processing script must merge scanned receipts into one image per day and generate output files with date‑time stamps to avoid overwriting previous results.
 * 3. When a photo‑sharing application creates a side‑by‑side comparison of before‑and‑after images and stores the merged JPEG with a timestamp to track version history.
 * 4. When an automated reporting tool assembles multiple chart images into a single wide JPEG for inclusion in a PDF report and uses a timestamped filename for easy archival.
 * 5. When a digital signage system concatenates several advertisement banners into one horizontal JPEG and names the output with a timestamp to ensure the latest content is displayed without manual renaming.
 */