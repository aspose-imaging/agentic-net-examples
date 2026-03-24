using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output/output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (ApngImage apng = (ApngImage)Aspose.Imaging.Image.Load(inputPath))
        {
            int width = apng.Width;
            int height = apng.Height;

            BmpOptions bmpOptions = new BmpOptions();
            string overlayPath = Path.Combine(Path.GetTempPath(), "overlay.bmp");
            bmpOptions.Source = new FileCreateSource(overlayPath, false);

            using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(overlay);
                Aspose.Imaging.Color overlayColor = Aspose.Imaging.Color.FromArgb(255, 255, 0, 0);
                graphics.Clear(overlayColor);

                foreach (ApngFrame frame in apng.Pages)
                {
                    ((Aspose.Imaging.RasterImage)frame).Blend(new Aspose.Imaging.Point(0, 0), overlay, 128);
                }
            }

            apng.Save(outputPath, new ApngOptions());
        }
    }
}