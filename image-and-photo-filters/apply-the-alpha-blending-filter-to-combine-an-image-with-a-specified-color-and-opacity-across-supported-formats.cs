using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            PngOptions overlayOptions = new PngOptions();
            using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, source.Width, source.Height))
            {
                int opacity = 128;
                int red = 255, green = 0, blue = 0;
                int argb = (opacity << 24) | (red << 16) | (green << 8) | blue;

                int[] pixels = new int[source.Width * source.Height];
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = argb;
                }

                overlay.SaveArgb32Pixels(new Rectangle(0, 0, overlay.Width, overlay.Height), pixels);
                source.Blend(new Point(0, 0), overlay, 255);
            }

            ImageOptionsBase saveOptions;
            string ext = Path.GetExtension(outputPath).ToUpperInvariant();
            switch (ext)
            {
                case ".JPG":
                case ".JPEG":
                    saveOptions = new JpegOptions { Quality = 90 };
                    break;
                case ".PNG":
                    saveOptions = new PngOptions();
                    break;
                case ".BMP":
                    saveOptions = new BmpOptions();
                    break;
                case ".TIFF":
                case ".TIF":
                    saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    break;
                case ".GIF":
                    saveOptions = new GifOptions();
                    break;
                case ".WEBP":
                    saveOptions = new WebPOptions();
                    break;
                default:
                    saveOptions = new PngOptions();
                    break;
            }

            source.Save(outputPath, saveOptions);
        }
    }
}