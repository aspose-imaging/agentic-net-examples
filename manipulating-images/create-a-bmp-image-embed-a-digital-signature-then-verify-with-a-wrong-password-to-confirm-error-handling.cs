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
            // Hardcoded paths
            string outputPath = "output.bmp";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create BMP canvas (200x200) bound to the output file
            Source bmpSource = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = bmpSource };
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 200, 200))
            {
                // Fill canvas with a solid color (light gray)
                for (int y = 0; y < canvas.Height; y++)
                {
                    for (int x = 0; x < canvas.Width; x++)
                    {
                        canvas.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, 200, 200, 200));
                    }
                }
                // Save the newly created image (bound source)
                canvas.Save();
            }

            // Verify the file was created
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Load the BMP image for digital signature operations
            using (RasterImage image = (RasterImage)Image.Load(outputPath))
            {
                // Embed digital signature with a valid password
                image.EmbedDigitalSignature("secure123");
                image.Save();

                // Attempt to embed with an invalid password to demonstrate error handling
                try
                {
                    image.EmbedDigitalSignature("123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    Console.WriteLine($"HANDLED: {ex.Message}");
                }

                // Verify signature with a wrong password (should be false)
                bool isSignedWrong = image.IsDigitalSigned("123");
                Console.WriteLine($"Is signed with wrong password: {isSignedWrong}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}