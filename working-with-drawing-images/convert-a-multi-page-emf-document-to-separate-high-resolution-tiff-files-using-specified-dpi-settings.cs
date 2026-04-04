using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        using (Image image = Image.Load(inputPath))
        {
            IMultipageImage multipage = image as IMultipageImage;
            int pageCount = multipage != null ? multipage.PageCount : 1;

            const int dpiX = 300;
            const int dpiY = 300;

            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.tif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                tiffOptions.ResolutionSettings = new ResolutionSetting(dpiX, dpiY);

                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    PageSize = image.Size
                };
                tiffOptions.VectorRasterizationOptions = vectorOptions;

                if (multipage != null)
                {
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));
                }

                image.Save(outputPath, tiffOptions);
            }
        }
    }
}