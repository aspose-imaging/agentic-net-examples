using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\input.gif";
            string outputPath = "c:\\temp\\output_contrast.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Adjust contrast to a high level (maximum is 100)
                gifImage.AdjustContrast(100f);

                // Save the modified image as a GIF
                gifImage.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to enhance the visual impact of animated GIF banners for a marketing email by increasing contrast before sending.
 * 2. When a C# application must preprocess user‑uploaded GIF avatars to make them stand out on a social platform by applying a high‑contrast filter.
 * 3. When an automated build pipeline generates product demo GIFs and requires a step to boost contrast for better visibility on high‑DPI screens.
 * 4. When a legacy system converts scanned GIF documents into a more readable format and the code is used to improve legibility by adjusting contrast.
 * 5. When a game developer prepares animated GIF sprites and wants to ensure they appear crisp against varied backgrounds by programmatically increasing contrast with Aspose.Imaging.
 */