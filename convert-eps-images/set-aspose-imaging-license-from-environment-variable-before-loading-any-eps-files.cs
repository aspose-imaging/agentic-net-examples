using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Set Aspose.Imaging license from environment variable
        string licensePath = Environment.GetEnvironmentVariable("ASPOSE_IMAGING_LICENSE");
        if (!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
        {
            var license = new Aspose.Imaging.License();
            license.SetLicense(licensePath);
        }

        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\Result\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image, resize, and save as PNG
        using (var image = Image.Load(inputPath) as EpsImage)
        {
            if (image == null)
            {
                Console.Error.WriteLine("Failed to load EPS image.");
                return;
            }

            // Resize using Mitchell interpolation
            image.Resize(400, 400, ResizeType.Mitchell);

            // Save to PNG with default options
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}