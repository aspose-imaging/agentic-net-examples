using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var image = Image.Load(inputPath) as EpsImage)
            {
                if (image == null)
                {
                    Console.Error.WriteLine("Failed to load EPS image.");
                    return;
                }

                // Calculate new dimensions with scaling factor 1.5
                int newWidth = (int)(image.Width * 1.5);
                int newHeight = (int)(image.Height * 1.5);

                // Resize using high-quality Lanczos resampling
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Configure high-quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // Maximum quality
                };

                // Save as JPEG
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
 * 1. When a developer needs to enlarge a vector EPS logo by 150 % and deliver a high‑resolution JPEG for web or print.
 * 2. When an automated batch process must convert archived EPS artwork to JPEG thumbnails with a custom 1.5 scaling factor to maintain visual fidelity.
 * 3. When a C# application has to render a scalable EPS diagram at a larger size for inclusion in a PDF report, saving it as a high‑quality JPEG.
 * 4. When a graphics pipeline requires resizing EPS images using Lanczos resampling before exporting them as maximum‑quality JPEG files for e‑commerce product listings.
 * 5. When a .NET service must verify the existence of an EPS file, upscale it by 1.5, and store the result as a high‑quality JPEG for archival or preview purposes.
 */