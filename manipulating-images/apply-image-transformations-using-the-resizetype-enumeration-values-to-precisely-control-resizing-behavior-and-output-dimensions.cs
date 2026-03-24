using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPathNearest = @"C:\Images\Resized\sample_nearest.jpg";
        string outputPathBilinear = @"C:\Images\Resized\sample_bilinear.jpg";
        string outputPathLanczos = @"C:\Images\Resized\sample_lanczos.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathNearest));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathBilinear));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathLanczos));

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Resize using NearestNeighbourResample
            image.Resize(image.Width / 2, image.Height / 2, ResizeType.NearestNeighbourResample);
            image.Save(outputPathNearest, new JpegOptions());

            // Reload original image for a fresh operation
            image.Dispose();
        }

        // Load again for the next resize operation
        using (Image image = Image.Load(inputPath))
        {
            // Resize using BilinearResample
            image.Resize(image.Width * 2, image.Height * 2, ResizeType.BilinearResample);
            image.Save(outputPathBilinear, new JpegOptions());

            // Reload again for the third resize
            image.Dispose();
        }

        // Load again for Lanczos resample and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Resize using LanczosResample
            image.Resize(800, 600, ResizeType.LanczosResample);
            image.Save(outputPathLanczos, new PngOptions());
        }
    }
}