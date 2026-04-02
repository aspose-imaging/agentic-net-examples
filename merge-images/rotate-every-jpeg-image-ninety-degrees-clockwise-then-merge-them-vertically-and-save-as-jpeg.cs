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
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        string outputPath = "merged_output.jpg";

        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int canvasWidth = 0;
        int canvasHeight = 0;

        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                if (img.Width > canvasWidth)
                    canvasWidth = img.Width;
                canvasHeight += img.Height;
            }
        }

        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions { Source = outputSource, Quality = 90 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetY = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    Rectangle destRect = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }
            }
            canvas.Save();
        }
    }
}