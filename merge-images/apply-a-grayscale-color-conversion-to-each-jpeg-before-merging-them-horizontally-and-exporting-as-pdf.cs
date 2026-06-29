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
            // Input and output directories
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

            // Collect sizes of grayscale JPEGs
            List<int> widths = new List<int>();
            List<int> heights = new List<int>();
            List<string> jpegPaths = new List<string>();

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load JPEG, convert to grayscale, and store temporary path
                string tempGrayPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + "_gray.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(tempGrayPath));

                using (JpegImage jpeg = (JpegImage)Image.Load(filePath))
                {
                    jpeg.Grayscale();
                    jpeg.Save(tempGrayPath);
                }

                using (JpegImage gray = (JpegImage)Image.Load(tempGrayPath))
                {
                    widths.Add(gray.Width);
                    heights.Add(gray.Height);
                }

                jpegPaths.Add(tempGrayPath);
            }

            if (jpegPaths.Count == 0)
            {
                Console.WriteLine("No images to process.");
                return;
            }

            int totalWidth = widths.Sum();
            int maxHeight = heights.Max();

            // Create final merged JPEG
            string finalPath = Path.Combine(outputDirectory, "merged.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(finalPath));
            Source finalSource = new FileCreateSource(finalPath, false);
            JpegOptions finalOptions = new JpegOptions() { Source = finalSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(finalOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string grayPath in jpegPaths)
                {
                    using (JpegImage img = (JpegImage)Image.Load(grayPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
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
 * 1. When a developer needs to generate a printable PDF catalog of product photos where all JPEG images are converted to grayscale and merged horizontally for consistent branding.
 * 2. When an archival system requires converting scanned color JPEG documents to grayscale and concatenating them side‑by‑side into a single PDF to save storage space.
 * 3. When a web application creates a before‑and‑after comparison PDF by turning each JPEG into grayscale and stitching them horizontally for easy visual analysis.
 * 4. When an e‑learning platform prepares study material by merging multiple grayscale JPEG diagrams into a single PDF page to simplify distribution.
 * 5. When a legal compliance tool must produce a PDF report that includes grayscale versions of evidence JPEGs arranged horizontally to meet document formatting standards.
 */