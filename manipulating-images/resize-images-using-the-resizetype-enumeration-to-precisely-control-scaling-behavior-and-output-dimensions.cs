using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for the source image and the resized outputs
        string inputPath = "input.jpg";
        string outputPathNearest = "output_nearest.jpg";
        string outputPathBilinear = "output_bilinear.jpg";

        // Load the image (load rule)
        using (Image image = Image.Load(inputPath))
        {
            // Resize the image by scaling up 2x using NearestNeighbourResample (ResizeType)
            image.Resize(image.Width * 2, image.Height * 2, ResizeType.NearestNeighbourResample);

            // Save the resized image (save rule)
            image.Save(outputPathNearest);
        }

        // Load the image again for a different resize operation
        using (Image image = Image.Load(inputPath))
        {
            // Resize the image by scaling down 2x using BilinearResample (ResizeType)
            image.Resize(image.Width / 2, image.Height / 2, ResizeType.BilinearResample);

            // Save the resized image
            image.Save(outputPathBilinear);
        }
    }
}