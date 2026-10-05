// HOW-TO: Merge Multiple JPEG Images Horizontally While Preserving EXIF Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string[] inputFiles = new string[]
            {
                "Input/image1.jpg",
                "Input/image2.jpg",
                "Input/image3.jpg"
            };
            string outputPath = "Output/merged.jpg";

            // Validate input files
            foreach (string path in inputFiles)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal merge)
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (var sz in sizes)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight) maxHeight = sz.Height;
            }

            // Create output JPEG canvas
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                // Preserve EXIF from the first image
                Aspose.Imaging.Exif.JpegExifData exifData = null;

                int offsetX = 0;
                foreach (string path in inputFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Capture EXIF from the first JPEG image
                        if (exifData == null && img is JpegImage firstJpeg)
                        {
                            exifData = firstJpeg.ExifData;
                        }

                        // Copy pixels onto canvas
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Assign captured EXIF data to the merged image
                if (exifData != null)
                {
                    canvas.ExifData = exifData;
                }

                // Save the merged image (bound to output source)
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
 * 1. When you need to create a panoramic view by stitching several JPEG photos side‑by‑side but must keep the original camera information for the combined image.
 * 2. When an e‑commerce platform wants to display product variants in a single image while retaining the first photo’s EXIF data for SEO and analytics.
 * 3. When a digital asset management system merges scanned documents saved as JPEGs into one file and needs to preserve the original metadata for compliance.
 * 4. When a mobile app generates a collage of user‑taken pictures and must retain orientation and GPS tags from the first picture for later processing.
 * 5. When a reporting tool combines chart screenshots into a single JPEG report and wants to keep the source image’s EXIF metadata for traceability.
 */
