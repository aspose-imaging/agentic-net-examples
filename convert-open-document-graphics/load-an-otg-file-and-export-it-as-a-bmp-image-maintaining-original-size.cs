// HOW-TO: Convert OTG File to BMP Image While Preserving Original Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.otg";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                BmpOptions options = new BmpOptions();
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
 * 1. When a developer needs to display or edit an OTG graphic in a Windows application that only supports BMP, they can convert the file while keeping its dimensions.
 * 2. When integrating legacy printing workflows that require BMP inputs, the code allows automatic conversion from OTG without resizing the image.
 * 3. When creating thumbnails or previews for a document management system that stores BMP files, developers can load the original OTG and save it as BMP at its native size.
 * 4. When performing batch processing of OTG assets for a game engine that only accepts BMP textures, this snippet converts each file while preserving the original pixel count.
 * 5. When migrating archival OTG images to a more universally supported format for backup or sharing, the code ensures the BMP output matches the source image’s resolution.
 */
