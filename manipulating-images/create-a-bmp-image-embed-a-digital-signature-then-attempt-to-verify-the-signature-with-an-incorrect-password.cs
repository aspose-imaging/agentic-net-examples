using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string outputPath = @"c:\temp\signed.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP canvas (200x200) and embed a digital signature
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, 200, 200))
            {
                // Fill canvas with a solid color
                for (int y = 0; y < canvas.Height; y++)
                {
                    for (int x = 0; x < canvas.Width; x++)
                    {
                        canvas.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, 100, 150, 200));
                    }
                }

                // Embed digital signature with a valid password
                canvas.EmbedDigitalSignature("secure123");

                // Save the image (bound to the source)
                canvas.Save();
            }

            // Verify the signature with an incorrect password
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            using (RasterImage loadedImage = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = loadedImage.IsDigitalSigned("123");
                Console.WriteLine($"Is signed with wrong password: {isSigned}");
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
 * 1. When a developer must generate a BMP file in C# and protect it with a password‑protected digital signature to ensure the image has not been tampered with.
 * 2. When an application needs to embed a secure digital signature into a raster BMP image using Aspose.Imaging before distributing the file to clients.
 * 3. When a system requires validation that a signed BMP image cannot be opened with an incorrect password, demonstrating the robustness of the signature verification logic.
 * 4. When a workflow involves programmatically creating a solid‑color BMP canvas, applying a digital signature, and then testing the signature check to handle authentication failures gracefully.
 * 5. When a developer wants to log or display the result of a failed digital signature verification on a BMP file to trigger security alerts or fallback processes.
 */