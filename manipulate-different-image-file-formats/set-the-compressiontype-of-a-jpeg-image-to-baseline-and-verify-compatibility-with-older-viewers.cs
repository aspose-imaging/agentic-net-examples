// HOW-TO: Set JPEG Compression to Baseline Mode in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\sample_baseline.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions options = new JpegOptions())
                {
                    options.CompressionType = JpegCompressionMode.Baseline;
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to ensure a JPEG file can be opened by older browsers or legacy image viewers that only support baseline JPEG compression.
 * 2. When you are preparing images for email attachments where some clients reject progressive JPEGs, so you convert them to baseline.
 * 3. When you are archiving photos for long‑term storage and want maximum compatibility across different operating systems and devices.
 * 4. When you are generating thumbnails for a web gallery and must guarantee that all users, regardless of their viewer version, can view the images.
 * 5. When you are batch‑processing a collection of photos from a camera that saved them as progressive JPEGs and need to standardize them to baseline for a printing workflow.
 */
