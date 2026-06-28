using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options for 24‑bit truecolor (8 bits per channel)
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.Truecolor, // 24‑bit RGB
                    BitDepth = 8                         // 8 bits per channel
                };

                // Save the image as PNG with the specified options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must convert high‑resolution JPEG photographs to lossless 24‑bit PNG files for archival or printing, developers can use Aspose.Imaging to load the JPEG and save it with PngOptions set to Truecolor and an 8‑bit per channel depth.
 * 2. When a .NET service processes user‑uploaded images and needs to standardize them to a PNG format with truecolor (24‑bit) to ensure consistent color fidelity across browsers, the code demonstrates how to verify file existence, create output directories, and perform the conversion with Aspose.Imaging.
 * 3. When building a batch‑processing tool that prepares graphics for e‑commerce catalogs, developers can employ this snippet to read each source image, configure PngOptions for 24‑bit color depth, and export a lossless PNG that meets catalog quality standards.
 * 4. When integrating image manipulation into a C# desktop application that requires saving edited pictures without compression artifacts, the example shows how to use Aspose.Imaging’s Image.Load and Image.Save methods to produce a 24‑bit PNG for lossless storage.
 * 5. When automating a workflow that extracts frames from high‑resolution video and stores them as PNG files with truecolor for later analysis, developers can apply this code to ensure each frame is saved with 8‑bit per channel depth using Aspose.Imaging.
 */