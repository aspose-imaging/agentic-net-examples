using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string resizedPath = "resized.png";
        string croppedPath = "cropped.png";
        string tiffPath = "output.tif";

        // Resize the image to half its original dimensions using lossless nearest-neighbour resampling
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            if (!image.IsCached) image.CacheData();

            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
            image.Save(resizedPath, new PngOptions());

            Console.WriteLine($"Resized image saved to {resizedPath}");
        }

        // Crop the central region of the image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            if (!image.IsCached) image.CacheData();

            int cropWidth = image.Width / 2;
            int cropHeight = image.Height / 2;
            int x = (image.Width - cropWidth) / 2;
            int y = (image.Height - cropHeight) / 2;

            Rectangle rect = new Rectangle(x, y, cropWidth, cropHeight);
            image.Crop(rect);
            image.Save(croppedPath, new PngOptions());

            Console.WriteLine($"Cropped image saved to {croppedPath}");
        }

        // Convert the PNG image to a lossless TIFF format
        using (Image image = Image.Load(inputPath))
        {
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(tiffPath, tiffOptions);

            Console.WriteLine($"Image converted to TIFF and saved to {tiffPath}");
        }
    }
}