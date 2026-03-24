using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[]
        {
            @"C:\temp\img1.jpg",
            @"C:\temp\img2.jpg",
            @"C:\temp\img3.jpg"
        };
        string outputPath = @"C:\temp\combined.jpg";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load all JPEG images
        List<JpegImage> loadedImages = new List<JpegImage>();
        foreach (string inputPath in inputPaths)
        {
            // Load image using the JpegImage constructor
            JpegImage img = new JpegImage(inputPath);
            loadedImages.Add(img);
        }

        // Determine the dimensions of the combined image
        int maxWidth = loadedImages.Max(img => img.Width);
        int totalHeight = loadedImages.Sum(img => img.Height);

        // Prepare JPEG save options (maintain high quality)
        JpegOptions jpegOptions = new JpegOptions
        {
            Quality = 100
        };

        // Create a new blank JPEG image with the calculated size
        using (JpegImage combinedImage = new JpegImage(jpegOptions, maxWidth, totalHeight))
        {
            // Graphics object for drawing onto the combined image
            Graphics graphics = new Graphics(combinedImage);

            int currentY = 0;
            foreach (JpegImage img in loadedImages)
            {
                // Draw each image at the current vertical offset
                graphics.DrawImage(
                    img,
                    new Aspose.Imaging.Rectangle(0, currentY, img.Width, img.Height));

                currentY += img.Height;
            }

            // Save the combined image to the output path
            combinedImage.Save(outputPath, jpegOptions);
        }

        // Dispose loaded source images
        foreach (JpegImage img in loadedImages)
        {
            img.Dispose();
        }
    }
}