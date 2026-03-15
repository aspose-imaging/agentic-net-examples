using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgCropExample
{
    static void Main()
    {
        // Input SVG file path
        string inputPath = @"C:\Images\input.svg";
        // Output SVG file path
        string outputPath = @"C:\Images\output.svg";

        // Desired dimensions after cropping (preserve aspect ratio)
        int targetWidth = 300;   // e.g., 300 pixels
        int targetHeight = 200;  // e.g., 200 pixels

        // Load the SVG image from file
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Original dimensions
            int originalWidth = svgImage.Width;
            int originalHeight = svgImage.Height;

            // Compute aspect ratios
            double targetRatio = (double)targetWidth / targetHeight;
            double originalRatio = (double)originalWidth / originalHeight;

            // Determine crop size that matches the target aspect ratio
            int cropWidth, cropHeight;
            if (originalRatio > targetRatio)
            {
                // Original is wider than target – crop width
                cropHeight = originalHeight;
                cropWidth = (int)(cropHeight * targetRatio);
            }
            else
            {
                // Original is taller (or equal) – crop height
                cropWidth = originalWidth;
                cropHeight = (int)(cropWidth / targetRatio);
            }

            // Center the crop rectangle
            int left = (originalWidth - cropWidth) / 2;
            int top = (originalHeight - cropHeight) / 2;

            // Create the rectangle and perform cropping
            Rectangle cropRect = new Rectangle(left, top, cropWidth, cropHeight);
            svgImage.Crop(cropRect);

            // Resize to the exact target dimensions (now aspect ratio matches)
            svgImage.Resize(targetWidth, targetHeight, ResizeType.Lanczos);

            // Save the cropped SVG preserving vector fidelity
            svgImage.Save(outputPath);
        }
    }
}