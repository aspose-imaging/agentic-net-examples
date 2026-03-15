using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source APNG file
        string dir = @"c:\temp\";
        string sourcePath = System.IO.Path.Combine(dir, "sample.apng");

        // ---------- Upscale (duplicate) ----------
        // Load the APNG image
        using (ApngImage image = (ApngImage)Image.Load(sourcePath))
        {
            // Double the width while preserving aspect ratio.
            // Using NearestNeighbourResample as the duplicate resize mode.
            image.ResizeWidthProportionally(image.Width * 2, ResizeType.NearestNeighbourResample);

            // Save the upscaled image
            string upscaledPath = System.IO.Path.Combine(dir, "sample_upscaled.apng");
            image.Save(upscaledPath);
        }

        // ---------- Downscale (duplicate) ----------
        // Load the original APNG image again
        using (ApngImage image = (ApngImage)Image.Load(sourcePath))
        {
            // Halve the width while preserving aspect ratio.
            // Using NearestNeighbourResample as the duplicate resize mode.
            image.ResizeWidthProportionally(image.Width / 2, ResizeType.NearestNeighbourResample);

            // Save the downscaled image
            string downscaledPath = System.IO.Path.Combine(dir, "sample_downscaled.apng");
            image.Save(downscaledPath);
        }
    }
}