using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                if (tiffImage is IMultipageImage multipage)
                {
                    ApngOptions createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, tiffImage.Width, tiffImage.Height))
                    {
                        apngImage.RemoveAllFrames();

                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            Image page = multipage.Pages[i];
                            RasterImage rasterPage = (RasterImage)page;
                            uint frameDelay = (uint)((i + 1) * 100); // unique delay per frame (ms)
                            apngImage.AddFrame(rasterPage, frameDelay);
                        }

                        apngImage.Save();
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}