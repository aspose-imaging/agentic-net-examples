using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

// Input raster or vector image path
string inputPath = "input_image.png";
// Output APNG file path
string outputPath = "output_image.apng";

// Load the source image
using (Image sourceImage = Image.Load(inputPath))
{
    // If the loaded image is a vector image, remove its background
    if (sourceImage is Aspose.Imaging.VectorImage vectorImg)
    {
        // Removes the background from the vector image
        vectorImg.RemoveBackground();
    }

    // Prepare APNG creation options
    ApngOptions apngOptions = new ApngOptions
    {
        // Define the file where the APNG will be created
        Source = new FileCreateSource(outputPath, false),
        // Ensure the APNG supports alpha channel
        ColorType = PngColorType.TruecolorWithAlpha,
        // Set default frame duration (in milliseconds)
        DefaultFrameTime = 500
    };

    // Create an empty APNG image with the same dimensions as the source
    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, sourceImage.Width, sourceImage.Height))
    {
        // Remove the automatically added default frame
        apngImage.RemoveAllFrames();

        // Add the processed source image as a single frame
        // If the source is not a RasterImage, rasterize it via a temporary PNG stream
        if (sourceImage is RasterImage rasterImg)
        {
            apngImage.AddFrame(rasterImg);
        }
        else
        {
            // Rasterize the vector image to a raster image using PNG options
            using (MemoryStream ms = new MemoryStream())
            {
                // Save vector image to memory as PNG with alpha
                sourceImage.Save(ms, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                ms.Position = 0;
                using (RasterImage rasterized = (RasterImage)Image.Load(ms))
                {
                    apngImage.AddFrame(rasterized);
                }
            }
        }

        // Save the APNG to the specified file (the Save method uses the options' Source)
        apngImage.Save();
    }
}