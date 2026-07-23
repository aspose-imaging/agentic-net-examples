using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open input file stream and load the image
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image image = Image.Load(inputStream))
            {
                // Desired dimensions for resizing (example: half size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Apply bicubic (cubic convolution) resizing
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Prepare PNG save options (can be changed to other formats)
                PngOptions saveOptions = new PngOptions();

                // Open output file stream and save the resized image
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    image.Save(outputStream, saveOptions);
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
 * 1. When a web service needs to generate thumbnail previews of user‑uploaded JPEG photos and store them as PNG files on disk.
 * 2. When a desktop application must batch‑process scanned documents, reducing their resolution by half using bicubic interpolation before archiving them in a lossless format.
 * 3. When an e‑commerce platform wants to create smaller product images on the fly to improve page load speed while preserving quality, reading the original file via FileStream and writing the resized PNG.
 * 4. When a mobile backend needs to convert high‑resolution camera captures to a more bandwidth‑friendly size for email attachments, using C# streams and Aspose.Imaging’s ResizeType.CubicConvolution.
 * 5. When an automated reporting tool extracts charts from PDFs, resizes them to fit a PDF page, and saves the result as PNG using file streams for reliable resource management.
 */