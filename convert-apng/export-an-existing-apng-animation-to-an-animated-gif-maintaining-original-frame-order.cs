using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.apng";
        string outputPath = "output.gif";

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

            // Load the APNG animation
            using (Image image = Image.Load(inputPath))
            {
                // Save as an animated GIF, preserving frame order
                image.Save(outputPath, new GifOptions());
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
 * 1. When a web developer needs to convert an APNG sprite animation into a widely supported animated GIF for older browsers using C# and Aspose.Imaging while keeping the original frame sequence.
 * 2. When a mobile app team wants to generate GIF previews of user‑uploaded APNG stickers on a server‑side .NET service, preserving the animation order with Aspose.Imaging.
 * 3. When an e‑learning platform must transform APNG tutorial animations into GIFs for inclusion in PDF handouts, using C# code that maintains frame order.
 * 4. When a digital marketing system automatically creates animated GIF banners from APNG assets for email campaigns, requiring reliable frame‑by‑frame conversion via Aspose.Imaging.
 * 5. When a game developer exports APNG character animations to GIF files for documentation or social media sharing, ensuring the original frame order is retained with C#.
 */