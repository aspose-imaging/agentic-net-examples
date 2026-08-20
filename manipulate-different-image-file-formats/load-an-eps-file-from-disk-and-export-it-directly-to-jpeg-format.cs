// HOW-TO: Convert EPS File to JPEG with Quality Setting in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Set JPEG export options (default options can be used)
                var jpegOptions = new JpegOptions
                {
                    // Example: set quality to 90 (optional)
                    Quality = 90
                };

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to display vector EPS artwork on a website that only supports JPEG images, you can use this code to convert the file on the server.
 * 2. When generating thumbnails for a catalog of EPS drawings, the snippet lets you quickly render each EPS as a high‑quality JPEG for preview.
 * 3. When automating a workflow that receives EPS files from designers and must store them in a JPEG archive for long‑term storage, this code performs the conversion in .NET.
 * 4. When building a desktop application that lets users open EPS files and save them as JPEGs with a specific compression quality, the example provides the necessary steps.
 * 5. When creating a microservice that receives EPS uploads via an API and returns JPEG responses for downstream image‑processing pipelines, the code shows how to load and export the image using Aspose.Imaging.
 */
