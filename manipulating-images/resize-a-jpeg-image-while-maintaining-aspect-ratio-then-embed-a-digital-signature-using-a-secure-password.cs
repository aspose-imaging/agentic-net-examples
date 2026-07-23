using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths and password
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_signed.jpg";
        string password = "SecurePassword123";

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
            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure we are working with a raster image
                if (image is RasterImage rasterImage)
                {
                    // Desired maximum width (maintain aspect ratio)
                    const int maxWidth = 800;

                    // Calculate new dimensions while preserving aspect ratio
                    int originalWidth = rasterImage.Width;
                    int originalHeight = rasterImage.Height;

                    if (originalWidth > maxWidth)
                    {
                        double aspectRatio = (double)originalHeight / originalWidth;
                        int newWidth = maxWidth;
                        int newHeight = (int)Math.Round(maxWidth * aspectRatio);

                        // Resize the image
                        rasterImage.Resize(newWidth, newHeight);
                    }

                    // Embed digital signature using the provided password
                    rasterImage.EmbedDigitalSignature(password);

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded JPEG photos while preserving the original aspect ratio and then protect the files with a password‑protected digital signature before storing them on the server.
 * 2. When an e‑commerce platform must automatically downsize high‑resolution product images to a maximum width of 800 px for faster page loads, and embed a secure signature to verify image authenticity during the upload pipeline.
 * 3. When a document management system processes scanned JPEG documents, resizes them to fit within a standard layout, and applies a password‑protected digital signature to ensure tamper‑evidence before archiving.
 * 4. When a mobile backend service receives JPEG images from devices, reduces their dimensions to meet bandwidth constraints, and embeds a cryptographic signature using a known password to validate the source on later retrieval.
 * 5. When a digital asset workflow needs to prepare marketing JPEG assets by resizing them for social‑media specifications while embedding a secure digital signature to guarantee the brand’s ownership during distribution.
 */