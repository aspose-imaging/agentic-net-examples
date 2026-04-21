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
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\result.jpg";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image, rotate it, and save as JPEG
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Rotate the image 45 degrees around its centre
            epsImage.Rotate(45f);

            // Save the rotated image as JPEG
            var jpegOptions = new JpegOptions();
            epsImage.Save(outputPath, jpegOptions);
        }
    }
}