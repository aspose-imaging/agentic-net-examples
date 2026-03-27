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
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\sample.jpg";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image and save it as JPEG
        using (Image image = Image.Load(inputPath) as EpsImage)
        {
            if (image == null)
            {
                Console.Error.WriteLine("Failed to load EPS image.");
                return;
            }

            // Save the image to JPEG format using default JPEG options
            image.Save(outputPath, new JpegOptions());
        }
    }
}