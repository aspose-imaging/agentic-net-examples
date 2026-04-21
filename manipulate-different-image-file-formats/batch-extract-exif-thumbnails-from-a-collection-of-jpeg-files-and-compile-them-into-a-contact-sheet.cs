using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputPath = "Output\\contact_sheet.jpg";

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect JPEG file paths
        string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
            .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
            .ToArray();

        if (jpegFiles.Length == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        // First pass: determine total canvas size based on thumbnails
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
                if (exif?.Thumbnail != null)
                {
                    var thumb = (RasterImage)exif.Thumbnail;
                    thumbSizes.Add(new Aspose.Imaging.Size(thumb.Width, thumb.Height));
                }
            }
        }

        if (thumbSizes.Count == 0)
        {
            Console.WriteLine("No EXIF thumbnails found in the JPEG files.");
            return;
        }

        int totalWidth = thumbSizes.Sum(s => s.Width);
        int maxHeight = thumbSizes.Max(s => s.Height);

        // Create JPEG canvas with calculated size
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            int thumbIndex = 0;

            // Second pass: load thumbnails again and paste onto canvas
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
                    if (exif?.Thumbnail != null)
                    {
                        var thumb = (RasterImage)exif.Thumbnail;
                        var size = thumbSizes[thumbIndex];

                        Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(offsetX, 0, size.Width, size.Height);
                        canvas.SaveArgb32Pixels(destRect, thumb.LoadArgb32Pixels(thumb.Bounds));

                        offsetX += size.Width;
                        thumbIndex++;
                    }
                }
            }

            // Save the bound canvas
            canvas.Save();
        }

        Console.WriteLine($"Contact sheet created at: {outputPath}");
    }
}