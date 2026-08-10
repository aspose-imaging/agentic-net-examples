// HOW-TO: Load EPS, Resize and Save as PNG with License from Environment Variable in C# (Aspose.Imaging for .NET)
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
            string licensePath = Environment.GetEnvironmentVariable("ASPOSE_IMAGING_LICENSE");
            if (!string.IsNullOrEmpty(licensePath) && File.Exists(licensePath))
            {
                var license = new Aspose.Imaging.License();
                license.SetLicense(licensePath);
            }

            // Load EPS image with default load options
            var loadOptions = new EpsLoadOptions();
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Example processing: resize to 400x400 using Mitchell interpolation
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
 * 1. When you need to convert EPS vector files to PNG thumbnails in a CI pipeline that stores the Aspose license path in an environment variable.
 * 2. When a web service must process uploaded EPS artwork, resize it to a fixed dimension, and return a PNG without hard‑coding the license location.
 * 3. When automating batch image processing on a server, you want to ensure the Aspose.Imaging license is applied from a secure environment variable before any EPS files are opened.
 * 4. When integrating Aspose.Imaging into a Docker container, you can read the license file path from an environment variable, load EPS files, resize them, and output PNGs.
 * 5. When building a desktop application that lets users open EPS files, automatically apply the license from the system environment, resize the image for preview, and save it as PNG.
 */
