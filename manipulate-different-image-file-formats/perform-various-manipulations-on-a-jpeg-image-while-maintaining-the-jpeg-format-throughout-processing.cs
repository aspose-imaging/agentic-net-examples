using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (can be passed as command‑line arguments)
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        string outputPath = args.Length > 1 ? args[1] : "output.jpg";

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Auto‑rotate based on EXIF orientation
            image.AutoRotate();

            // Brightness (+20) and contrast (+0.2)
            image.AdjustBrightness(20);
            image.AdjustContrast(0.2f);

            // Rotate 90 degrees clockwise, filling empty corners with white
            image.Rotate(90f, true, Color.White);

            // Resize to half of the current dimensions using nearest‑neighbour resampling
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Crop the central 80% of the resized image
            int cropWidth = (int)(newWidth * 0.8);
            int cropHeight = (int)(newHeight * 0.8);
            int cropX = (newWidth - cropWidth) / 2;
            int cropY = (newHeight - cropHeight) / 2;
            image.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

            // Prepare JPEG save options
            JpegOptions saveOptions = new JpegOptions
            {
                Quality = 90,
                CompressionType = JpegCompressionMode.Progressive,
                ColorType = JpegCompressionColorMode.YCbCr,
                ResolutionSettings = new ResolutionSetting(96, 96),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Save the processed image, preserving JPEG format
            image.Save(outputPath, saveOptions);
        }
    }
}