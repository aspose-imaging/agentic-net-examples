// HOW-TO: Convert APNG to GIF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
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

            using (Image image = Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to display an animated PNG on browsers that only support GIF, you can convert the APNG to a GIF using Aspose.Imaging in a C# application.
 * 2. When a mobile app requires GIF assets for animations but the source files are APNG, this code automates the conversion during the build process.
 * 3. When generating email newsletters that embed animated images, converting APNG to GIF ensures the animation works in most email clients.
 * 4. When creating a game asset pipeline that standardizes all sprite animations to GIF, this snippet can batch‑process APNG files on a server.
 * 5. When archiving user‑uploaded animations in a format with broader tool support, the code converts each APNG to GIF before storing it in the repository.
 */
