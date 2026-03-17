using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input PSD file path
        string inputPath = "input.psd";

        // Output paths
        string editedPsdPath = "edited.psd";
        string pngPath = "converted.png";

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel-level operations
            RasterImage raster = (RasterImage)image;
            if (!raster.IsCached)
                raster.CacheData();

            // Example edit: increase brightness by 30 units
            raster.AdjustBrightness(30);

            // Save the edited image back to PSD format, preserving layers
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb,
                Source = new FileCreateSource(editedPsdPath, false)
            };
            image.Save(editedPsdPath, psdOptions);

            // Convert the edited PSD to PNG (layers will be flattened in the PNG)
            PngOptions pngOptions = new PngOptions();
            image.Save(pngPath, pngOptions);
        }
    }
}