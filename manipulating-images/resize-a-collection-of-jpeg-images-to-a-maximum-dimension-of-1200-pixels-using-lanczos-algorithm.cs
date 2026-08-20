// HOW-TO: Resize Multiple JPEG Images to 1200 Pixels Using Lanczos in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output directories.
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of JPEG files to process (add or modify as needed).
            string[] files = new[]
            {
                "photo1.jpg",
                "photo2.jpg",
                "photo3.jpg"
            };

            // Maximum dimension (width or height) after resizing.
            const int maxDimension = 1200;

            foreach (string fileName in files)
            {
                // Build full input and output paths.
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, fileName);

                // Verify that the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG image.
                using (Image image = Image.Load(inputPath))
                {
                    // Determine scaling factor while preserving aspect ratio.
                    int newWidth = image.Width;
                    int newHeight = image.Height;

                    if (image.Width > image.Height)
                    {
                        if (image.Width > maxDimension)
                        {
                            newWidth = maxDimension;
                            newHeight = (int)Math.Round((double)image.Height * maxDimension / image.Width);
                        }
                    }
                    else
                    {
                        if (image.Height > maxDimension)
                        {
                            newHeight = maxDimension;
                            newWidth = (int)Math.Round((double)image.Width * maxDimension / image.Height);
                        }
                    }

                    // Resize using Lanczos resampling.
                    image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                    // Save the resized image back as JPEG.
                    // Using default JPEG options; you can customize if needed.
                    image.Save(outputPath, new JpegOptions());
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
 * 1. When you need to batch‑process product photos for a web catalog, ensuring each JPEG does not exceed 1200 pixels while preserving quality with Lanczos resampling.
 * 2. When preparing user‑uploaded images for a mobile app, you can automatically shrink them to a maximum dimension to reduce bandwidth and storage costs.
 * 3. When creating thumbnails for a photo‑gallery website, you can resize the original JPEGs to a consistent size without distorting the aspect ratio.
 * 4. When optimizing images for email newsletters, you can limit the width or height to 1200 pixels to keep the message size small and maintain visual clarity.
 * 5. When migrating legacy image archives to a new system, you can uniformly resize all JPEG files to a manageable size before importing them.
 */
