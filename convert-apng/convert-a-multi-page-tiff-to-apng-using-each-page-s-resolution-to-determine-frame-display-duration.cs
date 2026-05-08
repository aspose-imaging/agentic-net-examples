using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int pageCount;
            int width;
            int height;

            using (Image tiffImage = Image.Load(inputPath))
            {
                if (tiffImage is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }
                else
                {
                    pageCount = 1;
                }

                width = tiffImage.Width;
                height = tiffImage.Height;
            }

            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
            {
                apngImage.RemoveAllFrames();

                using (Image tiffImage = Image.Load(inputPath))
                {
                    IMultipageImage multipage = tiffImage as IMultipageImage;

                    for (int i = 0; i < pageCount; i++)
                    {
                        using (Image page = multipage != null ? multipage.Pages[i] : Image.Load(inputPath))
                        {
                            RasterImage raster = (RasterImage)page;
                            apngImage.AddFrame(raster);

                            int duration = (int)Math.Max(1, 1000.0 / Math.Max(1, raster.HorizontalResolution));
                            ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                            frame.FrameTime = duration;
                        }
                    }
                }

                apngImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}