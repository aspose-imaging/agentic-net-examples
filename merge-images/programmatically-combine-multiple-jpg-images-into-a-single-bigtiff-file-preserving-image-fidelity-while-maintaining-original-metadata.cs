using System;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <output_big_tiff_path> <input_jpg_path1> [<input_jpg_path2> ...]");
            return;
        }

        string outputPath = args[0];
        string[] inputPaths = args.Skip(1).ToArray();

        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int canvasWidth = firstImage.Width;
            int canvasHeight = firstImage.Height;

            BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                KeepMetadata = true
            };

            using (BigTiffImage bigTiff = (BigTiffImage)Image.Create(options, canvasWidth, canvasHeight))
            {
                bigTiff.AddPage(firstImage);

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