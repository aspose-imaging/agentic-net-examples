using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.eps";
        string outputPath = "thumbnail.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var epsImage = Image.Load(inputPath) as EpsImage)
        {
            if (epsImage == null)
            {
                Console.Error.WriteLine("Failed to load EPS image.");
                return;
            }

            // Resize to thumbnail dimensions (150x150)
            epsImage.Resize(150, 150, ResizeType.NearestNeighbourResample);

            // Save as JPEG
            var jpegOptions = new JpegOptions();
            epsImage.Save(outputPath, jpegOptions);
        }
    }
}