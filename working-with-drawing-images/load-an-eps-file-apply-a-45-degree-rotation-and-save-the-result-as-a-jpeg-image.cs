using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image, rotate it, and save as JPEG
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Rotate the image by 45 degrees around its center
            image.Rotate(45f);

            // Define JPEG save options (default settings)
            var jpegOptions = new JpegOptions();

            // Save the rotated image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}