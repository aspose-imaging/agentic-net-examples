using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

namespace CombineJpgToPngViaDjvu
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CombineJpgToPngViaDjvu <input1.jpg> <input2.jpg> ... <output.png>");
                return;
            }

            string outputPath = args[args.Length - 1];
            string[] inputJpgPaths = args.Take(args.Length - 1).ToArray();

            List<Size> pageSizes = new List<Size>();

            foreach (string jpgPath in inputJpgPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                {
                    pageSizes.Add(img.Size);
                }
            }

            int canvasWidth = pageSizes.Sum(s => s.Width);
            int canvasHeight = pageSizes.Max(s => s.Height);

            Source pngSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = pngSource };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string jpgPath in inputJpgPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                    {
                        Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                canvas.Save();
            }

            Console.WriteLine($"Combined image saved to: {outputPath}");
        }
    }
}