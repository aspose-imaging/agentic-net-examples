using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired dimensions after cropping/resizing
        int targetWidth = 800;
        int targetHeight = 600;

        // Load SVG image
        using (Image image = Image.Load(inputPath))
        {
            SvgImage svg = (SvgImage)image;

            // Original dimensions
            int origWidth = svg.Width;
            int origHeight = svg.Height;

            // Compute aspect ratios
            double origAspect = (double)origWidth / origHeight;
            double targetAspect = (double)targetWidth / targetHeight;

            // Determine crop rectangle to match target aspect ratio
            Aspose.Imaging.Rectangle cropRect;
            if (origAspect > targetAspect)
            {
                // Image is wider than target – crop width
                int newWidth = (int)(origHeight * targetAspect);
                int left = (origWidth - newWidth) / 2;
                cropRect = new Aspose.Imaging.Rectangle(left, 0, newWidth, origHeight);
            }
            else
            {
                // Image is taller than target – crop height
                int newHeight = (int)(origWidth / targetAspect);
                int top = (origHeight - newHeight) / 2;
                cropRect = new Aspose.Imaging.Rectangle(0, top, origWidth, newHeight);
            }

            // Perform cropping
            svg.Crop(cropRect);

            // Resize to exact target dimensions while preserving aspect ratio
            svg.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

            // Save the resulting SVG
            svg.Save(outputPath);
        }
    }
}