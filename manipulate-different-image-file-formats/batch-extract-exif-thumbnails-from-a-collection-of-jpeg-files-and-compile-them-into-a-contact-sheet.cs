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
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output contact sheet path
        string outputPath = @"C:\Images\contact_sheet.jpg";

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Collect thumbnails
        List<RasterImage> thumbnails = new List<RasterImage>();
        foreach (string path in inputPaths)
        {
            using (JpegImage jpeg = new JpegImage(path))
            {
                // ExifData may be null; Thumbnail may be null
                if (jpeg.ExifData != null && jpeg.ExifData.Thumbnail != null)
                {
                    // Thumbnail is a RasterImage; keep it for later merging
                    thumbnails.Add(jpeg.ExifData.Thumbnail);
                }
            }
        }

        if (thumbnails.Count == 0)
        {
            Console.Error.WriteLine("No EXIF thumbnails found.");
            return;
        }

        // Calculate canvas size (horizontal layout)
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (RasterImage thumb in thumbnails)
        {
            totalWidth += thumb.Width;
            if (thumb.Height > maxHeight)
                maxHeight = thumb.Height;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create JPEG canvas bound to output file
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = outputSource, Quality = 90 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (RasterImage thumb in thumbnails)
            {
                var bounds = new Rectangle(offsetX, 0, thumb.Width, thumb.Height);
                canvas.SaveArgb32Pixels(bounds, thumb.LoadArgb32Pixels(thumb.Bounds));
                offsetX += thumb.Width;
            }

            // Save the bound image
            canvas.Save();
        }

        // Dispose thumbnails
        foreach (RasterImage thumb in thumbnails)
        {
            thumb.Dispose();
        }
    }
}