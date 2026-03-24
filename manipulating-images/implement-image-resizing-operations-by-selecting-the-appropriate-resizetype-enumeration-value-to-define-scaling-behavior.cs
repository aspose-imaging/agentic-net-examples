using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageResizingDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output directory and file names
            string outputDir = "output";
            string outputPathLanczos = Path.Combine(outputDir, "resized_lanczos.jpg");
            string outputPathBilinear = Path.Combine(outputDir, "resized_bilinear.jpg");
            string outputPathAdaptive = Path.Combine(outputDir, "resized_adaptive.jpg");

            // Ensure output directory exists before each save
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathLanczos));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathBilinear));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathAdaptive));

            // Load the image once and perform multiple resize operations
            using (Image image = Image.Load(inputPath))
            {
                // Resize using LanczosResample (high quality)
                image.Resize(image.Width * 2, image.Height * 2, ResizeType.LanczosResample);
                image.Save(outputPathLanczos, new JpegOptions());

                // Reset to original size by reloading (or you could clone before each resize)
                image.Dispose();
                using (Image imageBilinear = Image.Load(inputPath))
                {
                    // Resize using BilinearResample (balanced quality/performance)
                    imageBilinear.Resize(imageBilinear.Width / 2, imageBilinear.Height / 2, ResizeType.BilinearResample);
                    imageBilinear.Save(outputPathBilinear, new JpegOptions());
                }

                // Reload again for the third operation
                using (Image imageAdaptive = Image.Load(inputPath))
                {
                    // Resize using AdaptiveResample (advanced algorithm)
                    imageAdaptive.Resize(imageAdaptive.Width, imageAdaptive.Height, ResizeType.AdaptiveResample);
                    imageAdaptive.Save(outputPathAdaptive, new JpegOptions());
                }
            }
        }
    }
}