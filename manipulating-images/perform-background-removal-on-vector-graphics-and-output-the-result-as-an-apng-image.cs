using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image is a vector type
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            // Rasterize the vector image to a temporary PNG with transparency
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                }
            };
            image.Save(tempPngPath, pngOptions);

            // Load the rasterized PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                // Create APNG options
                var apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 500 // milliseconds per frame (optional)
                };

                // Create APNG image and add the raster frame
                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(raster);
                    apng.Save();
                }
            }
        }
    }
}