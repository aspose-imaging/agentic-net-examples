using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Cropping rectangle parameters
        int cropX = 10;
        int cropY = 10;
        int cropWidth = 200;
        int cropHeight = 150;

        // Rotation angle in degrees
        float rotationAngle = 45f;

        // New size for resizing
        int newWidth = 300;
        int newHeight = 200;

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!apng.IsCached)
                apng.CacheData();

            // Process each frame
            foreach (var page in apng.Pages)
            {
                var frame = (ApngFrame)page;

                // Crop the frame
                frame.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

                // Rotate the frame (background color set to white)
                frame.Rotate(rotationAngle, true, Color.White);

                // Resize the frame
                frame.Resize(newWidth, newHeight);
            }

            // Save the transformed APNG preserving animation
            apng.Save(outputPath);
        }
    }
}