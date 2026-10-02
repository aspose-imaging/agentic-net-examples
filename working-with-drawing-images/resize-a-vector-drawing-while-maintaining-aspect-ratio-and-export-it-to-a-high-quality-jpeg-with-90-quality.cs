// HOW-TO: Resize SVG to JPEG with Aspect Ratio and 90% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int targetWidth = 800;
                double aspectRatio = (double)image.Height / image.Width;
                int targetHeight = (int)(targetWidth * aspectRatio);

                image.Resize(targetWidth, targetHeight, ResizeType.LanczosResample);

                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

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
 * 1. When generating thumbnails for SVG logos to display on a website, you need to resize the vector and save it as a high‑quality JPEG.
 * 2. When converting user‑uploaded SVG diagrams into JPEGs for email attachments, maintaining the original aspect ratio prevents distortion.
 * 3. When preparing print‑ready images from scalable graphics, resizing to a specific width and exporting with 90 % JPEG quality ensures sharpness while keeping file size reasonable.
 * 4. When building a batch‑processing tool that standardizes image dimensions for a mobile app, you can load each SVG, resize proportionally, and save as JPEG.
 * 5. When integrating vector assets into a legacy system that only supports JPEG, you must preserve the aspect ratio and control compression quality during conversion.
 */
