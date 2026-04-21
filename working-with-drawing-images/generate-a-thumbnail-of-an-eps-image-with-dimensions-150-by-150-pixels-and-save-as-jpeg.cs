using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image, resize, and save as JPEG
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Resize to 150x150 pixels using nearest neighbour resampling
            epsImage.Resize(150, 150, ResizeType.NearestNeighbourResample);

            // Prepare JPEG save options (default options are sufficient)
            var jpegOptions = new JpegOptions();

            // Save the resized image as JPEG
            epsImage.Save(outputPath, jpegOptions);
        }
    }
}