using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.j2k";
        string outputPath = "output.j2k";

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            if (!image.IsCached)
                image.CacheData();

            var cropRect = new Rectangle(50, 50, image.Width - 100, image.Height - 100);
            image.Crop(cropRect);

            image.Resize(image.Width / 2, image.Height / 2, ResizeType.NearestNeighbourResample);

            image.Rotate(45.0f, true, Color.White);

            var saveOptions = new Jpeg2000Options
            {
                Irreversible = true,
                CompressionRatios = new int[] { 10, 5 },
                Comments = new string[] { "Processed with Aspose.Imaging" },
                KeepMetadata = true
            };

            image.Save(outputPath, saveOptions);
        }
    }
}