using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.FileFormats.Tiff.TiffImage tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)image;

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

            for (int i = 0; i < tiffImage.PageCount; i++)
            {
                tiffImage.ActiveFrame = tiffImage.Frames[i];
                ((Aspose.Imaging.RasterImage)tiffImage).Filter(tiffImage.Bounds, filterOptions);
            }

            var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}