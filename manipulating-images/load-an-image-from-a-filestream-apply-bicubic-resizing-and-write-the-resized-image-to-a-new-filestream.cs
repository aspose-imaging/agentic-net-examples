using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open input file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Load image from stream
                using (Image image = Image.Load(inputStream))
                {
                    // Determine new dimensions (example: half the original size)
                    int newWidth = image.Width / 2;
                    int newHeight = image.Height / 2;

                    // Resize using bicubic (CubicConvolution) interpolation
                    image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                    // Prepare output stream and save options
                    using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                    {
                        var saveOptions = new PngOptions();
                        // Save resized image to output stream
                        image.Save(outputStream, saveOptions);
                    }
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
 * 1. When a web service needs to generate thumbnail previews of uploaded JPEG photos for a gallery, it can load the image from a FileStream, resize it with bicubic interpolation, and save the smaller PNG to a response stream.
 * 2. When a desktop application must batch‑convert high‑resolution product images to web‑friendly PNGs at half size, the code reads each file via FileStream, applies a cubic convolution resize, and writes the optimized image back to disk.
 * 3. When an e‑commerce platform wants to create fast‑loading preview images for mobile devices, it can stream the original JPG, resize it using Aspose.Imaging’s bicubic algorithm, and store the result as a PNG in a temporary folder.
 * 4. When a document generation tool embeds resized company logos into PDFs, it can load the source logo from a FileStream, shrink it with high‑quality bicubic scaling, and output the PNG to a memory or file stream for further processing.
 * 5. When an automated CI/CD pipeline validates image assets by down‑sampling them before publishing, the pipeline can read each asset via FileStream, resize with ResizeType.CubicConvolution, and write the reduced PNG to the build output directory.
 */