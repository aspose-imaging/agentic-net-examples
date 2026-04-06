using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main()
    {
        string[] inputPaths = new[] { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPath = "output/combined_big.tif";

        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
            options.Source = new FileCreateSource(outputPath, false);
            options.KeepMetadata = true;

            using (BigTiffImage bigTiff = (BigTiffImage)Image.Create(options, firstImage.Width, firstImage.Height))
            {
                bigTiff.SaveArgb32Pixels(
                    new Rectangle(0, 0, firstImage.Width, firstImage.Height),
                    firstImage.LoadArgb32Pixels(firstImage.Bounds));

                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        bigTiff.AddPage(img);
                    }
                }

                bigTiff.Save();
            }
        }
    }
}