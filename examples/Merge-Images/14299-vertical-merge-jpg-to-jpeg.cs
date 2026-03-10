using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class JpegVerticalMerger
{
    // Merges a list of JPEG files vertically and saves the result as a JPEG.
    public static void MergeVertically(List<string> inputFiles, string outputFile)
    {
        // Load all source JPEG images.
        var sourceImages = new List<JpegImage>();
        foreach (var file in inputFiles)
        {
            // Use the constructor that loads from a file path (create rule).
            var img = new JpegImage(file);
            sourceImages.Add(img);
        }

        // Determine the width of the resulting image (maximum width of inputs)
        // and the total height (sum of all heights).
        int resultWidth = 0;
        int resultHeight = 0;
        foreach (var img in sourceImages)
        {
            if (img.Width > resultWidth) resultWidth = img.Width;
            resultHeight += img.Height;
        }

        // Create a blank JPEG image with the calculated dimensions.
        // This uses the constructor (width, height) – a create rule.
        using (var resultImage = new JpegImage(resultWidth, resultHeight))
        {
            // Current vertical offset where the next source image will be placed.
            int currentY = 0;

            // Blend each source image onto the result image at the appropriate offset.
            foreach (var src in sourceImages)
            {
                // Blend method overlays src onto resultImage at (0, currentY) with full opacity (255).
                // This follows the provided Blend rule.
                resultImage.Blend(new Point(0, currentY), src, 255);
                currentY += src.Height;
            }

            // Save the merged image to the specified output path.
            // This uses the Save(string) method – a save rule.
            resultImage.Save(outputFile);
        }

        // Dispose all source images.
        foreach (var img in sourceImages)
        {
            img.Dispose();
        }
    }

    // Example usage.
    static void Main()
    {
        var input = new List<string>
        {
            @"C:\Images\first.jpg",
            @"C:\Images\second.jpg",
            @"C:\Images\third.jpg"
        };
        string output = @"C:\Images\merged_output.jpg";

        MergeVertically(input, output);
        Console.WriteLine("Images merged successfully.");
    }
}