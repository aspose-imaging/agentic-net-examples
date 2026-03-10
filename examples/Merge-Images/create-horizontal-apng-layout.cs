using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

// Load source raster images that will form the horizontal animation frames
using (RasterImage img1 = (RasterImage)Image.Load("left.png"))
using (RasterImage img2 = (RasterImage)Image.Load("center.png"))
using (RasterImage img3 = (RasterImage)Image.Load("right.png"))
{
    // Determine common dimensions for the APNG.
    // For simplicity we assume all source images have the same size.
    int width = img1.Width;
    int height = img1.Height;

    // Configure APNG creation options.
    ApngOptions apngOptions = new ApngOptions
    {
        // 200 ms per frame (adjust as needed)
        DefaultFrameTime = 200,
        // 0 = infinite looping
        NumPlays = 0,
        // Preserve alpha channel
        ColorType = PngColorType.TruecolorWithAlpha
    };

    // Create a new APNG image with the specified dimensions.
    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
    {
        // The image is created with a default first frame; remove it.
        apng.RemoveAllFrames();

        // Add each source image as a separate frame, producing a horizontal sequence.
        apng.AddFrame(img1); // frame 0
        apng.AddFrame(img2); // frame 1
        apng.AddFrame(img3); // frame 2

        // Save the resulting animated PNG.
        apng.Save("horizontal_layout.apng");
    }
}