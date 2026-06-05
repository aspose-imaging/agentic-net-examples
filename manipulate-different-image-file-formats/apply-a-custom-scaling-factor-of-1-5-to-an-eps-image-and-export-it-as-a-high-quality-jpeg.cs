using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\sample_scaled.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new dimensions with a scaling factor of 1.5
                int newWidth = (int)(epsImage.Width * 1.5);
                int newHeight = (int)(epsImage.Height * 1.5);

                // Resize using a high‑quality resampling method
                epsImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Configure high‑quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // Maximum quality
                };

                // Save as JPEG
                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to enlarge a vector EPS logo by 150 % and deliver it as a high‑quality JPEG for web publishing, they can use this code.
 * 2. When a print‑to‑screen workflow requires converting EPS artwork to a larger raster JPEG with maximum quality for client review, the example shows how to apply a 1.5 scaling factor in C#.
 * 3. When an e‑commerce platform must generate product thumbnails from EPS source files at a custom size while preserving detail, the code demonstrates resizing with Lanczos resampling and saving as JPEG.
 * 4. When a digital asset management system needs to batch‑process EPS files, scaling them up and exporting them as high‑resolution JPEGs for archival, this snippet provides the necessary steps.
 * 5. When a marketing automation script has to convert EPS banners to larger JPEG images for email campaigns, ensuring the output uses Aspose.Imaging’s JpegOptions with 100 % quality, the example is applicable.
 */