using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG files
        string[] inputPaths = { "input1.jpg", "input2.jpg", "input3.jpg" };
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Determine canvas size (horizontal stitching)
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Temporary BigTIFF file to hold high‑resolution canvas
        string tempTiffPath = "temp/temp.tif";
        Directory.CreateDirectory(Path.GetDirectoryName(tempTiffPath) ?? ".");

        // Configure BigTIFF options
        BigTiffOptions bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default)
        {
            BitsPerSample = new ushort[] { 8, 8, 8 },
            Compression = TiffCompressions.Lzw,
            Photometric = TiffPhotometrics.Rgb,
            Source = new FileCreateSource(tempTiffPath, false)
        };

        // Create BigTIFF canvas and merge JPEG images
        using (BigTiffImage canvas = (BigTiffImage)Image.Create(bigTiffOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            canvas.Save();
        }

        // Load the created BigTIFF image for PNG conversion
        using (RasterImage bigTiffImage = (RasterImage)Image.Load(tempTiffPath))
        {
            string outputPath = "output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            bigTiffImage.Save(outputPath, pngOptions);
        }
    }
}