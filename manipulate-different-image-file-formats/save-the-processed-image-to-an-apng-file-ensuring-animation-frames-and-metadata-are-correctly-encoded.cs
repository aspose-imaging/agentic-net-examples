using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source animated image (e.g., GIF, WebP, etc.)
        string sourcePath = "input.gif";

        // Desired output APNG file path
        string outputPath = "output.apng";

        // Load the source image which may contain multiple frames
        using (Image sourceImage = Image.Load(sourcePath))
        {
            // Configure APNG saving options
            ApngOptions apngOptions = new ApngOptions
            {
                // Set default frame duration (in milliseconds)
                DefaultFrameTime = 100, // 100 ms per frame

                // Number of times the animation should loop (0 = infinite)
                NumPlays = 0,

                // Preserve original metadata (EXIF, XMP, etc.) in the output file
                KeepMetadata = true
            };

            // Save the loaded image as an animated PNG using the configured options
            sourceImage.Save(outputPath, apngOptions);
        }
    }
}