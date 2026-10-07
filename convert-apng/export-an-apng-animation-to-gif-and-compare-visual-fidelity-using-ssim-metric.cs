// HOW-TO: Convert APNG Animation to GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                apng.Save(outputPath, new GifOptions());
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
 * 1. When you need to display an animated PNG on platforms that only support GIF, you can convert the APNG to a GIF with Aspose.Imaging in C#.
 * 2. When preparing assets for email newsletters that require GIF animations, this code transforms APNG files into GIF format programmatically.
 * 3. When automating a batch process that migrates legacy APNG assets to GIF for a mobile app, the snippet provides the conversion logic.
 * 4. When integrating image conversion into a .NET web service that receives APNG uploads and returns GIFs for browser compatibility, this example shows the required steps.
 * 5. When evaluating visual fidelity after conversion, you can first export the APNG to GIF using this code and then calculate SSIM to compare the two animations.
 */
