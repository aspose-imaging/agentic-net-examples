using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // args: <cmxPath> <outputJpgPath> <inputJpg1> [<inputJpg2> ...]
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: Program <cmxPath> <outputJpgPath> <inputJpg1> [<inputJpg2> ...]");
            return;
        }

        string cmxPath = args[0];
        string outputPath = args[1];
        var inputPaths = new List<string>();
        for (int i = 2; i < args.Length; i++)
            inputPaths.Add(args[i]);

        // Load CMX to obtain canvas dimensions
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Collect sizes of input images (optional, shown for pattern compliance)
            var sizeList = new List<Size>();
            foreach (string imgPath in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(imgPath))
                {
                    sizeList.Add(img.Size);
                }
            }

            // Create output source and JPEG options
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outputSource,
                Quality = 90
            };

            // Create JPEG canvas with dimensions from CMX
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string imgPath in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(imgPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image (output path already bound via source)
                canvas.Save();
            }
        }
    }
}