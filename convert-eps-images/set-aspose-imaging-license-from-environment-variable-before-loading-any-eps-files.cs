using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set Aspose.Imaging license from environment variable
            string licenseEnv = Environment.GetEnvironmentVariable("ASPOSE_IMAGING_LICENSE");
            if (!string.IsNullOrEmpty(licenseEnv) && File.Exists(licenseEnv))
            {
                var license = new Aspose.Imaging.License();
                license.SetLicense(licenseEnv);
            }

            // Load EPS image with default load options
            using (var image = Image.Load(inputPath, new EpsLoadOptions()))
            {
                // Resize the image (example dimensions)
                image.Resize(400, 400, ResizeType.Mitchell);

                // Save as PNG using default PNG options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}