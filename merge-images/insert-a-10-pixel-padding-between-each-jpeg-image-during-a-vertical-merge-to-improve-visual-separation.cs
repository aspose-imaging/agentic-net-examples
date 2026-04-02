using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string[] inputPaths = new string[]
        {
            @"C:\temp\img1.jpg",
            @"C:\temp\img2.jpg",
            @"C:\temp\img3.jpg"
        };
        string outputPath = @"C:\temp\merged.jpg";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load all JPEG images
        List<Image> sourceImages = new List<Image>();
        foreach (string inputPath in inputPaths)
        {
            // Load using the Image.Load method (JpegImage can also be used)
            Image img = Image.Load(inputPath);
            sourceImages.Add(img);
        }

        // Determine dimensions for the merged image
        int maxWidth = 0;
        int totalHeight = 0;
        const int padding = 10; // 10‑pixel padding between images

        foreach (Image img in sourceImages)
        {
            if (img.Width > maxWidth)
                maxWidth = img.Width;
            totalHeight += img.Height;
        }
        // Add padding between images (no padding after the last one)
        totalHeight += padding * (sourceImages.Count - 1);

        // Create a blank raster image to hold the result
        BmpOptions bmpOptions = new BmpOptions();
        // Use a temporary file source; the file will be overwritten when we save as JPEG
        bmpOptions.Source = new FileCreateSource(Path.GetTempFileName(), false);
        using (Image resultImage = Image.Create(bmpOptions, maxWidth, totalHeight))
        {
            // Draw each source image onto the result image with padding
            Graphics graphics = new Graphics(resultImage);
            int currentY = 0;
            foreach (Image src in sourceImages)
            {
                graphics.DrawImage(src, new Rectangle(0, currentY, src.Width, src.Height));
                currentY += src.Height + padding;
            }

            // Save the merged image as JPEG
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 100
            };
            resultImage.Save(outputPath, jpegOptions);
        }

        // Dispose source images
        foreach (Image img in sourceImages)
        {
            img.Dispose();
        }
    }
}