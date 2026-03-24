using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output JPEG2000 path
        string outputPath = "combined.jp2";

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
            using (JpegImage img = (JpegImage)Image.Load(path))
            {
                sizes.Add(new Size(img.Width, img.Height));
            }
        }

        // Calculate canvas dimensions (horizontal concatenation)
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizes)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        // Prepare JPEG2000 options (keep metadata, bind to output file)
        Jpeg2000Options options = new Jpeg2000Options
        {
            Source = new FileCreateSource(outputPath, false),
            KeepMetadata = true,
            Irreversible = true // use lossless wavelet transform
        };

        // Create JPEG2000 canvas
        using (Jpeg2000Image canvas = new Jpeg2000Image(totalWidth, maxHeight, options))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (JpegImage img = (JpegImage)Image.Load(path))
                {
                    // Load pixel data from source image
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    // Define destination rectangle on the canvas
                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                    // Paste pixels onto canvas
                    canvas.SaveArgb32Pixels(destRect, pixels);
                    offsetX += img.Width;
                }
            }

            // Save the bound JPEG2000 image
            canvas.Save();
        }
    }
}