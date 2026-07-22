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
            string inputPath = @"C:\temp\canvas.png";
            string outputPath = @"C:\temp\canvas_gamma.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image from the HTML5 canvas (assumed PNG format)
            using (Image image = Image.Load(inputPath))
            {
                // Apply gamma correction of 2.2 if the image supports it
                if (image is RasterImage rasterImage)
                {
                    rasterImage.AdjustGamma(2.2f);
                }

                // Prepare JPEG options with quality 90
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save the processed image as JPEG
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
 * 1. When a web app captures an HTML5 canvas as a PNG and must adjust its brightness for standard monitors, a developer can apply a 2.2 gamma correction and save the result as a high‑quality JPEG.
 * 2. When an e‑learning platform generates client‑side diagrams on a canvas and needs to deliver them as compressed JPEGs for email, this C# code loads the PNG, corrects gamma, and exports with 90 % quality.
 * 3. When a digital asset management system receives user‑uploaded canvas drawings and wants to normalize their gamma before archiving them as JPEG thumbnails, the snippet shows how to perform the adjustment using Aspose.Imaging.
 * 4. When a marketing automation tool creates promotional graphics on an HTML5 canvas and must ensure consistent color rendering across browsers before uploading to a CDN, the example demonstrates applying gamma correction and outputting a JPEG with controlled compression.
 * 5. When a desktop utility converts canvas‑generated PNG screenshots to JPEG for printing, applying a 2.2 gamma curve guarantees accurate tonal reproduction, and this code illustrates the complete process in .NET.
 */