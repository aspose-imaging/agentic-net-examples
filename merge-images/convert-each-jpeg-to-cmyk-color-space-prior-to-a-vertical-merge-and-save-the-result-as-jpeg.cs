// HOW-TO: Convert JPEG Images To CMYK And Vertically Merge In C# (Aspose.Imaging for .NET)
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
            List<string> jpegFiles = files
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (jpegFiles.Count == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            List<RasterImage> cmykImages = new List<RasterImage>();

            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage jpeg = (JpegImage)Image.Load(filePath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        JpegOptions cmykOptions = new JpegOptions
                        {
                            ColorType = JpegCompressionColorMode.Cmyk,
                            Source = new StreamSource(ms, false)
                        };
                        jpeg.Save(ms, cmykOptions);
                        ms.Position = 0;
                        RasterImage cmykImg = (RasterImage)Image.Load(ms);
                        cmykImages.Add(cmykImg);
                    }
                }
            }

            int totalHeight = cmykImages.Sum(img => img.Height);
            int maxWidth = cmykImages.Max(img => img.Width);

            string outputPath = Path.Combine(outputDirectory, "merged_cmyk.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            JpegOptions outOptions = new JpegOptions
            {
                ColorType = JpegCompressionColorMode.Cmyk,
                Quality = 100,
                Source = new FileCreateSource(outputPath, false)
            };

            using (JpegImage canvas = (JpegImage)Image.Create(outOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (RasterImage img in cmykImages)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                    img.Dispose();
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
 * 1. When you need to prepare a set of JPEG photos for high‑quality CMYK printing and combine them into a single tall image using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must generate a continuous product‑catalog banner from individual JPEG thumbnails, converting each to CMYK to match the printer’s color profile.
 * 3. When a digital publishing workflow requires merging scanned JPEG pages vertically while ensuring the final PDF‑ready image uses the CMYK color space.
 * 4. When a marketing automation script has to batch‑process JPEG ads, convert them to CMYK for consistent brand colors, and stack them for a vertical slideshow.
 * 5. When a desktop application needs to combine multiple JPEG screenshots into one CMYK image for archival printing without losing color fidelity.
 */
