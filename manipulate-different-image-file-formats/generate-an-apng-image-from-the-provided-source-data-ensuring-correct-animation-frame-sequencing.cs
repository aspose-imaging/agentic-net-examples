using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputFolder = "frames";
        string outputFile = "merged.png";

        string[] imageFiles = Directory.GetFiles(inputFolder, "*.png");
        if (imageFiles.Length == 0)
        {
            Console.WriteLine("No source images found.");
            return;
        }

        List<RasterImage> images = new List<RasterImage>();
        int maxWidth = 0;
        int totalHeight = 0;

        foreach (var file in imageFiles)
        {
            RasterImage img = (RasterImage)Image.Load(file);
            images.Add(img);
            if (img.Width > maxWidth) maxWidth = img.Width;
            totalHeight += img.Height;
        }

        using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions { Source = new FileCreateSource(outputFile, false) }, maxWidth, totalHeight))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.Transparent);

            int yOffset = 0;
            foreach (var img in images)
            {
                graphics.DrawImage(img, new Point(0, yOffset));
                yOffset += img.Height;
                img.Dispose();
            }

            canvas.Save();
        }
    }
}