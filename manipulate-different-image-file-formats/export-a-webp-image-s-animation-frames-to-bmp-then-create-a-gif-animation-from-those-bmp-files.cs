using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.webp";
            string outputPath = "Output/animation.gif";

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
 * 1. When a mobile app needs to display animated WebP content on platforms that only support GIF, a developer can extract the WebP frames to BMP and reassemble them into a GIF using C# and Aspose.Imaging.
 * 2. When an e‑learning platform wants to convert user‑uploaded animated WebP tutorials into GIFs for embedding in legacy LMS modules, the code can be used to transform each frame to BMP and generate a GIF.
 * 3. When a digital marketing system must generate GIF previews of animated WebP ads for email campaigns that do not support WebP, a developer can export the frames to BMP and create a GIF animation.
 * 4. When a game development pipeline requires converting animated WebP sprites into BMP frames for further processing before packaging them as GIF animations for UI elements, this code provides the necessary conversion.
 * 5. When a content management system needs to archive animated WebP files as BMP frame sequences and then produce a GIF version for cross‑browser compatibility, the code enables that workflow in .NET.
 */