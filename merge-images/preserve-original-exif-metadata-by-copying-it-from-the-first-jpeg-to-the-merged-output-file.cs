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
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };
            string outputPath = "merged.jpg";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Collect image sizes and preserve EXIF from the first image
            List<Size> sizes = new List<Size>();
            Aspose.Imaging.Exif.ExifData firstExifData = null;

            // Load first image to capture EXIF and size
            using (RasterImage firstImg = (RasterImage)Image.Load(inputPaths[0]))
            {
                sizes.Add(firstImg.Size);
                firstExifData = firstImg.ExifData;
            }

            // Load remaining images to collect sizes
            for (int i = 1; i < inputPaths.Length; i++)
            {
                using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Prepare JPEG options with bound output source
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            // Create JPEG canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Copy EXIF metadata from the first image if it is JPEG EXIF
                if (firstExifData is Aspose.Imaging.Exif.JpegExifData jpegExif)
                {
                    canvas.ExifData = jpegExif;
                }

                // Merge images horizontally
                int offsetX = 0;
                foreach (string imgPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(imgPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (output file already bound via options)
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
 * 1. When a photographer needs to stitch several JPEG photos into a single panoramic image while retaining the original camera settings and GPS coordinates stored in the first photo’s EXIF metadata.
 * 2. When an e‑commerce platform merges product view images into a composite thumbnail and must preserve the original exposure and orientation data for compliance with image‑catalog standards.
 * 3. When a real‑estate agency combines interior room photos into a brochure layout and wants to keep the first image’s EXIF timestamps for accurate property listing timelines.
 * 4. When a social‑media app creates a collage from user‑uploaded JPEGs and needs to retain the first picture’s copyright and author information embedded in EXIF for legal attribution.
 * 5. When a medical imaging system assembles multiple diagnostic JPEG scans into a single report page while preserving the first scan’s patient metadata stored in EXIF tags.
 */