using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Path to the source image (any raster format supported by Aspose.Imaging)
        const string sourcePath = "source_image.png";

        // Path for the resulting APNG file
        const string outputPath = "converted_image.apng";

        // Load the source image as a RasterImage
        using (RasterImage raster = (RasterImage)Image.Load(sourcePath))
        {
            // Define APNG options – set a default frame duration (e.g., 500 ms)
            ApngOptions apngOptions = new ApngOptions
            {
                DefaultFrameTime = 500, // duration of each frame in milliseconds
                ColorType = PngColorType.TruecolorWithAlpha // ensure lossless alpha support
            };

            // Save the raster image as an APNG file using the defined options
            raster.Save(outputPath, apngOptions);
        }
    }
}