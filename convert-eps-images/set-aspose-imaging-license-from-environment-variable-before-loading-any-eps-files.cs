using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.eps";
            string outputPath = @"C:\Images\output\sample_resized.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set Aspose.Imaging license from environment variable
            string licensePath = Environment.GetEnvironmentVariable("ASPOSE_IMAGING_LICENSE");
            if (!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
            {
                var license = new Aspose.Imaging.License();
                license.SetLicense(licensePath);
            }

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Resize the image (example: 400x400 using Mitchell interpolation)
                image.Resize(400, 400, ResizeType.Mitchell);

                // Save as PNG
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

/*
 * Real-World Use Cases:
 * 1. When deploying a .NET web service that converts customer‑uploaded EPS logos to web‑ready PNG thumbnails, you need to read the Aspose.Imaging license from an environment variable before processing each file.
 * 2. When automating a nightly build pipeline that generates product catalog images by resizing EPS artwork to a fixed 400 × 400 pixel size, the license must be set from an environment variable to keep the build server configuration simple.
 * 3. When creating a Windows desktop application that lets users import EPS vector files and export them as PNGs for presentation slides, you must load the Aspose.Imaging license from an environment variable to avoid hard‑coding the license path.
 * 4. When running a containerized microservice that receives EPS files via an API, resizes them, and returns PNG responses, the service reads the license location from an environment variable to stay portable across environments.
 * 5. When integrating Aspose.Imaging into a CI/CD workflow that validates EPS assets by converting them to PNG and checking dimensions, setting the license from an environment variable ensures the validation script works on any build agent without code changes.
 */