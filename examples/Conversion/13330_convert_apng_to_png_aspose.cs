using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source APNG file
        string sourcePath = "input.apng";

        // Path for the resulting PNG file
        string destinationPath = "output.png";

        // Load the APNG image. Only the active frame (first frame) will be kept for PNG.
        using (Image apngImage = Image.Load(sourcePath))
        {
            // Save the loaded image as a PNG file.
            // Since PNG is a single‑frame format, only the active frame is written.
            apngImage.Save(destinationPath, new PngOptions());
        }

        Console.WriteLine("Conversion completed.");
    }
}