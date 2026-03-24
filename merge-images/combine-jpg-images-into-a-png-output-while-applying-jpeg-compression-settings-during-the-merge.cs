using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG file paths
        string[] inputPaths = {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output PNG file path
        string outputPath = "output/combined.png";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load JPEG images
        Image[] jpegImages = new Image[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            jpegImages[i] = Image.Load(inputPaths[i]);
        }

        // Determine dimensions for the combined image
        int totalWidth = 0;
        int maxHeight = 0;
        foreach (var img in jpegImages)
        {
            totalWidth += img.Width;
            if (img.Height > maxHeight)
                maxHeight = img.Height;
        }

        // Create a blank PNG image with the calculated size
        var pngOptions = new PngOptions();
        using (Image combinedImage = Image.Create(pngOptions, totalWidth, maxHeight))
        {
            // Draw each JPEG onto the combined image
            var graphics = new Graphics(combinedImage);
            int offsetX = 0;
            foreach (var jpeg in jpegImages)
            {
                graphics.DrawImage(jpeg, offsetX, 0);
                offsetX += jpeg.Width;
                jpeg.Dispose(); // Release each source image after drawing
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the combined image as PNG
            combinedImage.Save(outputPath, pngOptions);
        }
    }
}