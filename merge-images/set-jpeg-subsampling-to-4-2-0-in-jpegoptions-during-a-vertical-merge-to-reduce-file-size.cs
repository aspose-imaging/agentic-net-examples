using System;
using System.IO;
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
            string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
            string outputPath = "output.jpg";

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int maxWidth = 0;
            int totalHeight = 0;
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    if (img.Width > maxWidth) maxWidth = img.Width;
                    totalHeight += img.Height;
                }
            }

            FileCreateSource source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = source,
                Quality = 90,
                ColorType = JpegCompressionColorMode.YCbCr,
                HorizontalSampling = new byte[] { 2, 1, 1 },
                VerticalSampling = new byte[] { 2, 1, 1 }
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, maxWidth, totalHeight))
            {
                int offsetY = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

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
 * 1. When a web application needs to generate a single JPEG photo strip from multiple user‑uploaded images while keeping the file size low, developers can use this code to vertically merge the pictures and apply 4:2:0 subsampling with Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform creates a product‑comparison image that stacks several product photos in a column, the code ensures the combined JPEG uses YCbCr color mode and reduced chroma resolution to optimize bandwidth.
 * 3. When a reporting tool assembles scanned invoice pages into one continuous JPEG document, the vertical merge with JpegOptions and 4:2:0 subsampling helps meet email attachment size limits.
 * 4. When a mobile game captures a sequence of in‑game screenshots and needs to bundle them into a single JPEG leaderboard image, this approach merges the frames vertically and compresses them efficiently for faster sharing.
 * 5. When a digital signage system prepares a tall banner by stitching together multiple advertisement banners, the code creates a high‑quality JPEG with reduced chroma data, minimizing storage while preserving visual fidelity.
 */