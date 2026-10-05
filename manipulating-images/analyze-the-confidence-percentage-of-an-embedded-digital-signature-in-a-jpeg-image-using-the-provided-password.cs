// HOW-TO: Analyze Digital Signature Confidence in JPEG Using Aspose Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            const string inputPath = "input.jpg";
            const string outputPath = "result.txt";
            const string password = "myPassword";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Image is not a raster image.");
                    return;
                }

                int confidence = raster.AnalyzePercentageDigitalSignature(password);
                File.WriteAllText(outputPath, confidence.ToString());
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
 * 1. When a developer needs to verify the authenticity of a JPEG that contains a password‑protected digital signature and obtain its confidence percentage.
 * 2. When integrating image processing into a document management system that must validate signed JPEGs before archiving them.
 * 3. When building a compliance audit tool that extracts the digital signature confidence score from scanned JPEG images for regulatory reporting.
 * 4. When creating a batch job that reads multiple JPEG files, checks each embedded signature with a known password, and writes the confidence results to a text report.
 * 5. When troubleshooting image security by programmatically measuring how strongly a JPEG’s embedded digital signature matches the expected password.
 */
