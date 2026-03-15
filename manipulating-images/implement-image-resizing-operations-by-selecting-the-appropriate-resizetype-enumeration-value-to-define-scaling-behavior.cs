using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf; // Example for WMF images, can be omitted for other formats

class Program
{
    static void Main()
    {
        // Directory containing the source image and where the resized images will be saved
        string dataDir = @"C:\temp\";

        // ------------------------------
        // Scale up by 2 using NearestNeighbourResample
        // ------------------------------
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Resize to double the original dimensions
            image.Resize(image.Width * 2, image.Height * 2, ResizeType.NearestNeighbourResample);
            // Save the resized image
            image.Save(dataDir + "sample_up_nearest.png");
        }

        // ------------------------------
        // Scale down by 2 using NearestNeighbourResample
        // ------------------------------
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Resize to half the original dimensions
            image.Resize(image.Width / 2, image.Height / 2, ResizeType.NearestNeighbourResample);
            image.Save(dataDir + "sample_down_nearest.png");
        }

        // ------------------------------
        // Scale up by 2 using BilinearResample
        // ------------------------------
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            image.Resize(image.Width * 2, image.Height * 2, ResizeType.BilinearResample);
            image.Save(dataDir + "sample_up_bilinear.png");
        }

        // ------------------------------
        // Scale down by 2 using BilinearResample
        // ------------------------------
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            image.Resize(image.Width / 2, image.Height / 2, ResizeType.BilinearResample);
            image.Save(dataDir + "sample_down_bilinear.png");
        }
    }
}