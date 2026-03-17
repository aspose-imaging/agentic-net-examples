using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input1> <input2> ... <outputBigTiff>");
            return;
        }

        string outputPath = args[args.Length - 1];
        string[] inputPaths = new string[args.Length - 1];
        Array.Copy(args, inputPaths, args.Length - 1);

        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                if (!img.IsCached) img.CacheData();
                sizes.Add(img.Size);
            }
        }

        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        Source src = new FileCreateSource(outputPath, false);
        BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default)
        {
            Source = src,
            Photometric = TiffPhotometrics.Rgb,
            Compression = TiffCompressions.Lzw,
            BitsPerSample = new ushort[] { 8, 8, 8 }
        };

        using (BigTiffImage canvas = (BigTiffImage)Image.Create(options, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    if (!img.IsCached) img.CacheData();
                    var bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            canvas.Save();
        }
    }
}