using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/multipage.svg";
            string outputPath = "output/processed.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        Aspose.Imaging.Image page = multipageImage.Pages[i];

                        var svgOptions = new SvgRasterizationOptions
                        {
                            PageWidth = page.Width,
                            PageHeight = page.Height,
                            BackgroundColor = Aspose.Imaging.Color.White
                        };

                        using (MemoryStream ms = new MemoryStream())
                        {
                            var pngOptions = new PngOptions { VectorRasterizationOptions = svgOptions };
                            page.Save(ms, pngOptions);
                            ms.Position = 0;

                            using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(ms))
                            {
                                // No additional processing
                            }
                        }
                    }
                }

                image.Save(outputPath, new SvgOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}