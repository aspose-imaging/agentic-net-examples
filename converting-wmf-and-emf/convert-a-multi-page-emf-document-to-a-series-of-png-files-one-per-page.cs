using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\Images\multpage.emf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = @"C:\Images\Output";
        Directory.CreateDirectory(outputDir);

        using (Image image = Image.Load(inputPath))
        {
            var multipage = image as IMultipageImage;
            if (multipage != null && multipage.PageCount > 0)
            {
                int pageIndex = 0;
                foreach (var pageObj in multipage.Pages)
                {
                    using (Image page = (Image)pageObj)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var pngOptions = new PngOptions();
                        var vectorOptions = new EmfRasterizationOptions
                        {
                            PageSize = page.Size
                        };
                        pngOptions.VectorRasterizationOptions = vectorOptions;

                        page.Save(outputPath, pngOptions);
                    }
                    pageIndex++;
                }
            }
            else
            {
                string outputPath = Path.Combine(outputDir, "page_0.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var pngOptions = new PngOptions();
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, pngOptions);
            }
        }
    }
}