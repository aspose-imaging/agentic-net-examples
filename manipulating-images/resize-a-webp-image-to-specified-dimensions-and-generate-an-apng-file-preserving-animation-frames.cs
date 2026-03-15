using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

// Input WebP file (can be animated)
string inputPath = @"C:\Images\input.webp";
// Desired output APNG file
string outputPath = @"C:\Images\output.apng";
// Target dimensions
int targetWidth = 200;
int targetHeight = 150;

// Load the WebP image (preserves all frames if animated)
using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
{
    // Prepare APNG creation options and specify the output file as the source
    ApngOptions apngOptions = new ApngOptions
    {
        Source = new FileCreateSource(outputPath, false),
        // Optional: set default frame duration (in milliseconds)
        DefaultFrameTime = 100
    };

    // Create an empty APNG image with the target dimensions
    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, targetWidth, targetHeight))
    {
        // Remove the automatically created default frame
        apngImage.RemoveAllFrames();

        // Iterate through each frame of the WebP image
        for (int i = 0; i < webpImage.PageCount; i++)
        {
            // Get the current frame as a RasterImage
            RasterImage frame = (RasterImage)webpImage.Pages[i];

            // Resize the frame to the target dimensions (using nearest‑neighbour resampling)
            frame.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

            // Append the resized frame to the APNG image
            apngImage.AddFrame(frame);
        }

        // Save the APNG file (the output path is already defined in apngOptions.Source)
        apngImage.Save();
    }
}