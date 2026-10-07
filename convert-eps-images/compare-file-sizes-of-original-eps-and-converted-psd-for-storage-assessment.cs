// HOW-TO: Compare EPS and PSD File Sizes After Conversion in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace EPSSizeComparison
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output.psd";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var psdOptions = new PsdOptions();
                    image.Save(outputPath, psdOptions);
                }

                long epsSize = new FileInfo(inputPath).Length;
                long psdSize = new FileInfo(outputPath).Length;

                Console.WriteLine($"EPS file size: {epsSize} bytes");
                Console.WriteLine($"PSD file size: {psdSize} bytes");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to evaluate storage requirements by measuring how an EPS vector file size changes after converting it to a PSD raster file in a C# application.
 * 2. When you want to decide whether to keep original EPS assets or replace them with PSD versions for a digital asset management system based on their file size differences.
 * 3. When performing batch processing to ensure that converted PSD files do not exceed size limits for cloud storage or email attachments.
 * 4. When auditing a design workflow to verify that converting EPS artwork to Photoshop PSD does not significantly increase disk usage before archiving.
 * 5. When building a reporting tool that logs the byte size of source EPS files and their PSD counterparts to monitor storage costs over time.
 */
