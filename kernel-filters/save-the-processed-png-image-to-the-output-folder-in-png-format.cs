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
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // (Optional) image processing could be performed here

                // Save the image as PNG with default options
                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy BMP files to PNG for web delivery, this code loads the BMP and saves it as a PNG with default options.
 * 2. When an automated batch job must ensure that all images in a folder are stored in a lossless PNG format for archival, the snippet verifies the input file, creates the output directory, and performs the conversion.
 * 3. When a C# application processes user‑uploaded bitmap images and must return a PNG thumbnail, the example shows how to load the bitmap, optionally apply processing, and save the result as PNG.
 * 4. When a Windows service monitors a directory for new BMP assets and needs to generate PNG versions for downstream services, the code demonstrates the required file existence check and directory creation before saving.
 * 5. When a developer is building a migration tool that standardizes image formats across a legacy system, this snippet provides a simple way to read each BMP and write it out as a PNG using Aspose.Imaging.
 */