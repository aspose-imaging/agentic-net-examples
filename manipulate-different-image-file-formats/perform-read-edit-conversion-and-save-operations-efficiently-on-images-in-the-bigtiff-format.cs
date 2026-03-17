using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.bigtiff";
        string outputBigTiffPath = @"C:\Images\output.bigtiff";
        string outputPngPath = @"C:\Images\output.png";

        using (var bigTiff = (BigTiffImage)Image.Load(inputPath))
        {
            if (!bigTiff.IsCached)
                bigTiff.CacheData();

            bigTiff.Resize(bigTiff.Width / 2, bigTiff.Height / 2, ResizeType.NearestNeighbourResample);

            int cropWidth = (int)(bigTiff.Width * 0.8);
            int cropHeight = (int)(bigTiff.Height * 0.8);
            int cropX = (bigTiff.Width - cropWidth) / 2;
            int cropY = (bigTiff.Height - cropHeight) / 2;
            var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            bigTiff.Crop(cropRect);

            bigTiff.Rotate(45f, true, Color.White);

            var saveOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            bigTiff.Save(outputBigTiffPath, saveOptions);
        }

        using (var editedBigTiff = (BigTiffImage)Image.Load(outputBigTiffPath))
        {
            var pngOptions = new PngOptions();
            editedBigTiff.Save(outputPngPath, pngOptions);
        }
    }
}