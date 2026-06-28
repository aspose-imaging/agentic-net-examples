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
        try
        {
            string[] inputPaths = new[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            string outputPath = "output/merged.jpg";

            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    sizes.Add(img.Size);
                }
            }

            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
 * 1. When a mobile app processes user‑uploaded photos taken in landscape orientation, rotates each JPEG 90° clockwise, and stacks them vertically to create a single scrolling image for social sharing.
 * 2. When an e‑commerce platform generates a product brochure by rotating scanned label images and merging them into one high‑quality JPEG for printing.
 * 3. When a digital signage system receives multiple camera snapshots, rotates them to match the display orientation and merges them vertically to produce a single JPEG banner.
 * 4. When a document management workflow needs to combine scanned pages saved as JPEGs, correct their orientation, and produce a single merged JPEG for archival.
 * 5. When a real‑estate website creates a vertical slideshow thumbnail by rotating floor‑plan JPEGs and stitching them into one image for faster page loading.
 */