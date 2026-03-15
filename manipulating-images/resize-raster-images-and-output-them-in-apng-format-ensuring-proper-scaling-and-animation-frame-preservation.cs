using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;

// Input parameters
string inputPath = "input.gif";          // Path to the source raster (single‑page or animated) image
string outputPath = "output.apng";       // Desired APNG output path
int newWidth = 800;                      // Target width
int newHeight = 600;                     // Target height
int defaultFrameTime = 100;              // Frame duration in milliseconds for the APNG

// Load the source image (could be single‑page or multi‑frame)
using (Image sourceImage = Image.Load(inputPath))
{
    // If the source is a GIF, resize it taking all frames into account to avoid artifacts
    if (sourceImage is GifImage gif)
    {
        // Resize each frame proportionally while preserving the animation integrity
        gif.ResizeFullFrame(newWidth, newHeight, ResizeType.NearestNeighbourResample);
    }

    // Create APNG options for the output file
    ApngOptions apngOptions = new ApngOptions
    {
        Source = new FileCreateSource(outputPath, false),
        DefaultFrameTime = (uint)defaultFrameTime,
        ColorType = PngColorType.TruecolorWithAlpha
    };

    // Create an empty APNG image with the target dimensions
    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, newWidth, newHeight))
    {
        // Remove the default frame that exists after creation
        apngImage.RemoveAllFrames();

        // Iterate through each page/frame of the source image
        foreach (var page in sourceImage.Pages)
        {
            // Clone the page to avoid modifying the original collection
            using (RasterImage frame = (RasterImage)page.Clone())
            {
                // Ensure the frame matches the target size (in case the source wasn't a GIF)
                frame.Resize(newWidth, newHeight);

                // Append the resized frame to the APNG animation
                apngImage.AddFrame(frame);
            }
        }

        // Save the assembled APNG file
        apngImage.Save();
    }
}