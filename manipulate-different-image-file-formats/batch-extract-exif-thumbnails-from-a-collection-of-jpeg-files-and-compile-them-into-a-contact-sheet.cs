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
            // Hardcoded paths
            string inputDirectory = "Input";
            string outputPath = "Output/ContactSheet.jpg";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Get JPEG files
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (jpegFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Lists to hold thumbnail pixel data and sizes
            List<int[]> thumbnailPixels = new List<int[]>();
            List<Size> thumbnailSizes = new List<Size>();

            foreach (string filePath in jpegFiles)
            {
                // Validate each file
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                // Load JPEG image
                using (JpegImage jpeg = (JpegImage)Image.Load(filePath))
                {
                    // Extract EXIF thumbnail
                    RasterImage thumb = jpeg.ExifData?.Thumbnail as RasterImage;
                    if (thumb == null)
                    {
                        Console.Error.WriteLine($"No EXIF thumbnail in: {filePath}");
                        continue;
                    }

                    // Load pixel data
                    int[] pixels = thumb.LoadArgb32Pixels(thumb.Bounds);
                    thumbnailPixels.Add(pixels);
                    thumbnailSizes.Add(thumb.Size);
                }
            }

            if (thumbnailPixels.Count == 0)
            {
                Console.Error.WriteLine("No EXIF thumbnails were extracted.");
                return;
            }

            // Determine layout (5 columns)
            int columns = 5;
            int rows = (int)Math.Ceiling((double)thumbnailPixels.Count / columns);
            int maxWidth = thumbnailSizes.Max(s => s.Width);
            int maxHeight = thumbnailSizes.Max(s => s.Height);
            int canvasWidth = columns * maxWidth;
            int canvasHeight = rows * maxHeight;

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare output options
            FileCreateSource outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };

            // Create canvas and paste thumbnails
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                for (int i = 0; i < thumbnailPixels.Count; i++)
                {
                    int col = i % columns;
                    int row = i / columns;
                    int offsetX = col * maxWidth;
                    int offsetY = row * maxHeight;

                    Size sz = thumbnailSizes[i];
                    Rectangle destRect = new Rectangle(offsetX, offsetY, sz.Width, sz.Height);
                    canvas.SaveArgb32Pixels(destRect, thumbnailPixels[i]);
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
 * 1. When you need to generate a quick visual overview of hundreds of photos by extracting their embedded EXIF thumbnails and arranging them into a single contact sheet for review.
 * 2. When building a digital asset management tool that shows thumbnail previews without loading full‑size images, using the EXIF thumbnail extraction to improve performance.
 * 3. When creating a printable catalog of product images where only the small EXIF thumbnails are required to fit many items on one page.
 * 4. When developing a web service that validates image metadata and returns a composite thumbnail image for client‑side display.
 * 5. When automating a workflow that archives JPEG files and stores a compact contact sheet of their thumbnails for quick reference in archives or backups.
 */
