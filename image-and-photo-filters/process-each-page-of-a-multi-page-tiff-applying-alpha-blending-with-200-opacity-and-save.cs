using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\temp\\input.tif";
            string outputPath = "C:\\temp\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int pageCount = tiff.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    tiff.ActiveFrame = tiff.Frames[i];
                    var bounds = tiff.ActiveFrame.Bounds;
                    Color[] pixels = tiff.LoadPixels(bounds);
                    for (int p = 0; p < pixels.Length; p++)
                    {
                        Color c = pixels[p];
                        pixels[p] = Color.FromArgb(200, c.R, c.G, c.B);
                    }
                    tiff.SavePixels(bounds, pixels);
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                tiff.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}