// HOW-TO: Batch Embed Digital Signatures into Large Images with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    // Minimum pixel count required to embed a digital signature
    const int MinPixelCount = 1024 * 768; // example threshold

    // Password used for the digital signature
    const string SignaturePassword = "MySecretPassword";

    static void Main()
    {
        // Hardcoded input and output file paths
        string[] inputPaths = {
            @"C:\Images\Input1.jpg",
            @"C:\Images\Input2.png",
            @"C:\Images\Input3.tif"
        };

        string[] outputPaths = {
            @"C:\Images\Signed\Output1.jpg",
            @"C:\Images\Signed\Output2.png",
            @"C:\Images\Signed\Output3.tif"
        };

        try
        {
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image using Aspose.Imaging
                using (Image image = Image.Load(inputPath))
                {
                    // Ensure the image has width and height properties
                    int width = image.Width;
                    int height = image.Height;

                    // Check pixel count requirement
                    if (width * height >= MinPixelCount)
                    {
                        // Cast to RasterImage (covers most raster formats)
                        if (image is RasterImage rasterImage)
                        {
                            // Embed the digital signature
                            rasterImage.EmbedDigitalSignature(SignaturePassword);
                        }
                        else if (image is RasterCachedImage cachedImage)
                        {
                            // For cached images
                            cachedImage.EmbedDigitalSignature(SignaturePassword);
                        }
                        else if (image is RasterCachedMultipageImage multiPageImage)
                        {
                            // For multi‑page images
                            multiPageImage.EmbedDigitalSignature(SignaturePassword);
                        }
                        else
                        {
                            // If the image type does not support embedding, skip
                            Console.Error.WriteLine($"Unsupported image type for signing: {inputPath}");
                            continue;
                        }
                    }
                    else
                    {
                        // Skip embedding for images below the pixel threshold
                        Console.WriteLine($"Skipping {inputPath}: pixel count below threshold.");
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the (potentially modified) image to the output path
                    image.Save(outputPath);
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
 * 1. When you need to add a password‑protected digital signature to a set of high‑resolution JPEG, PNG, or TIFF files before archiving them.
 * 2. When a workflow requires signing only images that meet a minimum resolution (e.g., 1024×768 pixels) to ensure the signature is visible and tamper‑evident.
 * 3. When you want to automate the signing of product photos in a folder, skipping thumbnails or low‑resolution previews that don’t satisfy the pixel threshold.
 * 4. When integrating document management systems that store raster images and must embed a secure signature only on images large enough for legal compliance.
 * 5. When processing scanned contracts in C# and you must embed a digital signature on each scan that exceeds the defined pixel count while leaving smaller scans unchanged.
 */
