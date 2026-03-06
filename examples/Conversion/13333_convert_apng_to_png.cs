using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class ApngToPngConverter
{
    static void Main()
    {
        // Path to the source APNG file
        string sourcePath = "input.apng";

        // Path for the resulting PNG file
        string destinationPath = "output.png";

        // Load the APNG image (only the active frame will be kept in memory)
        using (Image apngImage = Image.Load(sourcePath))
        {
            // Save the active frame as a regular PNG image
            // PNG is a single‑frame format, so only the first frame of the APNG is saved
            apngImage.Save(destinationPath, new PngOptions());
        }

        Console.WriteLine($"APNG file '{sourcePath}' has been converted to PNG '{destinationPath}'.");
    }
}