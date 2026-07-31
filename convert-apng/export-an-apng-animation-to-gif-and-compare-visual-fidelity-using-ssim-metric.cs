using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load APNG and save as GIF
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    apng.Save(outputPath, gifOptions);
                }
            }

            // SSIM comparison is not supported by Aspose.Imaging
            throw new NotSupportedException("SSIM metric comparison is not supported by Aspose.Imaging.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert an animated PNG (APNG) file into a widely supported GIF for browsers that lack APNG support, using C# and Aspose.Imaging.
 * 2. When a developer wants to automate batch processing of animation assets by loading APNG images, saving them as GIFs, and ensuring the output directory exists.
 * 3. When a developer must verify the existence of the source APNG file before performing image conversion to prevent runtime errors in a .NET application.
 * 4. When a developer builds a tool that compares visual fidelity of converted images and must handle the limitation that Aspose.Imaging does not support the SSIM metric, throwing a NotSupportedException.
 * 5. When a developer integrates image format conversion into a CI/CD pipeline, using Aspose.Imaging’s GifOptions to preserve animation frames while converting from APNG to GIF in C#.
 */