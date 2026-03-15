using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // Example format namespace
using Aspose.Imaging.ImageOptions;

class RotateFlipExample
{
    static void Main()
    {
        // Load an existing image from disk (replace with your actual file path)
        using (Image image = Image.Load("input.png"))
        {
            // Apply rotation of 90 degrees and horizontal flip
            // RotateFlipType combines rotation and flip operations
            image.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Save the transformed image to a new file (replace with desired output path)
            image.Save("output.png");
        }

        Console.WriteLine("Image rotation and flip completed.");
    }
}