using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.eps";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load Aspose.Imaging license from environment variable if available
        string licensePath = Environment.GetEnvironmentVariable("ASPOSE_IMAGING_LICENSE");
        if (!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
        {
            try
            {
                var license = new Aspose.Imaging.License();
                license.SetLicense(licensePath);
            }
            catch
            {
                // Silently ignore license loading errors
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image with default load options
        using (Image image = Image.Load(inputPath, new EpsLoadOptions()))
        {
            // Resize the image (example: 400x400 using Mitchell interpolation)
            image.Resize(400, 400, ResizeType.Mitchell);

            // Save the result as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}