// HOW-TO: Create a Contact Sheet from EXIF Thumbnails of Multiple JPEGs in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input directory and output file path
            string inputDirectory = "Input";
            string outputPath = "Output/contact_sheet.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files from the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            jpegFiles = jpegFiles.Concat(Directory.GetFiles(inputDirectory, "*.jpeg")).ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // First pass: collect thumbnail sizes
            List<Aspose.Imaging.Size> thumbSizes = new List<Aspose.Imaging.Size>();
            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage jpeg = (JpegImage)Image.Load(filePath))
                {
                    var exif = jpeg.ExifData;
                    if (exif != null && exif.Thumbnail != null)
                    {
                        using (RasterImage thumb = exif.Thumbnail)
                        {
                            thumbSizes.Add(thumb.Size);
                        }
                    }
                }
            }

            if (thumbSizes.Count == 0)
            {
                Console.WriteLine("No EXIF thumbnails found in the JPEG files.");
                return;
            }

            // Calculate canvas dimensions (horizontal layout)
            int canvasWidth = thumbSizes.Sum(s => s.Width);
            int canvasHeight = thumbSizes.Max(s => s.Height);

            // Prepare JPEG options for the output image
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 90
            };

            // Create the canvas image bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;

                // Second pass: load thumbnails again and merge onto the canvas
                foreach (string filePath in jpegFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (JpegImage jpeg = (JpegImage)Image.Load(filePath))
                    {
                        var exif = jpeg.ExifData;
                        if (exif != null && exif.Thumbnail != null)
                        {
                            using (RasterImage thumb = exif.Thumbnail)
                            {
                                Rectangle bounds = new Rectangle(offsetX, 0, thumb.Width, thumb.Height);
                                canvas.SaveArgb32Pixels(bounds, thumb.LoadArgb32Pixels(thumb.Bounds));
                                offsetX += thumb.Width;
                            }
                        }
                    }
                }

                // Save the bound canvas image
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
 * 1. When you need to quickly generate a preview grid of photos by extracting embedded EXIF thumbnails from a folder of JPEG images.
 * 2. When you want to create a lightweight contact sheet for a client without loading full‑resolution images, saving memory and processing time.
 * 3. When building a digital asset management tool that shows thumbnail overviews of uploaded JPEGs by reading their EXIF thumbnail data.
 * 4. When automating a report that includes a collage of camera‑taken pictures, using the stored thumbnails to keep the file size small.
 * 5. When developing a batch script to verify that all JPEG files contain EXIF thumbnails and to visualize them in a single composite image.
 */
