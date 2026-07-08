using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = "Input";
            string outputPath = "Output/contact_sheet.png";

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect JPEG files
            var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToList();

            // List to hold thumbnails
            List<RasterImage> thumbnails = new List<RasterImage>();

            // Load each JPEG and extract thumbnail
            foreach (var filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage jpegImage = (JpegImage)Image.Load(filePath))
                {
                    var thumb = jpegImage.ExifData?.Thumbnail;
                    if (thumb != null)
                    {
                        thumbnails.Add((RasterImage)thumb);
                    }
                }
            }

            if (thumbnails.Count == 0)
            {
                Console.WriteLine("No EXIF thumbnails found.");
                return;
            }

            // Calculate canvas size (horizontal layout)
            int totalWidth = thumbnails.Sum(t => t.Width);
            int maxHeight = thumbnails.Max(t => t.Height);

            // Create PNG canvas bound to output file
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (var thumb in thumbnails)
                {
                    int[] pixels = thumb.LoadArgb32Pixels(thumb.Bounds);
                    var destRect = new Rectangle(offsetX, 0, thumb.Width, thumb.Height);
                    canvas.SaveArgb32Pixels(destRect, pixels);
                    offsetX += thumb.Width;
                }

                // Save bound image
                canvas.Save();
            }

            // Dispose thumbnails
            foreach (var thumb in thumbnails)
            {
                thumb.Dispose();
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
 * 1. When a photographer wants to quickly generate a preview contact sheet of all EXIF thumbnails embedded in a folder of JPEG images for client review.
 * 2. When an e‑commerce platform needs to extract low‑resolution thumbnails from product photos stored as JPEGs and combine them into a single PNG catalog page.
 * 3. When a digital asset management system must batch process uploaded JPEG files to create a visual index using the embedded EXIF thumbnails without loading full‑size images.
 * 4. When a mobile app backend wants to assemble a lightweight contact sheet of user‑uploaded JPEG thumbnails for faster gallery loading on low‑bandwidth connections.
 * 5. When a forensic analyst requires an automated way to collect and display EXIF thumbnail data from a collection of suspect JPEG files in a single PNG contact sheet for quick visual inspection.
 */