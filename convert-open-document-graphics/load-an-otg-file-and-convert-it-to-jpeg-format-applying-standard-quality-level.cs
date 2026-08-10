// HOW-TO: Convert OTG Vector Image to JPEG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions();

                // Configure rasterization for vector OTG content
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                jpegOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save as JPEG with default quality
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
 * 1. When you need to display a CAD‑style OTG drawing on a web page that only supports JPEG images.
 * 2. When you must generate thumbnail previews of OTG files for a document management system using C#.
 * 3. When an automated batch job has to archive vector OTG graphics as compressed JPEG files for long‑term storage.
 * 4. When a reporting tool requires converting OTG charts into JPEG format to embed them in PDF reports.
 * 5. When a mobile app consumes JPEG images, and you have to transform server‑side OTG assets into JPEG on the fly with Aspose.Imaging.
 */
