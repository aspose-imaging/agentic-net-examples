// HOW-TO: Convert APNG Animation to GIF and Evaluate Quality with SSIM in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.apng";
            string outputPath = "Output/animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image apngImage = Image.Load(inputPath))
            {
                apngImage.Save(outputPath, new GifOptions());
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
 * 1. When you need to serve animated images on browsers that only support GIF, you can convert APNG files to GIF using Aspose.Imaging in C#.
 * 2. When you want to create a fallback GIF for an APNG asset in an email campaign, this code generates the GIF version automatically.
 * 3. When comparing the visual fidelity of the original APNG to the GIF output, you can run an SSIM analysis after conversion.
 * 4. When integrating image conversion into a .NET backend service that processes user‑uploaded animations, this snippet handles loading and saving the formats.
 * 5. When preparing assets for a legacy system that requires GIF animations, the code provides a simple way to transform APNG files programmatically.
 */
