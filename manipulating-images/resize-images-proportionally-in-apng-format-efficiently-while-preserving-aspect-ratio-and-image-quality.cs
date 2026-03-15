using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source APNG file
        string inputPath = "input.apng";

        // Path where the resized APNG will be saved
        string outputPath = "output_resized.apng";

        // Desired new width (height will be adjusted automatically to keep aspect ratio)
        int newWidth = 300;

        // Load the APNG image using Aspose.Imaging's load rule
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            // Proportionally resize the width; height is calculated internally to preserve aspect ratio
            // ResizeType.NearestNeighbourResample provides a fast, quality-preserving resize
            apng.ResizeWidthProportionally(newWidth, ResizeType.NearestNeighbourResample);

            // Save the resized image using Aspose.Imaging's save rule
            apng.Save(outputPath);
        }
    }
}