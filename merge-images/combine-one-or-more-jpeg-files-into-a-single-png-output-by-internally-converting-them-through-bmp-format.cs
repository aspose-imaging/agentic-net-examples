using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Input JPEG files (hard‑coded paths)
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Output PNG file (hard‑coded path)
        string outputPath = "output.png";

        // Validate each input file
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

        // Calculate canvas dimensions (horizontal stitching)
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Prepare PNG canvas bound to the output file
        PngOptions pngOptions = new PngOptions
        {
            Source = new FileCreateSource(outputPath, false)
        };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;

            foreach (string path in inputPaths)
            {
                // Load JPEG as raster image
                using (RasterImage jpegRaster = (RasterImage)Image.Load(path))
                {
                    // Convert JPEG to BMP in memory
                    using (MemoryStream bmpStream = new MemoryStream())
                    {
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            Source = new StreamSource(bmpStream, false)
                        };
                        using (RasterImage bmpRaster = (RasterImage)Image.Create(bmpOptions, jpegRaster.Width, jpegRaster.Height))
                        {
                            // Copy pixel data from JPEG to BMP
                            int[] pixels = jpegRaster.LoadArgb32Pixels(jpegRaster.Bounds);
                            bmpRaster.SaveArgb32Pixels(bmpRaster.Bounds, pixels);
                        }

                        // Reload BMP from the memory stream for merging
                        bmpStream.Position = 0;
                        using (RasterImage bmpForMerge = (RasterImage)Image.Load(bmpStream))
                        {
                            // Paste BMP onto the canvas
                            Rectangle bounds = new Rectangle(offsetX, 0, bmpForMerge.Width, bmpForMerge.Height);
                            canvas.SaveArgb32Pixels(bounds, bmpForMerge.LoadArgb32Pixels(bmpForMerge.Bounds));
                        }
                    }

                    offsetX += jpegRaster.Width;
                }
            }

            // Save the bound PNG canvas
            canvas.Save();
        }
    }
}