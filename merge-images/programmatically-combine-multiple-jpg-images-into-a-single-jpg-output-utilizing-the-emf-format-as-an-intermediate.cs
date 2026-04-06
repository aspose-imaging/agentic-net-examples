using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Input JPG files (hard‑coded)
        string[] inputPaths = new[] { "input1.jpg", "input2.jpg", "input3.jpg" };
        // Final output JPG file (hard‑coded)
        string outputPath = "output.jpg";

        // Validate each input file exists
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
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(new Aspose.Imaging.Size(img.Width, img.Height));
            }
        }

        // Calculate canvas size for horizontal stitching
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (var sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Prepare EMF recording graphics
        Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, totalWidth, maxHeight);
        int deviceWidth = totalWidth;
        int deviceHeight = maxHeight;
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Aspose.Imaging.Size(deviceWidth, deviceHeight),
            new Aspose.Imaging.Size(deviceWidthMm, deviceHeightMm));

        // Draw each JPG onto the EMF canvas side by side
        int offsetX = 0;
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                Aspose.Imaging.Rectangle srcRect = new Aspose.Imaging.Rectangle(0, 0, img.Width, img.Height);
                graphics.DrawImage(img, destRect, srcRect, Aspose.Imaging.GraphicsUnit.Pixel);
                offsetX += img.Width;
            }
        }

        // End recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Save EMF to a temporary file
            string tempEmfPath = "temp.emf";
            Directory.CreateDirectory(Path.GetDirectoryName(tempEmfPath));
            emfImage.Save(tempEmfPath, new EmfOptions());

            // Load the EMF and convert to JPG
            using (Image emfLoaded = Image.Load(tempEmfPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };
                // Since the source is bound, call Save()
                emfLoaded.Save();
            }
        }
    }
}