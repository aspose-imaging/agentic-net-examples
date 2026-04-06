using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            "Input\\image1.jpg",
            "Input\\image2.jpg",
            "Input\\image3.jpg"
        };

        // Hardcoded output JPG file
        string outputPath = "Output\\combined.jpg";

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

        // Convert each JPG to TGA and collect TGA paths
        List<string> tgaPaths = new List<string>();
        foreach (string jpgPath in inputPaths)
        {
            string tgaPath = Path.ChangeExtension(jpgPath, ".tga");
            using (JpegImage jpgImage = (JpegImage)Image.Load(jpgPath))
            {
                jpgImage.Save(tgaPath, new TgaOptions());
            }
            tgaPaths.Add(tgaPath);
        }

        // Load TGA images, collect sizes, and compute canvas dimensions (horizontal layout)
        List<Size> sizes = new List<Size>();
        foreach (string tgaPath in tgaPaths)
        {
            using (RasterImage tgaImage = (RasterImage)Image.Load(tgaPath))
            {
                sizes.Add(tgaImage.Size);
            }
        }

        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Create JPEG canvas bound to the output file
        Source outSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = outSource, Quality = 90 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (string tgaPath in tgaPaths)
            {
                using (RasterImage tgaImage = (RasterImage)Image.Load(tgaPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, tgaImage.Width, tgaImage.Height);
                    canvas.SaveArgb32Pixels(bounds, tgaImage.LoadArgb32Pixels(tgaImage.Bounds));
                    offsetX += tgaImage.Width;
                }
            }

            // Save the combined JPEG image
            canvas.Save();
        }
    }
}