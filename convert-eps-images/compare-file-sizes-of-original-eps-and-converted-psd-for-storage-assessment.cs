// HOW-TO: Compare EPS and PSD File Sizes After Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/converted.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                using (var psdOptions = new PsdOptions())
                {
                    epsImage.Save(outputPath, psdOptions);
                }
            }

            var epsInfo = new FileInfo(inputPath);
            var psdInfo = new FileInfo(outputPath);

            Console.WriteLine($"EPS size: {epsInfo.Length} bytes");
            Console.WriteLine($"PSD size: {psdInfo.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to assess storage impact of converting vector EPS artwork to raster PSD files in a .NET application.
 * 2. When you want to verify that a batch conversion process does not increase file size beyond a storage budget.
 * 3. When you are migrating legacy EPS assets to Photoshop PSD format and must compare original and converted sizes for archiving decisions.
 * 4. When you need to log EPS and PSD byte counts to monitor disk usage in an automated image processing pipeline.
 * 5. When you are troubleshooting unexpected size growth after converting EPS to PSD using Aspose.Imaging in C#.
 */
