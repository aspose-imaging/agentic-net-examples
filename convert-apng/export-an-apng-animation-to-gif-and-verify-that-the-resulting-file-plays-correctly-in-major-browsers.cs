// HOW-TO: Convert APNG Animation to GIF for Browser Compatibility in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.apng";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                apng.Save(outputPath, options);
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
 * 1. When you need to serve animated images on websites that only support GIF, you can convert APNG files to GIF using Aspose.Imaging in C#.
 * 2. When integrating user‑generated content, converting uploaded APNG stickers to GIF ensures they display correctly across all major browsers.
 * 3. When building an email marketing system, converting APNG banners to GIF guarantees animation works in email clients that lack APNG support.
 * 4. When migrating legacy assets, batch‑processing APNG icons to GIF with C# simplifies compatibility with older web platforms.
 * 5. When creating a cross‑platform mobile app, converting APNG animations to GIF at runtime ensures smooth playback on iOS and Android browsers.
 */
