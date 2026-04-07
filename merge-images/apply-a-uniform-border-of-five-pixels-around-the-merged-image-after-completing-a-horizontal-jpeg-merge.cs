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
        // Hardcoded input and output paths
        string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
        string outputPath = "merged_with_border.jpg";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas size for horizontal merge
        int mergedWidth = 0;
        int mergedHeight = 0;
        foreach (Size sz in sizes)
        {
            mergedWidth += sz.Width;
            if (sz.Height > mergedHeight) mergedHeight = sz.Height;
        }

        // Create JPEG canvas for merged image (bound to outputPath)
        JpegOptions mergeOptions = new JpegOptions
        {
            Source = new FileCreateSource(outputPath, false),
            Quality = 100
        };
        using (JpegImage mergeCanvas = (JpegImage)Image.Create(mergeOptions, mergedWidth, mergedHeight))
        {
            // Merge images horizontally
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    mergeCanvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Capture merged pixels before disposing the canvas
            int[] mergedPixels = mergeCanvas.LoadArgb32Pixels(mergeCanvas.Bounds);

            // Dispose mergeCanvas (exits using block)
            // Create final canvas with border (5 pixels on each side)
            int borderSize = 5;
            int finalWidth = mergedWidth + borderSize * 2;
            int finalHeight = mergedHeight + borderSize * 2;

            JpegOptions finalOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };
            using (JpegImage finalCanvas = (JpegImage)Image.Create(finalOptions, finalWidth, finalHeight))
            {
                // Fill background with white
                int totalPixels = finalWidth * finalHeight;
                int[] whitePixels = new int[totalPixels];
                int whiteArgb = Aspose.Imaging.Color.White.ToArgb();
                for (int i = 0; i < totalPixels; i++) whitePixels[i] = whiteArgb;
                finalCanvas.SaveArgb32Pixels(new Rectangle(0, 0, finalWidth, finalHeight), whitePixels);

                // Paste merged image onto the center (offset by borderSize)
                Rectangle destRect = new Rectangle(borderSize, borderSize, mergedWidth, mergedHeight);
                finalCanvas.SaveArgb32Pixels(destRect, mergedPixels);

                // Save final image (bound canvas)
                finalCanvas.Save();
            }
        }
    }
}