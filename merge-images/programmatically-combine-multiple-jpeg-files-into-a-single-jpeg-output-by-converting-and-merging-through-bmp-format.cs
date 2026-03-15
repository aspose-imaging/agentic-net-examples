using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least two arguments: input JPEG files and output JPEG file.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program.exe <input1.jpg> <input2.jpg> ... <output.jpg>");
            return;
        }

        // Last argument is the output path; the rest are input images.
        string outputPath = args[args.Length - 1];
        string[] inputPaths = new string[args.Length - 1];
        Array.Copy(args, inputPaths, args.Length - 1);

        // Collect sizes of all input images.
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching.
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizes)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create an unbound BMP canvas.
        BmpOptions bmpOptions = new BmpOptions();
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            // Merge each JPEG onto the canvas.
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged canvas as JPEG.
            JpegOptions jpegOptions = new JpegOptions { Quality = 90 };
            canvas.Save(outputPath, jpegOptions);
        }
    }
}