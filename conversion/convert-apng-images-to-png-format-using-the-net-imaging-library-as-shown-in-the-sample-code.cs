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

        // Load the APNG image using the Aspose.Imaging Image.Load method
        using (Image apngImage = Image.Load(sourcePath))
        {
            // Save the first (active) frame of the APNG as a regular PNG.
            // PNG is a single‑frame format, so only the active frame will be stored.
            apngImage.Save(destinationPath, new PngOptions());
        }

        Console.WriteLine("Conversion completed.");
    }
}