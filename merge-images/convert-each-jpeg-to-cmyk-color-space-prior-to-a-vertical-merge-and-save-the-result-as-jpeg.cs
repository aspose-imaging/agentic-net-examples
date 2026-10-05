// HOW-TO: Convert JPEG Images to CMYK and Merge Vertically in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            string inputDirectory = "Input";
            string outputPath = Path.Combine("Output", "merged.jpg");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in input directory.");
                return;
            }

            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(filePath))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int canvasWidth = widths.Max();
            int canvasHeight = heights.Sum();

            FileCreateSource source = new FileCreateSource(outputPath, false);
            using (JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 })
            {
                using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
                {
                    int offsetY = 0;
                    foreach (string filePath in files)
                    {
                        using (JpegImage img = (JpegImage)Image.Load(filePath))
                        {
                            Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetY += img.Height;
                        }
                    }
                    canvas.Save();
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
 * 1. When preparing product photos for high‑resolution print catalogs, a developer can convert the JPEGs to CMYK and stack them vertically to create a single printable image.
 * 2. When generating a continuous strip of scanned receipts for archival, the code ensures each JPEG is in CMYK color space and merges them into one file for easier storage.
 * 3. When building a web service that returns a combined image of multiple advertisements, converting each JPEG to CMYK maintains color consistency before vertically concatenating them.
 * 4. When creating a printable banner from separate JPEG panels, the developer can use this code to convert each panel to CMYK and merge them into a single high‑quality JPEG.
 * 5. When automating the preparation of proof sheets for a printing press, the script converts source JPEGs to CMYK and stacks them vertically to match the press’s layout requirements.
 */
