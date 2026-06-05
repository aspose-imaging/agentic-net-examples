using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "frames";
            Directory.CreateDirectory(outputDir);

            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                var multipage = webPImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image does not support multiple frames.");
                    return;
                }

                int pageCount = multipage.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    var frame = multipage.Pages[i];
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions options = new BmpOptions();
                    options.Source = new FileCreateSource(outputPath, false);

                    using (Image frameImage = (Image)frame)
                    {
                        frameImage.Save();
                    }
                }
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
 * 1. When a developer needs to extract each frame from an animated WebP file and store them as individual BMP images for legacy Windows applications that only support BMP format.
 * 2. When a .NET application must convert WebP animation frames into BMP files to generate thumbnails for a media catalog that requires uncompressed bitmap files.
 * 3. When a game developer wants to preprocess animated WebP sprites by separating them into separate BMP assets for use in a sprite‑sheet pipeline that only accepts BMP inputs.
 * 4. When an image‑processing service has to batch‑process uploaded WebP animations and archive each frame as BMP files for compliance with a document‑management system that stores images in BMP.
 * 5. When a developer is building a diagnostic tool that reads a WebP image, enumerates its pages via IMultipageImage, and saves each page as a BMP to allow pixel‑perfect visual inspection in standard image viewers.
 */