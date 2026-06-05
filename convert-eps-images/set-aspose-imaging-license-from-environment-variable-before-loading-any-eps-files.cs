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
        string inputPath = @"C:\Images\input.eps";
        string outputPath = @"C:\Images\output.png";

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
                var license = new License();
                license.SetLicense(licenseEnv);
            }
            else
            {
                Console.Error.WriteLine("Aspose.Imaging license not found. Proceeding without a license.");
            }

            // Load EPS image with default load options
            using (var image = Image.Load(inputPath, new EpsLoadOptions()))
            {
                // Example processing: resize the image
                image.Resize(800, 600, ResizeType.Mitchell);

                // Save the processed image as PNG
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