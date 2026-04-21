using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (WebPImage webp = new WebPImage(inputPath))
            {
                IMultipageImage multipage = webp as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP animation.");
                    return;
                }

                RasterImage firstFrame = (RasterImage)multipage.Pages[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    tiff.SavePixels(tiff.ActiveFrame.Bounds, firstFrame.LoadPixels(firstFrame.Bounds));

                    for (int i = 1; i < multipage.PageCount; i++)
                    {
                        tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                        tiff.ActiveFrame = tiff.Frames[i];
                        RasterImage frame = (RasterImage)multipage.Pages[i];
                        tiff.SavePixels(tiff.ActiveFrame.Bounds, frame.LoadPixels(frame.Bounds));
                    }

                    tiff.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}