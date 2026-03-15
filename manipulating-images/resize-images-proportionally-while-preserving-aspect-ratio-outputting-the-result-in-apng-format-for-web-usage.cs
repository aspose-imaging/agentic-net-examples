using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input image path (any supported format)
        string inputPath = "input.png";

        // Output APNG path suitable for web usage
        string outputPath = "output.apng";

        // Desired width for the resized image (height will be adjusted proportionally)
        int targetWidth = 300;

        // Load the source image
        using (Image srcImage = Image.Load(inputPath))
        {
            // If the loaded image is already an APNG, use its specific proportional resize method
            if (srcImage is ApngImage apngImg)
            {
                // Resize width proportionally; height is adjusted automatically
                apngImg.ResizeWidthProportionally(targetWidth, ResizeType.NearestNeighbourResample);

                // Save the result as APNG
                apngImg.Save(outputPath, new ApngOptions());
            }
            else
            {
                // For other image types, calculate the proportional height manually
                int originalWidth = srcImage.Width;
                int originalHeight = srcImage.Height;
                int targetHeight = (int)Math.Round((double)originalHeight * targetWidth / originalWidth);

                // Perform generic resize while preserving aspect ratio
                srcImage.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                // Save the resized image as APNG
                srcImage.Save(outputPath, new ApngOptions());
            }
        }
    }
}