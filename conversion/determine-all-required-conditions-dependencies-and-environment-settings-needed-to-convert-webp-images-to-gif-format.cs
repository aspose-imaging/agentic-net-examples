using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class WebPToGifConverter
{
    static void Main()
    {
        // ------------------------------------------------------------
        // Required environment / dependencies
        // ------------------------------------------------------------
        // 1. Aspose.Imaging for .NET library must be referenced.
        //    Install via NuGet:  Install-Package Aspose.Imaging
        // 2. A valid Aspose.Imaging license should be set before usage
        //    (optional for evaluation, but required for production).
        //    Example: new Aspose.Imaging.License().SetLicense("Aspose.Imaging.lic");
        // 3. .NET Framework 4.6+ or .NET Core 2.0+ is supported.
        // 4. Ensure the input directory exists and the WebP file is present.

        // ------------------------------------------------------------
        // Define input and output paths
        // ------------------------------------------------------------
        string dir = @"c:\temp\";                     // Change to your working folder
        string inputPath = Path.Combine(dir, "test.webp");
        string outputPath = Path.Combine(dir, "test.gif");

        // ------------------------------------------------------------
        // Load the WebP image (using the provided load rule)
        // ------------------------------------------------------------
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // ------------------------------------------------------------
            // Save the image as GIF (using the provided save rule)
            // ------------------------------------------------------------
            // Note: Only the active frame of a multi‑frame WebP will be saved.
            // If you need to handle animated WebP, additional frame extraction
            // logic would be required (outside the scope of the basic rule).
            webPImage.Save(outputPath, new GifOptions());

            // Optional: you can customize GifOptions (e.g., background color,
            // interlacing, palette) before saving if required.
        }

        Console.WriteLine("Conversion completed: " + outputPath);
    }
}