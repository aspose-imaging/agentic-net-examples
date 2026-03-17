using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging;

// Input SVG file path
string inputPath = @"C:\Images\input.svg";
// Output SVG file path
string outputPath = @"C:\Images\output.svg";

// Desired dimensions for the cropped SVG (preserve aspect ratio)
int targetWidth = 200;
int targetHeight = 100;

using (SvgImage svgImage = new SvgImage(inputPath))
{
    // Original dimensions
    int originalWidth = svgImage.Width;
    int originalHeight = svgImage.Height;

    // Compute aspect ratios
    double originalRatio = (double)originalWidth / originalHeight;
    double targetRatio = (double)targetWidth / targetHeight;

    // Determine cropping rectangle to match target aspect ratio
    int cropX = 0, cropY = 0, cropWidth = originalWidth, cropHeight = originalHeight;

    if (originalRatio > targetRatio)
    {
        // Image is wider than target: crop width
        cropWidth = (int)(originalHeight * targetRatio);
        cropX = (originalWidth - cropWidth) / 2;
    }
    else if (originalRatio < targetRatio)
    {
        // Image is taller than target: crop height
        cropHeight = (int)(originalWidth / targetRatio);
        cropY = (originalHeight - cropHeight) / 2;
    }
    // If ratios are equal, no cropping needed (full image)

    // Create rectangle for cropping
    Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

    // Perform the crop operation
    svgImage.Crop(cropRect);

    // Save the cropped SVG, preserving vector fidelity
    svgImage.Save(outputPath);
}