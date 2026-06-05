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
        try
        {
            // Hardcoded input JPEG files
            string[] inputPaths = {
                @"C:\temp\img1.jpg",
                @"C:\temp\img2.jpg",
                @"C:\temp\img3.jpg"
            };

            // Hardcoded output PNG file
            string outputPath = @"C:\temp\merged.png";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load JPEG images
            List<Image> sourceImages = new List<Image>();
            foreach (string inputPath in inputPaths)
            {
                // Using JpegImage constructor to load the file
                Image img = new JpegImage(inputPath);
                sourceImages.Add(img);
            }

            // Determine dimensions for the final composition
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Image img in sourceImages)
            {
                totalWidth += img.Width;
                if (img.Height > maxHeight)
                    maxHeight = img.Height;
            }

            // Create a new PNG image with the calculated size
            PngOptions pngOptions = new PngOptions();
            // The source is required for the Create method; we use a temporary create source.
            pngOptions.Source = new FileCreateSource(outputPath, false);
            using (Image resultImage = Image.Create(pngOptions, totalWidth, maxHeight))
            {
                // Draw each source image onto the result image side by side
                Graphics graphics = new Graphics(resultImage);
                int offsetX = 0;
                foreach (Image src in sourceImages)
                {
                    graphics.DrawImage(src, new Rectangle(offsetX, 0, src.Width, src.Height));
                    offsetX += src.Width;
                }

                // Ensure the output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the composed image as PNG
                resultImage.Save(outputPath, new PngOptions());
            }

            // Dispose source images
            foreach (Image img in sourceImages)
            {
                img.Dispose();
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
 * 1. When a developer needs to create a product catalog thumbnail that combines several JPEG photos side by side and saves the result as a lossless PNG for web display.
 * 2. When an e‑commerce platform wants to generate a combined promotional banner by stitching multiple JPEG advertisements together and exporting the composite as a PNG for email campaigns.
 * 3. When a photo‑management application must present a before‑and‑after comparison by aligning two JPEG images horizontally and saving the merged image as a PNG to preserve transparency.
 * 4. When a reporting tool has to embed a series of JPEG charts side by side into a single PNG summary that can be inserted into PDF or PowerPoint reports.
 * 5. When a mobile app backend needs to merge user‑uploaded JPEG screenshots into one PNG image for efficient storage and quick preview in a gallery view.
 */