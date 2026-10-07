// HOW-TO: Resize Image to Fit 1024x1024 Box Using Nearest Neighbor in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\resized.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                const int maxDimension = 1024;
                double scale = Math.Min((double)maxDimension / image.Width, (double)maxDimension / image.Height);
                int newWidth = (int)Math.Round(image.Width * scale);
                int newHeight = (int)Math.Round(image.Height * scale);

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                image.Save(outputPath);
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
 * 1. When you need to generate thumbnails for a web gallery and must keep the original aspect ratio while limiting dimensions to 1024 × 1024 pixels.
 * 2. When uploading user‑provided photos to a cloud service and you want to reduce file size by scaling them down with the fast NearestNeighbour algorithm.
 * 3. When preparing product images for an e‑commerce platform that requires all pictures to fit inside a 1024 × 1024 bounding box without distortion.
 * 4. When converting high‑resolution scans to a manageable size for mobile apps, preserving the aspect ratio using Aspose.Imaging in a C# backend.
 * 5. When batch‑processing a folder of JPEG files to ensure they meet a maximum resolution for email attachments while maintaining visual quality.
 */
