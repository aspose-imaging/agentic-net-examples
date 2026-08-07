using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\vector.svg";
        string outputPath = @"C:\Images\Resized\vector_resized.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the vector image
            using (Image image = Image.Load(inputPath))
            {
                // Desired maximum dimensions
                const int maxWidth = 800;
                const int maxHeight = 600;

                // Compute scaling factor while preserving aspect ratio
                double widthScale = (double)maxWidth / image.Width;
                double heightScale = (double)maxHeight / image.Height;
                double scale = Math.Min(widthScale, heightScale);
                if (scale > 1) scale = 1; // Do not upscale

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize using a high‑quality resampling method
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare JPEG save options with 90% quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    // Optional: set resolution unit and DPI if needed
                    ResolutionUnit = ResolutionUnit.Inch,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Save the resized image as JPEG
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos for product listings, it can use this C# code with Aspose.Imaging to resize the vector while preserving aspect ratio and save a 90 % quality JPEG for fast browser rendering.
 * 2. When an e‑commerce platform must create printable catalog images from designer‑provided vector artwork, the code can downscale the SVG to fit catalog dimensions and export a high‑quality JPEG suitable for print workflows.
 * 3. When a content management system automatically converts scalable icons into raster images for email newsletters, this snippet ensures the icons are resized proportionally and saved as JPEGs with consistent compression.
 * 4. When a mobile app backend prepares responsive images from SVG assets for different device screen sizes, the code resizes the vector without distortion and outputs a JPEG with 90 % quality to balance visual fidelity and bandwidth.
 * 5. When a digital signage solution needs to pre‑process SVG graphics into JPEG files that match specific display resolutions, the example provides a reliable way to maintain aspect ratio and achieve high‑quality raster output in C#.
 */