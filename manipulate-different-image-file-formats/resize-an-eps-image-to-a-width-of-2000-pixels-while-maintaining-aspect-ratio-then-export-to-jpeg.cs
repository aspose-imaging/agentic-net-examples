using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\Result\resized.jpg";

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

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate new height to keep aspect ratio for a width of 2000 pixels
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

                // Resize using a high‑quality interpolation method
                image.Resize(newWidth, newHeight, ResizeType.Mitchell);

                // Prepare JPEG save options (default options are sufficient for this example)
                var jpegOptions = new JpegOptions();

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
 * 1. When a developer needs to convert high‑resolution EPS artwork into a web‑friendly JPEG thumbnail of exactly 2000 px width while preserving the original aspect ratio, this code provides a quick C# solution using Aspose.Imaging.
 * 2. When an e‑commerce platform must generate product preview images from vector EPS files for faster page loads, the snippet resizes the vector to 2000 px wide and saves it as a JPEG.
 * 3. When a publishing workflow requires converting print‑ready EPS logos into JPEG assets for inclusion in digital PDFs, the example demonstrates how to maintain visual fidelity with Mitchell interpolation in C#.
 * 4. When an automated batch job processes a folder of EPS diagrams and needs each file resized to a consistent width before archiving as JPEG, the code shows the necessary file‑system checks and resizing logic.
 * 5. When a mobile app backend must serve scaled‑down JPEG versions of EPS‑based icons to devices with limited bandwidth, this sample illustrates the aspect‑ratio‑preserving resize and export using Aspose.Imaging for .NET.
 */