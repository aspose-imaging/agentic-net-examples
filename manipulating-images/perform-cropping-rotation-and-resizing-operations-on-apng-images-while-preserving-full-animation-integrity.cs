using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output/output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Define transformation parameters
            int cropLeft = 10;
            int cropTop = 10;
            int cropRight = 10;
            int cropBottom = 10;
            float rotateAngle = 45f; // degrees
            int newWidth = apngImage.Width / 2;
            int newHeight = apngImage.Height / 2;

            // Process each frame preserving animation
            foreach (var page in apngImage.Pages)
            {
                // Each page is an ApngFrame
                ApngFrame frame = (ApngFrame)page;

                // Crop the frame
                frame.Crop(cropLeft, cropRight, cropTop, cropBottom);

                // Rotate the frame (use transparent background)
                frame.Rotate(rotateAngle, true, Color.Transparent);

                // Resize the frame
                frame.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
            }

            // Save the transformed APNG
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}