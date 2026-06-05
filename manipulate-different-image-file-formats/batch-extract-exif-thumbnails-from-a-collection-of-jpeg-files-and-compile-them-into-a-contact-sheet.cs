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
            // Hardcoded input and output paths
            string inputDirectory = "Input";
            string outputPath = "Output/contact_sheet.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // First pass: collect thumbnail sizes
            var thumbSizes = new List<(string FilePath, int Width, int Height)>();

            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage jpeg = (JpegImage)Image.Load(filePath))
                {
                    var thumb = jpeg.ExifData?.Thumbnail;
                    if (thumb != null)
                    {
                        thumbSizes.Add((filePath, thumb.Width, thumb.Height));
                    }
                }
            }

            if (thumbSizes.Count == 0)
            {
                Console.WriteLine("No EXIF thumbnails found in the JPEG files.");
                return;
            }

            // Calculate canvas dimensions (horizontal layout)
            int canvasWidth = thumbSizes.Sum(t => t.Width);
            int canvasHeight = thumbSizes.Max(t => t.Height);

            // Create PNG canvas
            Source outputSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions { Source = outputSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (var (filePath, width, height) in thumbSizes)
                {
                    using (JpegImage jpeg = (JpegImage)Image.Load(filePath))
                    {
                        var thumb = jpeg.ExifData?.Thumbnail;
                        if (thumb != null)
                        {
                            // Copy thumbnail pixels onto the canvas
                            var bounds = new Rectangle(offsetX, 0, thumb.Width, thumb.Height);
                            canvas.SaveArgb32Pixels(bounds, thumb.LoadArgb32Pixels(thumb.Bounds));
                            offsetX += thumb.Width;
                        }
                    }
                }

                // Save the contact sheet
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
 * 1. When a photographer wants to quickly preview the embedded EXIF thumbnails of a batch of JPEG images as a single PNG contact sheet for client review.
 * 2. When a digital asset management system needs to generate a lightweight overview of thousands of uploaded photos without loading full‑resolution images.
 * 3. When a web application must display a collage of product image previews extracted from EXIF data to reduce bandwidth usage.
 * 4. When an e‑commerce platform wants to verify that uploaded JPEG files contain proper EXIF thumbnails and present them in a grid for quality control.
 * 5. When a mobile app developer needs to create a printable contact sheet of camera‑generated thumbnails for archival documentation.
 */