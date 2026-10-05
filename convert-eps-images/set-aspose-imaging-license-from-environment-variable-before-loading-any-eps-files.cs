// HOW-TO: Load EPS and Convert to Grayscale PNG with License from Environment Variable in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.png";

            // Set Aspose.Imaging license from environment variable
            string licensePath = Environment.GetEnvironmentVariable("ASPOSE_IMAGING_LICENSE");
            if (!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
            {
                var license = new Aspose.Imaging.License();
                license.SetLicense(licensePath);
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using var image = Aspose.Imaging.Image.Load(inputPath);
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.Grayscale
            };
            image.Save(outputPath, pngOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a CI/CD pipeline needs to convert EPS artwork to grayscale PNGs without hard‑coding the Aspose.Imaging license path.
 * 2. When a desktop application processes vector EPS files uploaded by users and must save them as PNG images while respecting licensing stored in an environment variable.
 * 3. When a batch script runs on a server to generate low‑color PNG previews of EPS diagrams and the license key is supplied securely via environment settings.
 * 4. When a microservice receives EPS files via an API and returns grayscale PNG responses, using the license loaded from the container’s environment.
 * 5. When automated tests validate EPS to PNG conversion and require the Aspose.Imaging license to be set dynamically without modifying source code.
 */
