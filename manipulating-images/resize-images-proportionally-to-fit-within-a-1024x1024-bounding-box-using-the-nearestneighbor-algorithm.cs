using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        const string inputPath = @"C:\Images\input.jpg";
        const string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                const int maxSize = 1024; // Bounding box dimension

                // Determine scaling factor to fit within 1024x1024 while preserving aspect ratio
                double widthRatio = (double)maxSize / image.Width;
                double heightRatio = (double)maxSize / image.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                // If the image is larger than the bounding box, resize it
                if (scale < 1.0)
                {
                    int newWidth = Math.Max(1, (int)(image.Width * scale));
                    int newHeight = Math.Max(1, (int)(image.Height * scale));

                    // Resize using NearestNeighbour algorithm
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                }

                // Save the (possibly resized) image
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded JPEG photos so they fit inside a 1024 × 1024 box without distortion, a developer can use this C# Aspose.Imaging code with the NearestNeighbour algorithm.
 * 2. When an e‑commerce platform must downsize product images before storing them in Azure Blob Storage to meet a 1 MB size limit while preserving aspect ratio, the code resizes the PNG or JPG files to a maximum of 1024 × 1024 pixels.
 * 3. When a mobile game server processes sprite sheets in BMP format and wants to reduce their dimensions for faster transmission to clients, the developer can call Image.Resize with ResizeType.NearestNeighbourResample to keep the graphics crisp.
 * 4. When an automated email system attaches resized screenshots of a Windows desktop (saved as PNG) to keep the email size low, the C# routine ensures each image fits within a 1024 × 1024 bounding box.
 * 5. When a content‑management workflow converts high‑resolution scans (TIFF) into web‑ready images, the developer can use this Aspose.Imaging snippet to proportionally shrink the files to 1024 × 1024 pixels while using the fast NearestNeighbour resampling method.
 */