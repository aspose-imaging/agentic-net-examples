using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output path for the generated JPEG2000 image
            string outputPath = "Output/output.jp2";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions and bits per sample
            int width = 200;
            int height = 200;
            int bitsPerSample = 8; // bits per pixel

            // Create a JPEG2000 image with specified dimensions and bits per sample
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(width, height, bitsPerSample))
            {
                // Draw a solid red rectangle covering the entire image
                Graphics graphics = new Graphics(jpeg2000Image);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);

                // Save the image to the output path
                jpeg2000Image.Save(outputPath);
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
 * 1. When a developer needs to generate a JPEG2000 file from raw pixel data in a C# application, such as creating a high‑quality medical image thumbnail with a specific bits‑per‑sample setting using Aspose.Imaging.
 * 2. When building a satellite‑imagery processing pipeline that requires converting raw sensor arrays into JP2 files with defined bit depth and color space for efficient storage and transmission.
 * 3. When preparing digital publishing assets where a fixed‑size, lossless JPEG2000 image must be programmatically created from scratch, for example generating a solid‑color cover page in a .NET content‑management system.
 * 4. When archiving scientific experiment results that are captured as raw pixel matrices and need to be saved as JPEG2000 images with precise bits‑per‑sample control to preserve data fidelity.
 * 5. When writing automated tests for an image‑processing workflow and a developer needs to create a placeholder JPEG2000 image with known dimensions and color values to validate downstream C# image‑analysis code.
 */